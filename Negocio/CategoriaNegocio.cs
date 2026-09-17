using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;using Datos;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT Id, Descripcion FROM CATEGORIAS");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion =
                        datos.Lector["Descripcion"].ToString();

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    

public void agregar(Categoria nueva)
{
    AccesoDatos datos = new AccesoDatos();

    try
    {
        datos.setearConsulta("INSERT INTO CATEGORIAS (Descripcion) VALUES (@descripcion)");
        datos.setearParametro("@descripcion", nueva.Descripcion);
        datos.ejecutarAccion();
    }
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        datos.cerrarConexion();
    }
}

public void modificar(Categoria categoria)
{
    AccesoDatos datos = new AccesoDatos();

    try
    {
        datos.setearConsulta("UPDATE CATEGORIAS SET Descripcion = @descripcion WHERE Id = @id");
        datos.setearParametro("@descripcion", categoria.Descripcion);
        datos.setearParametro("@id", categoria.Id);
        datos.ejecutarAccion();
    }
    catch (Exception ex)
    {
        throw ex;
    }
    finally
    {
        datos.cerrarConexion();
    }
}
    }
}