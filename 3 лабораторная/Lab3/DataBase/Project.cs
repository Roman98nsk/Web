using System.ComponentModel.DataAnnotations;

namespace Lab3.DataBase
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string NameProject { get; set; } = string.Empty;
        public string NameCustomerCompany { get; set; } = string.Empty;
        public string NamePerformerCompany { get; set; } = string.Empty;
        public string FullNameExecutor { get; set; } = string.Empty;
        public string FullNameSupervisor { get; set; } = string.Empty;
        public DateTime TheDateOfTheBeginning { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Priority { get; set; }
        public List<Objective> Tasks { get; set; }
    }
}
