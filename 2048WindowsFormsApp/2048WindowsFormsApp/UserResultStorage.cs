using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WindowsFormsApp
{
    public class UserResultStorage
    {
        static string path = @"usersResult.json";

        public static List<User> GetAll()
        {
            var users = new List<User>();

            if (FileProvider.Exist(path))
            {
                var value = FileProvider.GetValue(path);
                users = JsonConvert.DeserializeObject<List<User>>(value);
            }
            return users;
        }

        public static void Append(User user)
        {
            var users = GetAll();
            if (user.Score != 0)
            {
                users.Add(user);
                var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
                FileProvider.Replace(path, jsonData);
            }
        }

        public static void Update(User user)
        {
            var users = GetAll();

            if (users.Count != 0)
            {
                var lastIndex = users.Count() - 1;
                users.RemoveAt(lastIndex);
                Append(user);
            }
            else
            {
                Append(user);
            }
        }

    }
}
