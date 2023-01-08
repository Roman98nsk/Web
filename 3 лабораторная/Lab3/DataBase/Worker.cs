using System.ComponentModel.DataAnnotations;

namespace Lab3.DataBase
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? TaskId { get; set; }
        public Objective? Task { get; set; }
    }
}
