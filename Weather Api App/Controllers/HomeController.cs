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
        private JsonEditor jsonEditor = new JsonEditor();
        private WebClient client = new WebClient();

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
            var url = "https://api.openweathermap.org/data/2.5/weather?q=" + city +
                      "&APPID=" + _apiKey + "&units=metric";

             //Try catch for invalid City name which not equals with any city
            try
            {
                var content = client.DownloadString(url);
                var returnValue = Json(jsonEditor.Deserializer(content), JsonRequestBehavior.AllowGet);
                return returnValue;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetWeatherForFiveDays(string city)
        {
            //GET JSON FILE AND CONVERT IT

            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&APPID={_apiKey}&units=metric";

            //Try catch for invalid City name which not equals with any city
            try
            {
                var content = client.DownloadString(url);

                Rootobject weatherJsonData = new JavaScriptSerializer().Deserialize<Rootobject>(content);

                //Get selected values and return it to page
                var selectedWeatherData = new JavaScriptSerializer()
                    .Serialize(jsonEditor.SelectWeatherDetails(weatherJsonData));

                return selectedWeatherData;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}