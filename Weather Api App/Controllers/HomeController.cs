using System;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Weather_Api_App.Models;

namespace Weather_Api_App.Controllers
{
    public class HomeController : Controller
    {
        private string _apiKey = ConfigurationManager.AppSettings["ApiKey"];

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Weather()
        {
            return View();
        }

        public ActionResult DetailsWeather()
        {
            return View();
        }

        public ActionResult FiveDaysWeather()
        {
            return View();
        }

        public ActionResult WeatherInCity()
        {
            return View();
        }


        public JsonResult GetWeather(string city)
        {
            var weath = new JsonEditor();

            var url = "https://api.openweathermap.org/data/2.5/weather?q=" + city +
                      "&APPID=" + _apiKey + "&units=metric";

            var client = new WebClient();

             //Try catch for invalid City name which not equals with any city
            try
            {
                var content = client.DownloadString(url);
                var returnValue = Json(weath.Deserializer(content), JsonRequestBehavior.AllowGet);
                return returnValue;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string GetWeatherForFiveDays(string city)
        {
            //GET JSON FILE AND CONVERT IT
            var serial = new JsonEditor();

            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&APPID={_apiKey}&units=metric";

            var client = new WebClient();


            //Try catch for invalid City name which not equals with any city
            try
            {
                var content = client.DownloadString(url);

                Rootobject weatherJsonData = new JavaScriptSerializer().Deserialize<Rootobject>(content);

                //Get selected values and return it to page
                var selectedWeatherData = new JavaScriptSerializer()
                    .Serialize(serial.SelectWeatherDetails(weatherJsonData));

                return selectedWeatherData;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}