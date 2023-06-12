using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class NCategoria
    {
        public static DataTable Listar()
        {
            Sistema.Datos.DCategoria Datos = new Datos.DCategoria();
            return Datos.Listar();
        }
        public static DataTable Buscar(string Valor)
        {
            Sistema.Datos.DCategoria Datos = new Datos.DCategoria();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(string Nombre, string Descripcion)
        {
            Sistema.Datos.DCategoria Datos = new Datos.DCategoria();
            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "La categoria ya existe";
            }
            else
            {
                Categoria Obj = new Categoria();
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                return Datos.Insertar(Obj);
            }
            
        }

        public static string Actualizar(int Id, string Nombre, string Descripcion)
        {
            Sistema.Datos.DCategoria Datos = new Datos.DCategoria();
            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "La categoria ya existe";
            }
            else
            {
                Categoria Obj = new Categoria();
                Obj.Nombre = Nombre;
                Obj.Descripcion = Descripcion;
                Obj.IdCategoria = Id;
                return Datos.Actualizar(Obj);
            }

        }

        public static string Eliminar(int Id)
        {
            Sistema.Datos.DCategoria Datos = new Datos.DCategoria();
            return Datos.Eliminar(Id);
        }
        public static string Activar(int Id)
        {
            Sistema.Datos.DCategoria Datos = new Datos.DCategoria();
            return Datos.Activar(Id);
        }
        public static string Desactivar(int Id)
        {
            Sistema.Datos.DCategoria Datos = new Datos.DCategoria();
            return Datos.Desctivar(Id);
        }
    }
}
