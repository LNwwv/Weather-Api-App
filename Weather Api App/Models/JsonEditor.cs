using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using Weather_Api_App.Controllers;

namespace Weather_Api_App.Models
{
    public class JsonEditor
    {
        public object Deserializer(string content)
        {
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<object>(content);
            return jsonContent;
        }

        public object SelectValue(Rootobject value)
        {
            var currentDateTime = DateTime.Now.Day;
            var weatherDataToReturn = new SegregationModel();
            weatherDataToReturn = AddStaticValuesToSegregationModel(value);

            //helper parameters
            var counter = 0;
            float avgMinTemp = 0;
            float avgMaxTemp = 0;
            float avgTempFeelsLike = 0;
            float avgTemp = 0;
            float avgHumidity = 0;
            float avgVisibility = 0;
            float avgPressure = 0;
            float avgWindSpeed = 0;

            //addind next days and divide it by counter to get avg weather data
            foreach (var item in value.list)
            {
                if (Convert.ToDateTime(item.dt_txt).Day == currentDateTime)
                {
                    counter++;
                    avgMinTemp += item.main.temp_min;
                    avgMaxTemp += item.main.temp_max;
                    avgTempFeelsLike += item.main.feels_like;
                    avgTemp += item.main.temp;
                    avgHumidity += item.main.humidity;
                    avgVisibility += item.visibility;
                    avgPressure += item.main.pressure;
                    avgWindSpeed += item.wind.speed;
                }
                // else if to catch 24:00/00:00
                else if (Convert.ToDateTime(item.dt_txt).Day == currentDateTime+1)
                {
                    counter++;
                    avgMinTemp += item.main.temp_min;
                    avgMaxTemp += item.main.temp_max;
                    avgTempFeelsLike += item.main.feels_like;
                    avgTemp += item.main.temp;
                    avgHumidity += item.main.humidity;
                    avgVisibility += item.visibility;
                    avgPressure += item.main.pressure;
                    avgWindSpeed += item.wind.speed;

                    weatherDataToReturn.DataByDay.Add(
                        new Day()
                        {
                            AvgFeelsLike = (avgTempFeelsLike / counter).ToString("0.00"),
                            AvgMaxTemp = (avgMaxTemp / counter).ToString("0.00"),
                            AvgMinTemp = (avgMinTemp / counter).ToString("0.00"),
                            AvgTemp = (avgTemp / counter).ToString("0.00"),
                            AvgHumidity = (avgHumidity / counter).ToString("0.00"),
                            AvgVisibility = (avgVisibility / counter).ToString("0.00"),
                            AvgPressure = (avgPressure / counter).ToString("0.00"),
                            AvgWindSpeed = (avgWindSpeed / counter).ToString("0.00"),
                            DayTime = Convert.ToDateTime(item.dt_txt).ToString("dddd dd MMMM",
                                CultureInfo.CreateSpecificCulture("en-US")),

                        }
                    );
                    counter = 0;
                    avgMinTemp = 0;
                    avgMaxTemp = 0;
                    avgTempFeelsLike = 0;
                    avgTemp = 0;
                    avgHumidity = 0;
                    avgVisibility = 0;
                    avgPressure = 0;
                    avgWindSpeed = 0;
                    currentDateTime += 1;
                }
                else
                {
                    weatherDataToReturn.DataByDay.Add(
                        new Day()
                        {
                            AvgFeelsLike = (avgTempFeelsLike / counter).ToString("0.00"),
                            AvgMaxTemp = (avgMaxTemp / counter).ToString("0.00"),
                            AvgMinTemp = (avgMinTemp / counter).ToString("0.00"),
                            AvgTemp = (avgTemp / counter).ToString("0.00"),
                            AvgHumidity = (avgHumidity / counter).ToString("0.00"),
                            AvgVisibility = (avgVisibility / counter).ToString("0.00"),
                            AvgPressure = (avgPressure / counter).ToString("0.00"),
                            AvgWindSpeed = (avgWindSpeed / counter).ToString("0.00"),
                            DayTime = Convert.ToDateTime(item.dt_txt).ToString("dddd dd MMMM",
                                CultureInfo.CreateSpecificCulture("en-US")),
                        }
                    );
                    counter = 0;
                    avgMinTemp = 0;
                    avgMaxTemp = 0;
                    avgTempFeelsLike = 0;
                    avgTemp = 0;
                    avgHumidity = 0;
                    avgVisibility = 0;
                    avgPressure = 0;
                    avgWindSpeed = 0;
                    currentDateTime += 1;
                }
            }

            return weatherDataToReturn;
        }
        /*
         * static values are values which presents
         * weather data at the api weather call time
         */
        private SegregationModel AddStaticValuesToSegregationModel(Rootobject value)
        {
            var weatherDataToReturn = new SegregationModel();
            weatherDataToReturn.CityName = value.city.name;
            weatherDataToReturn.CountryName = value.city.country;
            weatherDataToReturn.Coords = new List<Coord>
            {
                new Coord()
                {
                    lat = value.city.coord.lat,
                    lon = value.city.coord.lon,
                }
            };
            weatherDataToReturn.DataByDay = new List<Day>
            {

                new Day()
                {
                    AvgFeelsLike = (value.list[0].main.feels_like).ToString("0.00"),
                    AvgMinTemp = (value.list[0].main.temp_min).ToString("0.00"),
                    AvgTemp = (value.list[0].main.temp).ToString("0.00"),
                    AvgMaxTemp = (value.list[0].main.temp_max).ToString("0.00"),
                    AvgHumidity = (value.list[0].main.humidity).ToString("0.00"),
                    AvgPressure = (value.list[0].main.pressure).ToString("0.00"),
                    AvgVisibility = (value.list[0].visibility).ToString("0.00"),
                    AvgWindSpeed = (value.list[0].wind.speed).ToString("0.00"),
                    DayTime = Convert.ToDateTime(value.list[0].dt_txt).ToString("dddd dd MMMM",
                        CultureInfo.CreateSpecificCulture("en-US")),
                }
            };
            return weatherDataToReturn;
        }
    }
}