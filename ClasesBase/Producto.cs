using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace ClasesBase
{
    public class Producto : IDataErrorInfo
    {
        public string CodProducto { get; set; }
        public string Categoria { get; set;}
        public string Color { get; set;}
        public string Descripcion { get; set;}
        public decimal Precio { get; set; }
        public string CodImagen { get; set; }

        public Producto()
        { 
        
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get {

                string result = null;

                switch (columnName)
                {
                    case "CodProducto":
                        result = validar_Cod();
                        break;
                    case "Categoria":
                        result = validar_Cat();
                        break;

                    case "Color":
                        result = validar_Col();
                        break;

                    case "Descripcion":
                        result = validar_Desc();
                        break;

                    case "Precio":
                        result = validar_Precio();
                        break;

                    case "CodImagen":
                        result = validar_imagen();
                        break; 
                }

                return result;
            }
        }

        private string validar_Precio()
        {
            if (Precio <= 0) 
                return "El precio debe ser mayor a 0";
            return null;
        }

        private string validar_Desc()
        {
            if (String.IsNullOrEmpty(Descripcion))
                return "Obligatorio";
            else if (Descripcion.Length < 3)
                return "La descripcion debe tener almenos 3 caracteres";
            return null;
        }

        private string validar_Col()
        {
            if (String.IsNullOrEmpty(Color))
                return "Obligatorio";
            else if (Color.Length < 3)
                return "El color debe tener almenos 3 caracteres";
            return null;
        }

        private string validar_Cat()
        {
            if (String.IsNullOrEmpty(Categoria))
                return "Obligatorio";
            else if (Categoria.Length < 3)
                return "La categoria debe tener almenos 3 caracteres";
            return null;
        }

        private string validar_Cod()
        {
            if (String.IsNullOrEmpty(CodProducto))
                 return "Obligatorio";
            else if (CodProducto.Length < 3)
                 return "El nombre debe tener al menos 3 carácteres";
            return null;
        }

        private string validar_imagen() 
        {

            if (String.IsNullOrEmpty(CodImagen))
                return "Obligatorio";
            return null;
        }

    }
}
