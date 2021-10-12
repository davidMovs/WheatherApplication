using System;
using System.Text.Json;
using System.Net;

namespace WheatherApp
{
    class Wheather
    {
        public static WheatherInfoSimple GetWheaterForecast(DataBundle data)
        {

            try
            {
                var client = new WebClient();
                var content = client.DownloadString(DataUtil.CreateUrl(data.City, data.Unit));
                WheatherInfoSimple root = JsonSerializer.Deserialize<WheatherInfo>(content);
                return root;
            }
            catch
            {
                throw new InvalidCityNameException();
            }
        }
    }
}
