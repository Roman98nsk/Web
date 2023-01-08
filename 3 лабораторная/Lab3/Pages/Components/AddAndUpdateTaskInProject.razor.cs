using System.Text;
using Lab3.DataBase;
using Microsoft.AspNetCore.Components;
using TaskStatus = Lab3.DataBase.TaskStatus;

namespace Lab3.Pages.Components
{
    /// <summary>
    /// Добавить или обновить задачу в проекте по логике такой же как и обновляльщик в AddAndUpdateProject
    /// </summary>
    public partial class AddAndUpdateTaskInProject
    {
        [Inject] MyDbContext Context { get; set; }
        [Parameter] public Project? ActiveProject { get; set; }
        [Parameter] public Worker? ActiveWorker { get; set; }
        private string TaskName { get; set; }
        private TaskStatus TaskStatus { get; set; }
        private int TaskId { get; set; }
        private StringBuilder ErrorString { get; set; } = new();
        private async void CreateTask()
        {
            if (!CheckToCorrect()) return;
            await Context.AddTaskToProject(ActiveProject,
                new Objective() { Status = TaskStatus, Name = TaskName, Worker = ActiveWorker });
        }

        private async void UpdateTask()
        {
            if (!CheckToCorrect()) return;
            await Context.UpdateTaskToProject(ActiveProject, new Objective() { Id = TaskId, Status = TaskStatus, Name = TaskName, Worker = ActiveWorker });
        }
        private bool CheckToCorrect()
        {
            ErrorString.Clear();
            var ErrorCount = 0;
            if (string.IsNullOrWhiteSpace(TaskName))
            {
                ErrorCount++;
                ErrorString.Append($"{ErrorCount})Заполните имя задачи не может быть пустым");
            }
            if (ActiveWorker?.Task != null)
            {
                ErrorCount++;
                ErrorString.Append($"{ErrorCount})Работник должен быть свободен!");
            }
            return ErrorCount == 0;
        }
    }
}
