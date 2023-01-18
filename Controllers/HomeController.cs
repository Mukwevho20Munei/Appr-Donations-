using Appr_Munei.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Appr_Munei.Controllers
{
    public class HomeController : Controller
    {
        List<myDisasterInfoModel> myDisasters = new List<myDisasterInfoModel>();
        private readonly ILogger<HomeController> _logger;
        private IConfiguration myconfuguration;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            myconfuguration = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Information()
        {
            disasterCredits();
            return View(myDisasters);
        }
        private void disasterCredits()
        {
            if (myDisasters.Count > 0)
            {
                myDisasters.Clear();
            }
           
                string con = myconfuguration["ConnectionStrings:database"];
                SqlConnection sqlCon = new SqlConnection(con);
                sqlCon.Open();
                string sqlquery = "Select top (1000) [id],[DisasterTag],[startDate],[endDate],[locations],[description],[aid],[distributedNumberOfProds],[ProdsCategory],[DistributedAmount] from disasterTbl";
                SqlCommand command = new SqlCommand(sqlquery, sqlCon);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    myDisasters.Add(new myDisasterInfoModel()
                    {
                        id = Convert.ToInt32(read["id"].ToString()),
                        Heading = read["DisasterTag"].ToString(),
                        StartDate = Convert.ToDateTime(read["startDate"].ToString()),
                        EndDate = Convert.ToDateTime(read["endDate"].ToString()),
                        Location = read["locations"].ToString(),
                        Description = read["description"].ToString(),
                        Aid = read["aid"].ToString(),
                        numberOfProd = Convert.ToInt32(read["distributedNumberOfProds"].ToString()),
                        category = read["ProdsCategory"].ToString(),
                        DistributedAmount = Convert.ToDouble(read["DistributedAmount"].ToString())



                    });

                }



        }

        public IActionResult success()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
