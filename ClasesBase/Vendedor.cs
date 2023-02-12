using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase
{
    public class Vendedor
    {
        public string Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string passw { get; set; }
        public Boolean isAdmin { get; set; }

        public Vendedor()
        {


        }
        public Vendedor(string legajo, string nombre, string apellido, string passw, Boolean isadmin)
        {
            this.Legajo = legajo;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.passw = passw;
            this.isAdmin = isadmin;
            //    if (isadmin == 1) {
            //        this.isAdmin = true;
            //    }
            //    else {
            //        this.isAdmin = false;
            //    }
            //}
        }
    }
}
