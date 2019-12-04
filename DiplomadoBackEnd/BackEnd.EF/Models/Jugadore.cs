using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.EF.Models
{
    public class Jugadore
    {
        public int IDJugador { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Posicion { get; set; }
        public int IDEquipo { get; set; }

        public virtual Equipos Equipos { get; set; }
    }
}