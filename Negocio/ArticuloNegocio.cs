using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                            @"SELECT
                                A.Id,
                                A.Codigo,
                                A.Nombre,
                                A.Descripcion,
                                A.IdMarca,
                                A.IdCategoria,
                                A.Precio,
                                M.Descripcion AS Marca,
                                C.Descripcion AS Categoria,
                                I.ImagenUrl,
                                I.Id AS IdImagen,
                                I.IdArticulo
                            FROM ARTICULOS A
                            INNER JOIN MARCAS M
                                ON M.Id = A.IdMarca
                            INNER JOIN CATEGORIAS C
                                ON C.Id = A.IdCategoria
                            LEFT JOIN IMAGENES I
                                ON I.IdArticulo = A.Id"
                            );
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int IdArticulo = (int)datos.Lector["Id"];
                    Articulo existente = lista.FirstOrDefault(a => a.Id == IdArticulo);
                    if (existente == null)
                    {
                        Articulo aux = new Articulo();
                        aux.Id = (int)datos.Lector["Id"];
                        aux.Codigo = (string)datos.Lector["Codigo"];
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Precio = (decimal)datos.Lector["Precio"];
                        aux.Marca = new Marca();
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                        aux.Categoria = new Categoria();
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        aux.Imagenes = new List<Imagen>();
                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                        {
                            Imagen img = new Imagen
                            {
                                Id = (int)datos.Lector["IdImagen"],
                                ImagenUrl = (string)datos.Lector["ImagenUrl"],
                                IdArticulo = (int)datos.Lector["IdArticulo"]

                            };
                            aux.Imagenes.Add(img);
                        }
                        lista.Add(aux);

                    }
                    else
                    {
                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                        {
                            Imagen img = new Imagen
                            {
                                Id = (int)datos.Lector["IdImagen"],
                                ImagenUrl = (string)datos.Lector["ImagenUrl"]
                            };
                            existente.Imagenes.Add(img);
                        }



                    }
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
        public void Agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio); " + "Select SCOPE_IDENTITY()");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);

                articulo.Id = Convert.ToInt32(datos.ejecutarScalar());

                ImagenNegocio imgNegocio = new ImagenNegocio();

                foreach (Imagen img in articulo.Imagenes)
                {
                    img.IdArticulo = articulo.Id;

                    imgNegocio.agregar(img);
                }

                datos.cerrarConexion();


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

        public void Modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Articulos set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio where Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.Id);
                datos.ejecutarAccion();
                ImagenNegocio imgNegocio = new ImagenNegocio();

                imgNegocio.eliminarPorArticulo(articulo.Id);

                foreach (Imagen img in articulo.Imagenes)
                {
                    img.IdArticulo = articulo.Id;
                    imgNegocio.agregar(img);
                }
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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                ImagenNegocio imgNegocio = new ImagenNegocio();
                imgNegocio.eliminarPorArticulo(id);

                datos.setearConsulta("Delete from Articulos where Id = @Id");
                datos.setearParametro("@Id", id);
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

        public bool ExisteCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE Codigo = @codigo");
                datos.setearParametro("@codigo", codigo);
                return Convert.ToInt32(datos.ejecutarScalar()) > 0;
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
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, 
                                   M.Descripcion AS Marca, C.Descripcion AS Categoria, 
                                   I.ImagenUrl, I.Id AS IdImagen, I.IdArticulo
                            FROM ARTICULOS A
                            INNER JOIN MARCAS M ON M.Id = A.IdMarca
                            INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria
                            LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id WHERE ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + filtro;
                            break;
                        default:
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Nombre LIKE '%" + filtro + "%'";
                            break;
                    }
                }
                else 
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "M.Descripcion LIKE '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "M.Descripcion LIKE '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion LIKE '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idArticulo = (int)datos.Lector["Id"];
                    Articulo existente = lista.FirstOrDefault(a => a.Id == idArticulo);
                    if (existente == null)
                    {
                        Articulo aux = new Articulo();
                        aux.Id = idArticulo;
                        aux.Codigo = (string)datos.Lector["Codigo"];
                        aux.Nombre = (string)datos.Lector["Nombre"];
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                        aux.Precio = (decimal)datos.Lector["Precio"];
                        aux.Marca = new Marca { Id = (int)datos.Lector["IdMarca"], Descripcion = (string)datos.Lector["Marca"] };
                        aux.Categoria = new Categoria { Id = (int)datos.Lector["IdCategoria"], Descripcion = (string)datos.Lector["Categoria"] };
                        aux.Imagenes = new List<Imagen>();

                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                        {
                            aux.Imagenes.Add(new Imagen
                            {
                                Id = (int)datos.Lector["IdImagen"],
                                ImagenUrl = (string)datos.Lector["ImagenUrl"],
                                IdArticulo = (int)datos.Lector["IdArticulo"]
                            });
                        }
                        lista.Add(aux);
                    }
                    else
                    {
                        if (!(datos.Lector["ImagenUrl"] is DBNull))
                        {
                            existente.Imagenes.Add(new Imagen
                            {
                                Id = (int)datos.Lector["IdImagen"],
                                ImagenUrl = (string)datos.Lector["ImagenUrl"]
                            });
                        }
                    }
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
    }
}
