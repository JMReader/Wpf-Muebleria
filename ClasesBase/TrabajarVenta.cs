using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarVenta
    {
        public void cargarVenta(Venta vent)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "cargarVenta";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nroFactura", vent.NroFactura);
            cmd.Parameters.AddWithValue("@fechaFactura", vent.FechaFactura);
            cmd.Parameters.AddWithValue("@legajo", vent.Legajo);
            cmd.Parameters.AddWithValue("@dni", vent.DNI);
            cmd.Parameters.AddWithValue("@codProducto", vent.CodProducto);
            cmd.Parameters.AddWithValue("@precio", vent.Precio);
            cmd.Parameters.AddWithValue("@cantidad", vent.Cantidad);
            cmd.Parameters.AddWithValue("@importe", vent.Importe);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Parameters.Clear();
        }

        public Boolean VentaEnTabla(int nroFactura)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            Boolean aux;
            cmd.Connection = cnn;
            cmd.CommandText = "VentaExistente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nroFactura", nroFactura);
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