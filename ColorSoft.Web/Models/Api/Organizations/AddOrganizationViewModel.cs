using System.ComponentModel.DataAnnotations;

namespace ColorSoft.Web.Models.Api.Organizations
{
    public class AddOrganizationViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "A name is required.")]
        public string Name { get; set; }
    }
}