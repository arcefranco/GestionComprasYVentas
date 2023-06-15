using Sistema.Datos;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NArticulo
    {
        public static DataTable Listar()
        {
            Sistema.Datos.DArticulo Datos = new Datos.DArticulo();
            return Datos.Listar();
        }
        public static DataTable Buscar(string Valor)
        {
            Sistema.Datos.DArticulo Datos = new Datos.DArticulo();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(int IdCategoria, string Codigo, string Nombre, decimal PrecioVenta, int Stock, 
            string Descripcion, string Imagen)
        {
            Sistema.Datos.DArticulo Datos = new Datos.DArticulo();
            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "El artículo ya existe";
            }
            else
            {
                Articulo Obj = new Articulo();
                Obj.IdCategoria = IdCategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                Obj.Descripcion = Descripcion;
                Obj.Imagen = Imagen;
                return Datos.Insertar(Obj);
            }

        }

        public static string Actualizar(int Id, int IdCategoria, string Codigo, string NombreAnt, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            DArticulo Datos = new DArticulo();
            Articulo Obj = new Articulo();

            if (NombreAnt.Equals(Nombre))
            {
                Obj.IdArticulo = Id;
                Obj.IdCategoria = IdCategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                Obj.Descripcion = Descripcion;
                Obj.Imagen = Imagen;
                return Datos.Actualizar(Obj);
            }
            else
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "El artículo ya existe";
                }
                else
                {
                    Obj.IdArticulo = Id;
                    Obj.IdCategoria = IdCategoria;
                    Obj.Codigo = Codigo;
                    Obj.Nombre = Nombre;
                    Obj.PrecioVenta = PrecioVenta;
                    Obj.Stock = Stock;
                    Obj.Descripcion = Descripcion;
                    Obj.Imagen = Imagen;
                    return Datos.Actualizar(Obj);
                }
            }

        }

        public static string Eliminar(int Id)
        {
            Sistema.Datos.DArticulo Datos = new Datos.DArticulo();
            return Datos.Eliminar(Id);
        }
        public static string Activar(int Id)
        {
            Sistema.Datos.DArticulo Datos = new Datos.DArticulo();
            return Datos.Activar(Id);
        }
        public static string Desactivar(int Id)
        {
            Sistema.Datos.DArticulo Datos = new Datos.DArticulo();
            return Datos.Desctivar(Id);
        }
    }
}
