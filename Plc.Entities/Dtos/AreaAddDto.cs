using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Entities.Dtos
{
   public class AreaAddDto
    {
        [DisplayName("Area Name")]
        [Required(ErrorMessage = "Area adı boş geçilmemeli.")]
        [MaxLength(70, ErrorMessage = "Area adı 70 karakterden fazla olamaz.")]
        public string Name { get; set; }
    }
}
