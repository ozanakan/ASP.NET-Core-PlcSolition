using Plc.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Entities.Concrete
{
    public class Plc : IEntity
    {
        public int Id { get; set; }
        public int WorkCenterId { get; set; }
        public string Name { get; set; }
        public int Ip { get; set; }
        public int Slot { get; set; }
        public int ConnType { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
        public virtual ICollection<PlcTag> PlcTags { get; set; }
    }
}
