using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Cliente : INotifyPropertyChanged
    {
        private string dni;
        public string DNI {
            get {return dni;}
            set {
                dni = value;
                Notificador(dni);
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                Notificador(nombre);
            }
        }

        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;
                Notificador(apellido);
            }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                Notificador(direccion);
            }
        }

        //public string DNI { get; set { DNI = value; Notificador(DNI); } }
        //public string Nombre { get; set { Nombre = value; Notificador(Nombre); } }
        //public string Apellido { get; set { Apellido = value; Notificador(Apellido); } }
        //public string Direccion { get; set { Direccion = value; Notificador(Direccion); } }

        public Cliente()
        { 
        
        }

        public Cliente(string dni, string nombre, string apellido, string direccion) { 
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void Notificador(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
