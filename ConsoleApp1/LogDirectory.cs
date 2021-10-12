using System;
using System.IO;
using System.Linq;

namespace WheatherApp
{
    public class LogDirectory
    {
        public const string LOG_PATH = DataUtil.LOG_PATH;
        public string[] logFiles;
        public DirectoryInfo logDir = new DirectoryInfo(LOG_PATH);

        public LogDirectory() => logFiles = Directory.GetFiles(LOG_PATH);

        public void Update() => logFiles = Directory.GetFiles(LOG_PATH);

        public bool IsWheatherLogFileExist(string logFileName)
        {
            string[] test = logFiles.Select(name => Path.GetFileNameWithoutExtension(name)).ToArray();

            return Array.IndexOf(test, logFileName) > -1 ? true : false;
        }

        private string CreateWheatherLogFile(string cityName)
        {
            string path = $@"{LOG_PATH}\{cityName}.txt";
            File.Create(path).Close();
            Update();
            return path;
        }

        private void SetDataToLogFile(WheatherInfoSimple wi, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(wi);
            }
        }

        public void CreateLog(WheatherInfoSimple wi,string name)
        {
            SetDataToLogFile(wi, CreateWheatherLogFile(name));
        }

        public WheatherInfoSimple GetDataFromLogFile(string fileName)
        {
            string[] data = new string[6];
            using (StreamReader sr = new StreamReader($@"{LOG_PATH}\{fileName}.txt"))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    data[i] = line;
                    i++;
                }
            }

            WheatherInfoSimple result = data;
            return result;
        }

        public void DeleteLogs()
        {
            foreach(FileInfo file in logDir.EnumerateFiles())
            {
                file.Delete();
            }
        }
    }
}
