using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WindowsFormsApp
{
    public class FileProvider
    {
        public static void Replace(string path, string value)
        {
            var writer = new StreamWriter(path, false);
            writer.Write(value);
            writer.Close();
        }

        public static string GetValue(string path)
        {
            var reader = new StreamReader(path, Encoding.UTF8);
            var value = reader.ReadToEnd();
            reader.Close();
            return value;
        }

        public static bool Exist(string path)
        {
            return File.Exists(path);
        }       
    }
}
