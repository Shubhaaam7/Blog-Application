using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be blank")]
        public string? Title { get; set; }

        [Required(ErrorMessage = " Auther Name cannot be blank")]
        public string? AutherName { get; set; }

        [Required(ErrorMessage = "Contents cannot be blank")]
        public string? Contents { get; set; }

        [Required(ErrorMessage = "Publication Date cannot be blank")]
        public DateTime PublicationDate { get; set; }
        
        public string? CreatedBy { get; set; }
       
        public string? UpdatedBy { get; set; }
  
        public DateTime CreatedDate { get; set; }
   
        public DateTime UpdatedDate { get; set; }

        public bool Isdeleted { get; set; }
    }
}
