using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Models
{
    public class DistributeMoneyToDisaster
    {
        public int moneyId { get; set; }

        public List<SelectListItem> DisasterTag { get; set; }

        public double Amount { get; set; }
    }
}
