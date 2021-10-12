using System;

namespace WheatherApp
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid key try again!");
            Console.ResetColor();
        }
    }

    public class InvalidCityNameException : Exception
    {
        public InvalidCityNameException() : base()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid city name! Try again!");
            Console.ResetColor();
        }
    }

    public class InvalidConfFileNameException : Exception
    {
        public InvalidConfFileNameException() : base()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid configuration file name!");
            Console.ResetColor();
        }
    }
}
