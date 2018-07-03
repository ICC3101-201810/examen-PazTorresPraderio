using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_PazTorresPraderio
{
    public class Jugador
    {
        string name;
        int score;
        public Jugador(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public string GetName()
        {
            return this.name;
        }
        public int GetScore()
        {
            return this.score;
        }
    }
}
