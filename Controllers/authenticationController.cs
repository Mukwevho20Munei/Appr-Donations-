using Appr_Munei.Models;
using Microsoft.AspNetCore.Http;
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
    public class authenticationController : Controller
    {

        private IConfiguration myconfuguration;

        public authenticationController(IConfiguration config)
        {
            myconfuguration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult signIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult signIn(login model)
        {
            string con = myconfuguration["ConnectionStrings:database"];
            SqlConnection sqlCon = new SqlConnection(con);
            sqlCon.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            string query = "select * from accounts where email = @email and password = @password";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            sqlCommand.Parameters.AddWithValue("@email", model.Email);
            sqlCommand.Parameters.AddWithValue("@password", model.Password);

            sqlDataAdapter.SelectCommand = sqlCommand;

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                HttpContext.Session.SetString("email", model.Email);
                ViewBag.Message =model.Email + " Welcome to our Disaster Avilliation";
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.Message = "Failed to  login re-enter your credentials";
            }
            return View();
        }
    }
}
