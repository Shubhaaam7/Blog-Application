using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.Models
{
    public class MonthWiseDashboard
    {
        
        public int Id { get; set; }
    
    public string MonthName { get; set; }
        public int MonthCount { get; set; }
    }
}
