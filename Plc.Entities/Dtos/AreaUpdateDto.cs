using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Entities.Dtos
{
    public class AreaUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Area Adi")]
        [Required(ErrorMessage = "Area adı boş geçilmemeli.")]
        [MaxLength(70, ErrorMessage = "Area adı 70 karakterden fazla olamaz.")]
        public string Name { get; set; }
    }
}
