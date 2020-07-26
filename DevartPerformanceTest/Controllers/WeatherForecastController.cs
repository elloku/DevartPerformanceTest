using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevartPerformanceTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public void Query()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DevartExecute devart = new DevartExecute();
            devart.Query();
            sw.Stop();
            Console.WriteLine($"查询耗时:{sw.ElapsedMilliseconds}");
        }

        /// <summary>
        /// 查询单个值(OK)
        /// </summary>
        [HttpGet("executeScalar")]
        public void ExecuteScalar()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DevartExecute devart = new DevartExecute();
            devart.ExecuteScalar();
            sw.Stop();
            Console.WriteLine($"查询耗时:{sw.ElapsedMilliseconds}");
        }
    }
}
