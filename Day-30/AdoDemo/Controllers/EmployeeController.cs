using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; // modern ADO.NET client
using AdoDemo.Models;
using Microsoft.AspNetCore.Http; // for session
using System.Collections.Generic;

namespace AdoDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _config;

        public EmployeeController(IConfiguration config)
        {
            _config = config;

        }

        //get Employee/Index
        public IActionResult Index()
        {
            string connstr = _config.GetConnectionString("DefaultConnection");
            var employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string sql = "select Id,Name,Email from Employees";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var emp = new Employee
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
                                Email = reader.IsDBNull(2) ? "" : reader.GetString(2)
                            };
                            employees.Add(emp);
                        }

                    }
                    //connection closed
                }
            }

            HttpContext.Session.SetString("LastFetchTime", DateTime.Now.ToString("s"));

            return View(employees);
        }



        //Example of disconnect approach

        public IActionResult GridUsingDataAdaptor()
        {
            string connstr = _config.GetConnectionString("DefaultConnection");
            var dt = new System.Data.DataTable();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string sql = "select Id,Name,Email from Employees";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.Fill(dt);
                }
            }
            ViewBag.EmployeesTable = dt;
            HttpContext.Session.SetString("LastFetchTime", DateTime.Now.ToString("s"));
            return View("IndexUsingDataTable");
        }
    }
}