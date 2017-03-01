using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace University
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>{
                List<Department> AllDepartments = Department.GetAll();
                return View["index.cshtml", AllDepartments];
            };
        }
    }
}
