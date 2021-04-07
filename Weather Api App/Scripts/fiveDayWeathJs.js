
    //JS function to get dropdown containers
    function toggle_visibility(id) {
        var e = document.getElementById(id);
        if (e.style.display == 'block')
            e.style.display = 'none';
        else
            e.style.display = 'block';
    }

    // JS function to set values to suitable html ids
    function setValue(value) {
        //Container #1
        $('#name-0').html(value.CityName);
        $("#country-0").html(value.CountryName);
        $("#lat-0").html(value.Coords[0].lat);
        $("#lon-0").html(value.Coords[0].lon);
        $("#humidity-0").html(value.DataByDay[0].AvgHumidity);
        $("#tempfeelslike-0").html(value.DataByDay[0].AvgFeelsLike);
        $("#visibility-0").html(value.DataByDay[0].AvgVisibility);
        $("#wind-0").html(value.DataByDay[0].AvgWindSpeed);
        $("#temp-0").html(value.DataByDay[0].AvgTemp);
        $("#maxTemp-0").html(value.DataByDay[0].AvgMaxTemp);
        $("#minTemp-0").html(value.DataByDay[0].AvgMinTemp);
        $("#pressure-0").html(value.DataByDay[0].AvgPressure);
        $("#day-0").text('Current weather');
        //Container #2
        $('#name-1').html(value.CityName);
        $("#country-1").html(value.CountryName);
        $("#lat-1").html(value.Coords[0].lat);
        $("#lon-1").html(value.Coords[0].lon);
        $("#humidity-1").html(value.DataByDay[1].AvgHumidity);
        $("#tempfeelslike-1").html(value.DataByDay[1].AvgFeelsLike);
        $("#visibility-1").html(value.DataByDay[1].AvgVisibility);
        $("#wind-1").html(value.DataByDay[1].AvgWindSpeed);
        $("#temp-1").html(value.DataByDay[1].AvgTemp);
        $("#maxTemp-1").html(value.DataByDay[1].AvgMaxTemp);
        $("#minTemp-1").html(value.DataByDay[1].AvgMinTemp);
        $("#pressure-1").html(value.DataByDay[1].AvgPressure);
        $("#day-1").html(value.DataByDay[1].DayTime);
        //Container #3
        $('#name-2').html(value.CityName);
        $("#country-2").html(value.CountryName);
        $("#lat-2").html(value.Coords[0].lat);
        $("#lon-2").html(value.Coords[0].lon);
        $("#humidity-2").html(value.DataByDay[2].AvgHumidity);
        $("#tempfeelslike-2").html(value.DataByDay[2].AvgFeelsLike);
        $("#visibility-2").html(value.DataByDay[2].AvgVisibility);
        $("#wind-2").html(value.DataByDay[2].AvgWindSpeed);
        $("#temp-2").html(value.DataByDay[2].AvgTemp);
        $("#maxTemp-2").html(value.DataByDay[2].AvgMaxTemp);
        $("#minTemp-2").html(value.DataByDay[2].AvgMinTemp);
        $("#pressure-2").html(value.DataByDay[2].AvgPressure);
        $("#day-2").html(value.DataByDay[2].DayTime);
        //Container #4
        $('#name-3').html(value.CityName);
        $("#country-3").html(value.CountryName);
        $("#lat-3").html(value.Coords[0].lat);
        $("#lon-3").html(value.Coords[0].lon);
        $("#humidity-3").html(value.DataByDay[3].AvgHumidity);
        $("#tempfeelslike-3").html(value.DataByDay[3].AvgFeelsLike);
        $("#visibility-3").html(value.DataByDay[3].AvgVisibility);
        $("#wind-3").html(value.DataByDay[3].AvgWindSpeed);
        $("#temp-3").html(value.DataByDay[3].AvgTemp);
        $("#maxTemp-3").html(value.DataByDay[3].AvgMaxTemp);
        $("#minTemp-3").html(value.DataByDay[3].AvgMinTemp);
        $("#pressure-3").html(value.DataByDay[3].AvgPressure);
        $("#day-3").html(value.DataByDay[3].DayTime);
        //Container #5
        $('#name-4').html(value.CityName);
        $("#country-4").html(value.CountryName);
        $("#lat-4").html(value.Coords[0].lat);
        $("#lon-4").html(value.Coords[0].lon);
        $("#humidity-4").html(value.DataByDay[4].AvgHumidity);
        $("#tempfeelslike-4").html(value.DataByDay[4].AvgFeelsLike);
        $("#visibility-4").html(value.DataByDay[4].AvgVisibility);
        $("#wind-4").html(value.DataByDay[4].AvgWindSpeed);
        $("#temp-4").html(value.DataByDay[4].AvgTemp);
        $("#maxTemp-4").html(value.DataByDay[4].AvgMaxTemp);
        $("#minTemp-4").html(value.DataByDay[4].AvgMinTemp);
        $("#pressure-4").html(value.DataByDay[4].AvgPressure);
        $("#day-4").html(value.DataByDay[4].DayTime);

    }
