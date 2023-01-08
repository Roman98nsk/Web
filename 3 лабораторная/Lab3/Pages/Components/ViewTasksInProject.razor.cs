using Lab3.DataBase;
using Microsoft.AspNetCore.Components;

namespace Lab3.Pages.Components
{
    /// <summary>
    /// Схема показа как и у воркеров
    /// </summary>
    public partial class ViewTasksInProject
    {
        [Parameter] public Project? ActiveProject { get; set; }
        [Parameter] public EventCallback<Objective> DeleteTask { get; set; }
    }
}
