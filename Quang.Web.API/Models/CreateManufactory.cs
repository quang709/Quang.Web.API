using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quang.Web.API.Models
{
    public class CreateManufactory
 {
        [Display(Name ="Manufactoy Name")]
        [Required(ErrorMessage = "Manufactoy Name is required.")]
        public string Name { get; set; }
    }
}
