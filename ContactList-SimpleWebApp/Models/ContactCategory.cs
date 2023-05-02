using System.ComponentModel.DataAnnotations;

namespace ContactList_SimpleWebApp.Models
{
    public class ContactCategory
    {
        [Key] public string Category { get; set; }

        //public virtual ContactSubCategory SubCategory { get; set; } 
    }
}
