using Lab3.DataBase;
using Microsoft.AspNetCore.Components;

namespace Lab3.Pages.Components
{
    /// <summary>
    /// Схема показа как и у воркеров
    /// </summary>
    public partial class ViewProjectData
    {
        [Parameter] public List<Project>? Projects { get; set; }
        [Parameter] public EventCallback<Project> OnProjectClick { get; set; }
        [Parameter] public EventCallback<Project> DeleteProject { get; set; }
    }
}
