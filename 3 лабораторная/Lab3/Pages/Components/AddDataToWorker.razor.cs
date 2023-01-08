using Lab3.DataBase;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace Lab3.Pages.Components
{
    /// <summary>
    /// Заполнение работников. Схема та же, что и у остальных обновляторов
    /// </summary>
    public partial class AddDataToWorker
    {
        [Inject] MyDbContext Context { get; set; }
        private int Id { get; set; }
        private string FullName { get; set; } = string.Empty;
        private StringBuilder ErrorString { get; set; } = new();
        private async void CreateWorker()
        {
            if (!CheckToCorrect()) return;
            await Context.AddWorker(new Worker() { FullName = FullName });
        }
        private bool CheckToCorrect()
        {
            ErrorString.Clear();
            var ErrorCount = 0;
            if (string.IsNullOrWhiteSpace(FullName))
            {
                ErrorCount++;
                ErrorString.Append($"{ErrorCount})Имя не может быть пустым!");
            }
            return ErrorCount == 0;
        }
    }
}
