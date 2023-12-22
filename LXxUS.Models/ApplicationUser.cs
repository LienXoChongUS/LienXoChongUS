using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LXxUS.Models
{

	public class ApplicationUser:IdentityUser {
		
		[Required]
	    public string Name { get; set; }
   
        public string StreetAddress { get; set; }
      
        public string City { get; set; }

        public string Phone_Number { get; set; }
    }
}
