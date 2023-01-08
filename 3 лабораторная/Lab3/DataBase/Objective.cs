using System.ComponentModel.DataAnnotations;

namespace Lab3.DataBase
{
    /// <summary>
    /// Task
    /// </summary>
    public class Objective
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public Project Project { get; set; }
        public Worker? Worker { get; set; }
        public override string ToString()
        {
            return $"Id = {Id} Name ={Name}, Status = {Status}";
        }
    }
}
