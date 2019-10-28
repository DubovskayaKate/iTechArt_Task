using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP_App.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        public Result Index(string name )
        {
            return new Result( name,"ETR");
        }

        public class Result
        {
            public string Name;
            public string Surname;

            public Result(string name, string surname)
            {
                Name = name;
                Surname = surname;
            }
        }
    }
}