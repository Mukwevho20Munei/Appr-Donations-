using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Models
{
    public class DistributeGoodstoDisaster
    {
        public int prodId { get; set; }

        public List<SelectListItem> DisasterTag { get; set; }

        public string Category { get; set; }

        public int NumberOfProds { get; set; }
    }
}
