using Plc.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plc.Entities.Concrete
{
    public class PlcTag : IEntity
    {
        public int Id { get; set; }
        public int PlcId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DbNumber { get; set; }
        public int Address { get; set; }
        public int DataType { get; set; }
        public virtual Plc Plc { get; set; }
    }
}
