using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NUsuario
    {

        public static DataTable Listar()
        {
            Sistema.Datos.DUsuario Datos = new Datos.DUsuario();
            return Datos.Listar();
        }
        public static DataTable Buscar(string Valor)
        {
            Sistema.Datos.DUsuario Datos = new Datos.DUsuario();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(int IdRol, string Nombre, int TipoDocumento, 
            string NumDocumento, string Direccion, string Telefono, string Email, string Clave)
        {
            Sistema.Datos.DUsuario Datos = new Datos.DUsuario();
            string Existe = Datos.Existe(Email);
            if (Existe.Equals("1"))
            {
                return "El usuario ya existe";
            }
            else
            {
                Usuario Obj = new Usuario();
                Obj.IdRol = IdRol;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;
                Obj.Nombre = Nombre;
                return Datos.Insertar(Obj);
            }

        }

        public static string Actualizar(int Id, int IdRol, string Nombre, int TipoDocumento,
            string NumDocumento, string Direccion, string Telefono, string EmailAnt, string Email, string Clave)
        {
            Sistema.Datos.DUsuario Datos = new Datos.DUsuario();
            Usuario Obj = new Usuario();


            if (EmailAnt.Equals(Email))
            {
                Obj.IdUsuario = Id;
                Obj.IdRol = IdRol;
                Obj.TipoDocumento = TipoDocumento;
                Obj.NumDocumento = NumDocumento;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                Obj.Clave = Clave;
                Obj.Nombre = Nombre;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Email);
                if (Existe.Equals("1"))
                {
                    return "El usuario con ese email ya existe";
                }
                else
                {
                    Obj.IdUsuario = Id;
                    Obj.IdRol = IdRol;
                    Obj.TipoDocumento = TipoDocumento;
                    Obj.NumDocumento = NumDocumento;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    Obj.Clave = Clave;
                    Obj.Nombre = Nombre;
                    return Datos.Actualizar(Obj);

                }
            }



        }

        public static string Eliminar(int Id)
        {
            Sistema.Datos.DUsuario Datos = new Datos.DUsuario();
            return Datos.Eliminar(Id);
        }
        public static string Activar(int Id)
        {
            Sistema.Datos.DUsuario Datos = new Datos.DUsuario();
            return Datos.Activar(Id);
        }
        public static string Desactivar(int Id)
        {
            Sistema.Datos.DUsuario Datos = new Datos.DUsuario();
            return Datos.Desctivar(Id);
        }
    }
}
