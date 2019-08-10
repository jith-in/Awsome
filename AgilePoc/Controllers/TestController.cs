using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgilePoc.Controllers
{
    [Produces("application/json")]
    [Route("api/metrics")]
    public class TestController : Controller
    {
        [HttpGet("[action]")]
        public MetricsForecast GetWeatherForecast()
        {
            var weatherList = new List<Weather>();
            weatherList.Add(new Weather { Label = "New Delhi", stack= "a", Data = new int[] { 6, 19, 6, 21, 7, 15 } }); ; 
            weatherList.Add(new Weather { Label = "New Delhi", stack= "a", Data = new int[] { 16, 9, 6, 1, 8, 10 } });


         
            //weatherList.Add(new Weather { Label = "New York", Data = new int[] { -8, -6, -1, 2, -7, 6 } });
            //weatherList.Add(new Weather { Label = "Moscow", Data = new int[] { -4, 3, -5, -1, -6, -3 } });
            //weatherList.Add(new Weather { Label = "London", Data = new int[] { 6, 2, 4, 6, 7, 7 } });

            List<string> lineChartLabelsList = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                lineChartLabelsList.AddRange(new string[] { $"{(DayOfWeek)i} High", $"{(DayOfWeek)i} Low" });
            }
            return new MetricsForecast { WeatherList = weatherList, ChartLabels = lineChartLabelsList.ToArray() };
        }
        [HttpGet("scope/data")]
       
        public MetricsForecast GetScopeChange()
        {
            var weatherList = new List<Weather>();
            weatherList.Add(new Weather { Label = "SprintAcceted",stack="a", Data = new int[] { 6, 5, 9 } });
            weatherList.Add(new Weather { Label = "Scopechange", stack = "a", Data = new int[] { 3, 2, 4 } });
            List<string> lineChartLabelsList = new List<string>();

            lineChartLabelsList.Add("sprint1");
            lineChartLabelsList.Add("sprint2");
            lineChartLabelsList.Add("sprint3");

            return new MetricsForecast { WeatherList = weatherList, ChartLabels = lineChartLabelsList.ToArray() };
        }
        [HttpGet("successrate/data")]
        public MetricsForecast GetAcceptedCommitted()
        {
            var weatherList = new List<Weather>();
            weatherList.Add(new Weather { Label = "SprintDetails",  Data = new int[] { 6,5 ,9} }); 
            //weatherList.Add(new Weather { Label = "Sprint1", Data = new int[] { 16 } });


            List<string> lineChartLabelsList = new List<string>();

            //for (int i = 0; i < weatherList.Count; i++)
            //{
            //    lineChartLabelsList.Add($"{weatherList[i].Label }");
            //}

            lineChartLabelsList.Add("sprint1");
            lineChartLabelsList.Add("sprint2");
            lineChartLabelsList.Add("sprint3");

            return new MetricsForecast { WeatherList = weatherList, ChartLabels = lineChartLabelsList.ToArray() };
        }
        [HttpGet("priority")]
        public MetricsForecast GetPriority()
        {
            var weatherList = new List<Weather>();
            weatherList.Add(new Weather { Label = "Low", stack = "a", Data = new int[] { 6, 5, 9,8,2 } });
            weatherList.Add(new Weather { Label = "Lowest", stack = "a", Data = new int[] { 3, 2, 4,9,10 } });
            weatherList.Add(new Weather { Label = "High", stack = "a", Data = new int[] { 6, 5, 9,4,3 } });
            weatherList.Add(new Weather { Label = "Highest", stack = "a", Data = new int[] { 3, 2, 4,6,8 } });
            weatherList.Add(new Weather { Label = "Medium", stack = "a", Data = new int[] { 13, 4, 1, 5, 8 } });
            List<string> lineChartLabelsList = new List<string>();
            lineChartLabelsList.Add("Sprint1");
            lineChartLabelsList.Add("Sprint2");
            lineChartLabelsList.Add("Sprint3");
            lineChartLabelsList.Add("Sprint4");
            lineChartLabelsList.Add("Sprint5");
            return new MetricsForecast { WeatherList = weatherList, ChartLabels = lineChartLabelsList.ToArray() };
        }
        [HttpGet("velocity/trends")]
        public MetricsForecast GetVelocity()
        {
            var weatherList = new List<Weather>();
            weatherList.Add(new Weather { Label = "Velocity", stack = "a", Data = new int[] { 6,5,2,10 } }); ;
           


            List<string> lineChartLabelsList = new List<string>();
            lineChartLabelsList.Add("sprint1");
            lineChartLabelsList.Add("sprint2");
            lineChartLabelsList.Add("sprint3");
            //for (int i = 0; i < weatherList.Count; i++)
            //{
            //    lineChartLabelsList.Add($"{weatherList[i].Label }");
            //}
            return new MetricsForecast { WeatherList = weatherList, ChartLabels = lineChartLabelsList.ToArray() };
        }

        public class Weather
        {
            public int[] Data { get; set; }
            public string Label { get; set; }

            public string stack { get; set; }
        }

        public class MetricsForecast
        {
            public List<Weather> WeatherList { get; set; }
            public string[] ChartLabels { get; set; }
        }

        public class PriorityModel
        {
            public string SprintName { get; set; }
            public string ProjectName { get; set; }
            public string IssueType { get; set; }
            public string Priority { get; set; }
            public int PriorityCount { get; set; }
        }
        public class ScopeModel
        {
            public string SprintName { get; set; }
            public int AddedWork { get; set; }
        }
        public class SprintModel
        {
            public string Name { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public bool Closed { get; set; }
            public string ProjectName { get; set; }
        }
        public class StoryPointMappingModel
        {
            public string SprintName { get; set; }
            public int CommittedSp { get; set; }
            public int Acceptedsp { get; set; }
            public string ProjectName { get; set; }
        }
        public class SuccessRateModel
        {
            public string SprintName { get; set; }
            public double SuccessRate { get; set; }
        }
        public class VelocityTrendsModel
        {
            public string SprintName { get; set; }
            public double Velocity { get; set; }
        }
    }
}