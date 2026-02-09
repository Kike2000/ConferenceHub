using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceHub.Domain.Entities
{
    public class Area
    {
        public int AreaId { get; set; }

        public Guid PublicId { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }
    }
}
