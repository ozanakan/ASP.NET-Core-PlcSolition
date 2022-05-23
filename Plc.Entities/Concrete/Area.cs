using Plc.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Entities.Concrete
{
    public class Area : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual ICollection<WorkCenter> WorkCenters { get; set; }

    }
}
