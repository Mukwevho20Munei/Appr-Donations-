using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Models
{
    public class goods
    {
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Select Category")]
        public string category { get; set; }
       
        public int NumberOfProds { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Donor { get; set; }
    }
}
