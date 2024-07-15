namespace BlogApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string First_Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Start_Date { get; set; } = string.Empty;
        public int Salary { get; set; }

        public string Senior_Management { get; set; } = string.Empty;

        public string Team { get; set; } = string.Empty;

    }
}
