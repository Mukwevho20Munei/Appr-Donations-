using Appr_Munei.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Controllers
{
    public class newGoodsController : Controller
    {
        private IConfiguration myconfuguration;

        public newGoodsController(IConfiguration config)
        {
            myconfuguration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult newProducts()
        {
            return View();
        }
        [HttpPost]
        public IActionResult newProducts(CaptureNewGoods model)
        {

            string con = myconfuguration["ConnectionStrings:database"];
            SqlConnection sqlCon = new SqlConnection(con);
            sqlCon.Open();
            string query = "insert  into goodsTbl (date,category , numOfProducts, description, donor) values (@Date,@category, @numOfprod, @des,@donor)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            sqlCommand.Parameters.AddWithValue("@Date", model.Date);
            sqlCommand.Parameters.AddWithValue("@Category", model.Category);
            sqlCommand.Parameters.AddWithValue("@numOfprod", model.NumberOfProds);
            sqlCommand.Parameters.AddWithValue("@des", model.Description);
            sqlCommand.Parameters.AddWithValue("@donor", model.Donor);
            sqlCommand.ExecuteNonQuery();
            ViewBag.Message = "New Goods has been added succefully";
            return View();
        }
    }
}
