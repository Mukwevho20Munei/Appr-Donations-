using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Models
{
    public class myDisasterInfoModel
    {
        public int id { get; set; }
        public string Heading { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
    
        public string Description { get; set; }
        public string Aid { get; set; }

        public int numberOfProd { get; set; }
        public string category { get; set; }
        public double DistributedAmount { get; set; }
    }
}
