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


            var content = client.DownloadString(url);


            var returnValue = Json(weath.Deserializer(content), JsonRequestBehavior.AllowGet);

            return returnValue;
        }

        public string GetWeatherForFiveDays(string city)
        {
            //GET JSON FILE AND CONVERT IT
            var serial = new JsonEditor();
            var url = string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&APPID={1}&units=metric", city, _apiKey);
            var client = new WebClient();
            var content = client.DownloadString(url);

            Rootobject weatherJsonData = new JavaScriptSerializer().Deserialize<Rootobject>(content);

            //Get selected values and return it to page
            var selectedWeatherData = new JavaScriptSerializer()
                .Serialize(serial.SelectWeatherDetails(weatherJsonData));

            return selectedWeatherData;
        }
    }
}