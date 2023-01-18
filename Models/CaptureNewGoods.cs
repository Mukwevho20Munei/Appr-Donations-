using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Models
{
    public class CaptureNewGoods
    {
        public DateTime Date { get; set; }

        public int NumberOfProds { get; set; }

        public string Category { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Donor { get; set; }
        public decimal AmountSpent { get; set; }
    }
}
