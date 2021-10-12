/*
    This file defines several classes that represent a JSON object as a C # object.
*/
using System;
using System.Collections.Generic;

namespace WheatherApp
{
    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public sealed class WheatherInfo
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class WheatherInfoSimple
    {
        public string CityName { get;set; }
        public double Temp { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        public override string ToString()
        {
            return
                $"City: {CityName}\n" +
                $"Tempreture: {Temp}\n" +
                $"Tempreture(Min): {TempMin}\n" +
                $"Tempreture(Max): {TempMax}\n" +
                $"Pressure: {Pressure}\n" +
                $"Humidity: {Humidity}";
        }

        public void DisplayInfo(string unit)
        {
            Console.WriteLine("=========");
            if(unit == "metric")
            {
                Console.WriteLine($"City: {CityName}\n" +
                $"Tempreture: {Temp} °C\n" +
                $"Tempreture(Min): {TempMin} °C\n" +
                $"Tempreture(Max): {TempMax} °C\n" +
                $"Pressure: {Pressure} Pa\n" +
                $"Humidity: {Humidity} %\n");
            }
            else
            {
                Console.WriteLine($"City: {CityName}\n" +
                $"Tempreture: {(Temp*(9/5))+32} °F\n" +
                $"Tempreture(Min): {(TempMin * (9 / 5)) + 32} °F\n" +
                $"Tempreture(Max): {(TempMax * (9 / 5)) + 32} °F\n" +
                $"Pressure: {Pressure} Pa\n" +
                $"Humidity: {Humidity} %\n");
            }
            Console.WriteLine("==============");
        }

        public static implicit operator WheatherInfoSimple(WheatherInfo wi)
        {
            return new WheatherInfoSimple
            {
                CityName = wi.name,
                Temp = wi.main.temp,
                TempMin = wi.main.temp_min,
                TempMax = wi.main.temp_max,
                Pressure = wi.main.pressure,
                Humidity = wi.main.humidity
            };
        }

        public static implicit operator WheatherInfoSimple(string[] data)
        {
            WheatherInfoSimple result = new WheatherInfoSimple();
            result.CityName = data[0].Split(" ")[1];
            result.Temp = Convert.ToDouble(data[1].Split(" ")[1]);
            result.TempMin = Convert.ToDouble(data[2].Split(" ")[1]);
            result.TempMax = Convert.ToDouble(data[3].Split(" ")[1]);
            result.Pressure = Convert.ToInt32(data[4].Split(" ")[1]);
            result.Humidity = Convert.ToInt32(data[5].Split(" ")[1]);

            return result;
        }
    }
}
