using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactList_SimpleWebApp.Models
{
    public class Contact
    {
        // TODO: Error messages
        [StringLength(60, MinimumLength = 3)][Required]public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]public string? Surname { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")][Key] public string Email { get; set; }
        [Required]public string Password { get; set; }
        [ForeignKey("Categories")]public string Category { get; set; }
        
        [RegularExpression(@"([0]{1}[6]{1}[-\s]*([1-9]{1}[\s]*){8})|([0]{1}[1-9]{1}[0-9]{1}[0-9]{1}[-\s]*([1-9]{1}[\s]*){6})|([0]{1}[1-9]{1}[0-9]{1}[-\s]*([1-9]{1}[\s]*){7})")]
        public string? Phone { get; set; }
        [Display(Name = "Birth Date")][DataType(DataType.Date)] public DateTime? BirthDate { get; set; }
    

    }
}
