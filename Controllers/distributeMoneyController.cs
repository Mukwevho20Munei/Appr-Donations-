using Appr_Munei.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Controllers
{
    public class distributeMoneyController : Controller
    {
        private IConfiguration myconfuguration;

        public distributeMoneyController(IConfiguration config)
        {
            myconfuguration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult distributeMoney()
        {
            DistributeMoneyToDisaster model = new DistributeMoneyToDisaster();
            model.DisasterTag = tag();
            return View(model);
        }
        [HttpPost]
        public IActionResult distributeMoney(DistributeMoneyToDisaster model)
        {
            model.DisasterTag = tag();
            var selectTag = model.DisasterTag.Find(t => t.Value == model.moneyId.ToString());

            if (selectTag != null)
            {
                selectTag.Selected = true;
                string con = myconfuguration["ConnectionStrings:database"];
                SqlConnection sqlCon = new SqlConnection(con);
                sqlCon.Open();
                string moneyQuery = "update disasterTbl set DistributedAmount = @Dmoney where DisasterTag = @tag";
                SqlCommand sql = new SqlCommand(moneyQuery, sqlCon);
                sql.Parameters.AddWithValue("@tag", selectTag.Text);
                sql.Parameters.AddWithValue("@Dmoney", model.Amount);
                ViewBag.Message = "Distributed money to disaster Successfully";
                sql.ExecuteNonQuery();

            }
            return View(model);
        }

        public List<SelectListItem> tag()
        {
            List<SelectListItem> disaster = new List<SelectListItem>();
            string con = myconfuguration["ConnectionStrings:database"];
            SqlConnection sqlCon = new SqlConnection(con);
            sqlCon.Open();
            string tagQuery = "select DisasterTag, id from disasterTbl";
            SqlCommand sqlCommand = new SqlCommand(tagQuery, sqlCon);
             
             using (SqlDataReader Reader = sqlCommand.ExecuteReader())
                {
               while (Reader.Read())
                        {
                            disaster.Add(new SelectListItem
                            {
                                Text = Reader["DisasterTag"].ToString(),
                                Value = Reader["id"].ToString()
                            });
                        }
                    }
            return disaster;
        }
    }
}
