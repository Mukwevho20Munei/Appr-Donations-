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
    public class moneyController : Controller
    {
        private IConfiguration myconfuguration;

        public moneyController(IConfiguration config)
        {
            myconfuguration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult cash()
        {
            return View();
        }
        [HttpPost]
        public IActionResult cash(money model)
        {
            string con = myconfuguration["ConnectionStrings:database"];
            SqlConnection sqlCon = new SqlConnection(con);
            sqlCon.Open();
            string query = "insert  into moneyTbl (date,amount , donor) values (@Date,@Amount,@donor)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            sqlCommand.Parameters.AddWithValue("@Date", model.Date);
            sqlCommand.Parameters.AddWithValue("@Amount", model.Amount);
            sqlCommand.Parameters.AddWithValue("@donor", model.Donor);
            sqlCommand.ExecuteNonQuery();
            ViewBag.Message = "Money has been captured succefully";
            return View();
        }
    }
}
