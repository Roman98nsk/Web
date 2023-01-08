using Lab3.DataBase;
using Microsoft.AspNetCore.Components;

namespace Lab3.Pages.Components
{
    /// <summary>
    /// Тупо показ работяг, которые передаются, в параметрах + есть 2 EventCallback, они передают информацию "наверх"
    /// в index.razor, где мы это обрабатываем
    /// </summary>
    public partial class ViewAllWorkers
    {
        [Parameter] public List<Worker>? Workers { get; set; }
        [Parameter] public EventCallback<Worker> OnWorkerClick { get; set; }
        [Parameter] public EventCallback<Worker> DeleteWorker { get; set; }
    }
}
