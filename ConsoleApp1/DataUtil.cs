using System;

namespace WheatherApp
{
    class DataUtil
    { 
        private const string API_KEY = "02f655a885986f9e57e7c8da5cb1732e";

        public const string LOG_PATH = @"D:\WheaterApp\ConsoleApp1\ConsoleApp1\forecast_logs";
        public const string SETTINGS_PATH = @"D:\WheaterApp\ConsoleApp1\ConsoleApp1\settings";

        public static string CreateUrl(string cityName,string unit)
        {
            return $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={API_KEY}&units={unit}";
        }
    }
}
