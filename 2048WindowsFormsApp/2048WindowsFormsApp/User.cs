using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048WindowsFormsApp
{
    public class User
    {
        public string Name;
        public int Score = 0;        

        public User(string userName)
        {
            Name = userName;
        }
        // new feature changes
        public void AcceptUserScore(int bestScore)
        {
            Score = bestScore;
        }       
    }
}
