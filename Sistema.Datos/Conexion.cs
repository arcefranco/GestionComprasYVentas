using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;

        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "dbsistema";
            this.Servidor = "sistemasgf07\\SQLEXPRESS";
            this.Usuario = "sa";
            this.Clave = "";
            this.Seguridad = true;
        }

        public SqlConnection CrearConexion() 
        {
            SqlConnection Cadena = new SqlConnection();

            try 
            {
                Cadena.ConnectionString = "Data Source=sistemasgf07\\SQLEXPRESS;Initial Catalog=dbsistema;Integrated Security=True";

            }
            catch(Exception ex) 
            {
                Cadena = null;
                throw ex;
            
            }

            return Cadena;
        }

        public static Conexion  getInstancia () 
        { 
            if(Con == null)
            {
                Con = new Conexion();
            }
            return Con;  
        }
    }
}
