using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_PazTorresPraderio
{
    public static class BBDD
    {
        public static List<Jugador> jugadores = new List<Jugador>();

        public static void AddJugador(Jugador jugador)
        {
            jugadores.Add(jugador);
        }

    }
}
