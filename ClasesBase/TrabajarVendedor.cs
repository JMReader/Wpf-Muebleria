using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarVendedor
    {
        public void cargarVendedor(Vendedor vend)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "cargarVendedor";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@legajo", vend.Legajo);
            cmd.Parameters.AddWithValue("@nombre", vend.Nombre);
            cmd.Parameters.AddWithValue("@apellido", vend.Apellido);
            

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Parameters.Clear();
        }

        public void eliminarVendedor(string legajo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "eliminarVendedor";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@legajo", legajo);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Parameters.Clear();
        }

        public void actualizarVendedor(Vendedor vend)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "editarVendedor";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@legajo", vend.Legajo);
            cmd.Parameters.AddWithValue("@nombre", vend.Nombre);
            cmd.Parameters.AddWithValue("@apellido", vend.Apellido);
            

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Parameters.Clear();
        }

        public Boolean VendedorEntabla(string legajo)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            Boolean aux;
            cmd.Connection = cnn;
            cmd.CommandText = "VendedorExistente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@legajo", legajo);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                aux = true;
            }
            else { aux = false; }
            cnn.Close();
            cmd.Parameters.Clear();
            return aux;
        }
    }
}
