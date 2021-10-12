using System;

namespace WheatherApp
{
    public class App
    {
        private static string _unit = "metric";

        private LogDirectory _logs;
        private ConfigurationDirectory _confs;

        public App()
        {
            _logs = new LogDirectory();
            _confs = new ConfigurationDirectory();
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    if (!_confs.IsConfigurationExist())
                    {
                        while (true)
                        {
                            try
                            {
                                _confs.SetUpNewConfiguration();
                                break;
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            try
                            {
                                _confs.GetExistingConfiguration();
                                break;
                            }
                            catch { }
                        }
                    }
                    break;
                }
                catch{ }
            }
            while (true)
            {
                try
                {
                    string cityName = GetCityNameOrExit();

                    if (cityName == "q") break;

                    WheatherInfoSimple forecast;
                    if (_logs.IsWheatherLogFileExist(cityName))
                    {
                        forecast = _logs.GetDataFromLogFile(cityName);
                    }
                    else
                    {

                        forecast = Wheather.GetWheaterForecast(new DataBundle { City = cityName, Unit = _unit });

                        _logs.CreateLog(forecast, cityName);
                    }

                    forecast.DisplayInfo(_unit);
                }
                catch{ }
            }
            _logs.DeleteLogs();
        }

        public static void SetUpGlobalData(DataBundle data)
        {
            _unit = data.Unit;
        }

        public string GetCityNameOrExit()
        {
            Console.WriteLine("==========================");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("City name must be in English and grammatically correct!");
            Console.Write("Write the name of the city whose weather forecast you want to receive or enter 'q' to exit: ");
            Console.ResetColor();
            string cityName = Console.ReadLine();
            return cityName;
        }
    }
}
