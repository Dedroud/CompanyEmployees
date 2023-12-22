using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ComnataForCreationDto
    {
        public string Name { get; set; }
        public IEnumerable<HumanForCreationDto> Human { get; set; }

    }
}
