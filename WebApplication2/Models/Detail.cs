using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Detail 
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string MemberId { get; set; }

        [ForeignKey("MemberId")]
        [ValidateNever]
        public MessMember MessMember { get; set; }

        public DateTime Date { get; set; }
        
        


    }
}
