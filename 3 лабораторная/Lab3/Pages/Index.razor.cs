using Lab3.DataBase;
using Microsoft.AspNetCore.Components;
using TaskStatus = Lab3.DataBase.TaskStatus;

namespace Lab3.Pages
{
    /// <summary>
    /// Страничка босс, которая управляет всеми страницами, содержит в себе все компоненты и обрабатывает ивенты от них, так же следит
    /// за правильностью отрисовки UI
    /// </summary>
    public partial class Index : IDisposable
    {
        [Inject] MyDbContext Context { get; set; }
        private List<Project>? Projects { get; set; }
        private List<Worker>? Workers { get; set; }
        private Project? ActiveProject { get; set; }
        private Worker? ActiveWorker { get; set; }
        /// <summary>
        /// При инициализации странички мы забираем из контекста проекты и воркеры, а так же
        /// подписываемся на событие о сохранении контекста
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            Projects = await Context.GetAllProjects();
            Workers = await Context.GetAllWorkers();
            Context.SavedChanges += Context_SavedChanges;
        }
        /// <summary>
        /// заполнение активного проекта
        /// </summary>
        /// <param name="projectId"></param>
        private void SelectOneProject(int projectId) => ActiveProject = Projects?.FirstOrDefault(x => x.Id == projectId)!;
        /// <summary>
        /// заполнение активного работника
        /// </summary>
        /// <param name="workerId"></param>
        private void SelectOneWorker(int workerId) => ActiveWorker = Workers?.FirstOrDefault(x => x.Id == workerId)!;
        /// <summary>
        /// Вызывается, когда контекст сохранил изменения
        /// После сохранения мы должны обновить всю информацию о проектах и воркерах, а так же
        /// с помощью StateHasChanged обновить UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Context_SavedChanges(object? sender, Microsoft.EntityFrameworkCore.SavedChangesEventArgs e)
        {
            Projects = await Context.GetAllProjects();
            Workers = await Context.GetAllWorkers();
            if (ActiveProject != null)
            {
                ActiveProject = Projects.FirstOrDefault(x => x.Id == ActiveProject.Id)!;
            }
            await InvokeAsync(StateHasChanged);
        }
        public void Dispose() => Context.SavedChanges -= Context_SavedChanges;
    }
}
