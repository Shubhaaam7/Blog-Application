using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.Models
{
    public class Blog
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }
        public string? AutherName { get; set; }
        public string? Contents { get; set; }
        public DateTime PublicationDate { get; set; }
        
        public string? CreatedBy { get; set; }
       
        public string? UpdatedBy { get; set; }
  
        public DateTime CreatedDate { get; set; }
   
        public DateTime UpdatedDate { get; set; }

        public bool Isdeleted { get; set; }
    }
}
