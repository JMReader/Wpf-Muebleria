using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;

namespace ClasesBase
{
    public class TrabajarClientes
    {
        public static ObservableCollection<Cliente> TraerClientes() {
            SqlConnection cn = new SqlConnection(ClasesBase.Properties.Settings.Default.muebleriaConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ListarClientes";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;

            DataTable oTablaClientes = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(oTablaClientes);

            var oListaClientes = new ObservableCollection<Cliente>();

            foreach (DataRow fila in oTablaClientes.Rows)
            {
                Cliente oCliente = new Cliente();

                oCliente.DNI = (string)fila["Dni"];
                oCliente.Nombre = (string)fila["Nombre"];
                oCliente.Apellido = (string)fila["Apellido"];
                oCliente.Direccion = (string)fila["Direccion"];

                oListaClientes.Add(oCliente);

            }
            return oListaClientes;
        }

        public void cargarCliente(Cliente cli)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandText = "cargarCliente";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dni", cli.DNI);
            cmd.Parameters.AddWithValue("@apellido", cli.Apellido);
            cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
            cmd.Parameters.AddWithValue("@direccion", cli.Direccion);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Parameters.Clear();
        }

        public void eliminarCliente(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "eliminarCliente";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dni", dni);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Parameters.Clear();
        }

        public void actualizarCliente(Cliente cli)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "editarCliente";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@dni", cli.DNI);
            cmd.Parameters.AddWithValue("@apellido", cli.Apellido);
            cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
            cmd.Parameters.AddWithValue("@direccion", cli.Direccion);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            cmd.Parameters.Clear();
        }

        public Boolean ClienteEntabla(string dni)
        {
            SqlConnection cnn = new SqlConnection(ClasesBase.Properties.Settings.Default.conexion);
            SqlCommand cmd = new SqlCommand();
            Boolean aux;
            cmd.Connection = cnn;
            cmd.CommandText = "ClienteExistente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@dni", dni);
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
