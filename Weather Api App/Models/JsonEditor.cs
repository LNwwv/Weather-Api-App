using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Serialization;

namespace Weather_Api_App.Models
{
    public class JsonEditor
    {
        private int _counter;
        private double _avgMinTemp;
        private double _avgMaxTemp;
        private double _avgTempFeelsLike;
        private double _avgTemp;
        private double _avgHumidity;
        private double _avgVisibility;
        private double _avgPressure;
        private double _avgWindSpeed;
        private SegregationModel _weatherDataToReturn = new SegregationModel();


        public object Deserializer(string content)
        {
            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<object>(content);
            return jsonContent;
        }

        /*
         * Method that is resposible for select weather data,
         * because WeatherApi gives us data
         * for every 3 next hours and we need to select it for each day
         */
        public SegregationModel SelectWeatherDetails(Rootobject mainJsonDataFromApi)
        {
            var presentDay = DateTime.Now.Day;

            AddStaticValuesToSegregationModel(mainJsonDataFromApi);

            //addind next days and divide it by counter to get avg weather data

            foreach (var item in mainJsonDataFromApi.list)
            {
                var dayInJsonData = Convert.ToDateTime(item.dt_txt);

                if (dayInJsonData.Day == presentDay)
                {
                    SumAvgValues(item);
                }
                // else if to catch 24:00/00:00
                else if (dayInJsonData.Day == presentDay + 1)
                {
                    SumAvgValues(item);
                    CalcutateAvgAndReturn(dayInJsonData);
                    SetZeroToClassObjects();
                    presentDay += 1;
                }
                else
                {
                    CalcutateAvgAndReturn(dayInJsonData);
                    SetZeroToClassObjects();
                    presentDay += 1;
                }
            }

            return _weatherDataToReturn;
        }


        // Method responsible for calculate avg
        private void CalcutateAvgAndReturn(DateTime date)
        {
            _weatherDataToReturn.DataByDay.Add(
                new Day()
                {
                    AvgFeelsLike = (_avgTempFeelsLike / _counter).ToString("##.00"),
                    AvgMaxTemp = (_avgMaxTemp / _counter).ToString("##.00"),
                    AvgMinTemp = (_avgMinTemp / _counter).ToString("##.00"),
                    AvgTemp = (_avgTemp / _counter).ToString("##.00"),
                    AvgHumidity = (_avgHumidity / _counter).ToString("##.00"),
                    AvgVisibility = (_avgVisibility / _counter).ToString("##.00"),
                    AvgPressure = (_avgPressure / _counter).ToString("##.00"),
                    AvgWindSpeed = (_avgWindSpeed / _counter).ToString("##.00"),
                    DayTime = Convert.ToDateTime(date).ToString("dddd dd MMMM",
                        CultureInfo.CreateSpecificCulture("en-US")),
                }
            );
        }

        /*
         *  SetZeroToClassObjects is method which set to 0
         *  every JsonEditor field that is needed to
         *  calculate an avg from json data 
         */

        private void SetZeroToClassObjects()
        {
            _counter = 0;
            _avgMinTemp = 0;
            _avgMaxTemp = 0;
            _avgTempFeelsLike = 0;
            _avgTemp = 0;
            _avgHumidity = 0;
            _avgVisibility = 0;
            _avgPressure = 0;
            _avgWindSpeed = 0;
        }

        /*
         *  SumAvgValues add sum of existing
         *  Avg field and data from next 3 hr
         */

        private void SumAvgValues(List item)
        {
            _counter++;
            _avgMinTemp += item.main.temp_min;
            _avgMaxTemp += item.main.temp_max;
            _avgTempFeelsLike += item.main.feels_like;
            _avgTemp += item.main.temp;
            _avgHumidity += item.main.humidity;
            _avgVisibility += item.visibility;
            _avgPressure += item.main.pressure;
            _avgWindSpeed += item.wind.speed;
        }

        /*
         * Static values are values which presents
         * weather data at the api weather call time
         */
        private void AddStaticValuesToSegregationModel(Rootobject value)
        {
            _weatherDataToReturn.CityName = value.city.name;
            _weatherDataToReturn.CountryName = value.city.country;
            _weatherDataToReturn.Coords = new List<Coord>
            {
                new Coord()
                {
                    lat = value.city.coord.lat,
                    lon = value.city.coord.lon,
                }
            };
            _weatherDataToReturn.DataByDay = new List<Day>
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
        }
    }
}