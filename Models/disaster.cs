using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Models
{
    public class disaster
    {
        public string DisasterTag { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string RequiredSupport { get; set; }
    }
}
