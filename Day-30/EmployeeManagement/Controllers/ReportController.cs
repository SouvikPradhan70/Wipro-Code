using EmployeeManagement.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class ReportController : Controller
    {
        //Only managers can access this action
        [AuthorizeRole("Manager")]
        public IActionResult Index()
        {
            return Content("Welcome manager .. This data is Very confidential!!");
        }


        //Normal action without restiction
        public IActionResult PublicReport()
        {
            return Content("Any one can see this result!!");
        }  
    }
}
