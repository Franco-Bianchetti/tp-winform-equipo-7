using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_equipo_7.Modelos
{
    public class Imagen
    {
        public int Id { get; set; }
        public int IdArticulo {  get; set; }
        public string ImagenUrl { get; set; }

        public Imagen() { }

        public Imagen(int id, int idArticulo, string imagenUrl)
        {
            Id = id;
            IdArticulo = idArticulo;
            ImagenUrl = imagenUrl;
        }
    }
}
