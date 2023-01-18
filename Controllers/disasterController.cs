using Appr_Munei.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Controllers
{
    public class disasterController : Controller
    {
        private IConfiguration myconfuguration;

        public disasterController(IConfiguration config)
        {
            myconfuguration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult disasterInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult disasterInfo(disaster model)
        {
            string con = myconfuguration["ConnectionStrings:database"];
            SqlConnection sqlCon = new SqlConnection(con);
            sqlCon.Open();
            string query = "insert  into disasterTbl (DisasterTag,startDate, endDate, locations, description, aid) values (@DisasterTag,@sDate,@Edate, @loc, @des,@aid)";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            sqlCommand.Parameters.AddWithValue("@DisasterTag", model.DisasterTag);
            sqlCommand.Parameters.AddWithValue("@sDate", model.StartDate);
            sqlCommand.Parameters.AddWithValue("@EDate", model.EndDate);
            sqlCommand.Parameters.AddWithValue("@loc", model.Location);
            sqlCommand.Parameters.AddWithValue("@des", model.Description);
            sqlCommand.Parameters.AddWithValue("@aid", model.RequiredSupport);
            sqlCommand.ExecuteNonQuery();
            ViewBag.Message = "Disaster has been created succefully";
            return View();
        }
    }
}
