using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class MessMember:IdentityUser
    {

        
        public string? Name { get; set; }
        public string? HostelName { get; set; }
        
        public int? Dues { get; set; }


    }

}
