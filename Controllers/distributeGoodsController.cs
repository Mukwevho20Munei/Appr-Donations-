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
    public class distributeGoodsController : Controller
    {
        private IConfiguration myconfuguration;

        public distributeGoodsController(IConfiguration config)
        {
            myconfuguration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult distributeProducts()
        {
            DistributeGoodstoDisaster model = new DistributeGoodstoDisaster();
            model.DisasterTag = tag();
            return View(model);
        }
        [HttpPost]
        public IActionResult distributeProducts(DistributeGoodstoDisaster model)
        {
            model.DisasterTag = tag();
            var selectTag = model.DisasterTag.Find(d => d.Value == model.prodId.ToString());
            string con = myconfuguration["ConnectionStrings:database"];
            SqlConnection sqlCon = new SqlConnection(con);
            if (selectTag != null)
            {
                selectTag.Selected = true;

                sqlCon.Open();
                string query = "update disasterTbl set ProdsCategory = @Category, distributedNumberOfProds = @numberOfProds where DisasterTag = @tag";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@Category", model.Category);
                sqlCommand.Parameters.AddWithValue("@numberOfProds", model.NumberOfProds);
                sqlCommand.Parameters.AddWithValue("@tag", selectTag.Text);

                ViewBag.Message = "Distributed Products to disaster Successfully";
                sqlCommand.ExecuteNonQuery();
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
