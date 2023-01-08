using System.Text;
using Lab3.DataBase;
using Microsoft.AspNetCore.Components;

namespace Lab3.Pages.Components
{
    /// <summary>
    /// Добавление данных в проект.
    /// тут куча полей, которые связаны с UI с помощью bind + обработчики кнопок, после нажатия на которые
    /// мы проверяем поля на правильность и если все хорошо, то обращаемся к контексту, а если нет, выводим на UI что не так
    /// Так же есть обновление проекта. Нужно выбрать Id и вписать новые данные(криво, знаю, если на защите прижмет, то можно сделать намного лучше+
    /// я знаю даже как)
    /// </summary>
    public partial class AddAndUpdateProject
    {
        [Inject] MyDbContext Context { get; set; }
        private int Id { get; set; }
        private string NameProject { get; set; } = string.Empty;
        private string NameCustomerCompany { get; set; } = string.Empty;
        private string NamePerformerCompany { get; set; } = string.Empty;
        private string FullNameExecutor { get; set; } = string.Empty;
        private string FullNameSupervisor { get; set; } = string.Empty;
        private DateTime TheDateOfTheBeginning { get; set; }
        private DateTime ExpirationDate { get; set; }
        private int Priority { get; set; }
        private StringBuilder ErrorString { get; set; } = new();
        private async void AddNewProject()
        {
            if (!CheckToCorrect()) return;
            var project = new Project()
            {
                FullNameSupervisor = FullNameSupervisor,
                FullNameExecutor = FullNameExecutor,
                NameCustomerCompany = NameCustomerCompany,
                NamePerformerCompany = NamePerformerCompany,
                NameProject = NameProject,
                ExpirationDate = ExpirationDate,
                TheDateOfTheBeginning = TheDateOfTheBeginning,
                Priority = Priority
            };
            await Context.CreateProject(project);
        }
        private async void UpdateNewProject()
        {
            if (!CheckToCorrect()) return;
            var project = new Project()
            {
                Id = Id,
                FullNameSupervisor = FullNameSupervisor,
                FullNameExecutor = FullNameExecutor,
                NameCustomerCompany = NameCustomerCompany,
                NamePerformerCompany = NamePerformerCompany,
                NameProject = NameProject,
                ExpirationDate = ExpirationDate,
                TheDateOfTheBeginning = TheDateOfTheBeginning,
                Priority = Priority
            };
            await Context.UpdateProject(project);
        }

        private bool CheckToCorrect()
        {
            ErrorString.Clear();
            var ErrorCount = 0;
            if (string.IsNullOrWhiteSpace(NameProject) && string.IsNullOrWhiteSpace(FullNameSupervisor) && string.IsNullOrWhiteSpace(FullNameExecutor) &&
                string.IsNullOrWhiteSpace(NameCustomerCompany) && string.IsNullOrWhiteSpace(NamePerformerCompany))
            {
                ErrorCount++;
                ErrorString.Append($"{ErrorCount})Заполните все поля!");
            }
            if (TheDateOfTheBeginning > ExpirationDate)
            {
                ErrorCount++;
                ErrorString.Append($"{ErrorCount})Дата начала не может быть больше даты окончания!");
            }
            return ErrorCount == 0;
        }
    }
}
