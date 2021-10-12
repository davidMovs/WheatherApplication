using System;
using System.IO;
using System.Collections;

namespace WheatherApp
{
    public class ConfigurationDirectory
    {
        private string _path = DataUtil.SETTINGS_PATH;

        public string GetConfigurationFileName()
        {
            Console.WriteLine("------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter your configuration file name: ");
            Console.ResetColor();
            string name = Console.ReadLine();

            Console.WriteLine("=============");
            return name;
        }

        public void SetUpNewConfiguration()
        {
            Console.WriteLine("##########");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Let's start setting up!");
            Console.Write("Please write the city where you live: ");
            Console.ResetColor();

            string cityName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nPlease write the unit you want use to[m-metric i-imperial]: ");
            Console.ResetColor();

            string input = Console.ReadLine();
            string unit;

            if (input == "m") unit = "metric";
            else if (input == "i") unit = "imperial";
            else throw new InvalidInputException();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nDo you want to save your configuration[y/n]: ");
            Console.ResetColor();

            string answer = Console.ReadLine();

            if (answer == "y")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nEnter the name of configuration file: ");
                Console.ResetColor();

                string name = Console.ReadLine();
                CreateConfiguration(new DataBundle { City = cityName, Unit = unit }, name);
            }
            else if(answer == "n") { }
            else
            {
                throw new InvalidInputException();
            }


            App.SetUpGlobalData(new DataBundle { Unit = unit });

            Console.WriteLine("###############");
        }

        public void GetExistingConfiguration()
        {
            string fileName = GetConfigurationFileName();
            DataBundle data = GetConfigurationData(fileName);
            App.SetUpGlobalData(data);
        }

        public bool IsConfigurationExist()
        {
            Console.WriteLine("------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Wheather Forecast Application");
            Console.Write("Do you have configuration file?[y/n]: ");
            Console.ResetColor();
            string answer = Console.ReadLine();
            if (answer == "y") return true;
            else if (answer == "n") return false;
            else throw new InvalidInputException();
        }

        private static string CreateConfigurationFile(string fileName)
        {
            string path = $@"{DataUtil.SETTINGS_PATH}\{fileName}.txt";

            File.Create(path)
                .Close();

            return path;
        }

        private static void SaveConfigurationFile(DataBundle bundle, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(bundle.City);
                sw.WriteLine(bundle.Unit);
            }
        }

        public static void CreateConfiguration(DataBundle data, string fileName)
        {
            App.SetUpGlobalData(data);
            SaveConfigurationFile(data, CreateConfigurationFile(fileName));
        }

        public static DataBundle GetConfigurationData(string fileName)
        {
            try
            {
                ArrayList data = new ArrayList(2);
                using (StreamReader sr = new StreamReader($@"{DataUtil.SETTINGS_PATH}\{fileName}.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                }

                return new DataBundle { City = (string)data[0], Unit = (string)data[1] };
            }
            catch (IOException)
            {
                throw new InvalidConfFileNameException();
            }
        }
    }
}
