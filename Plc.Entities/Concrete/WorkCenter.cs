using Plc.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Entities.Concrete
{
    public class WorkCenter : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Area boş geçilmemeli.")]
        public int AreaId { get; set; }
        [Required(ErrorMessage = "WorkCenter adı boş geçilmemeli.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilmemeli.")]
        public string Description { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Plc> Plcs { get; set; }
    }
}
