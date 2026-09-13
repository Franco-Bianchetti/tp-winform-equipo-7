using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPWinForm_equipo_7.Modelos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPWinForm_equipo_7.Interfaz
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Completá al menos Código y Nombre.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingresá un precio válido.");
                return;
            }

            if (cboMarca.SelectedItem == null || cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná marca y categoría.");
                return;
            }

            if (articulo == null)
                articulo = new Articulo();

            articulo.Codigo = txtCodigo.Text;
            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Precio = precio;
            articulo.Marca = (Marca)cboMarca.SelectedItem;
            articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

            articulo.Imagenes.Clear();
            foreach (var item in lstImagenes.Items)
                articulo.Imagenes.Add(new Imagen { ImagenUrl = item.ToString() });

            MessageBox.Show("Artículo guardado (en memoria, todavía sin base de datos).");
            Close();
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                picImagen.Image = Image.FromFile(imagen);
            }
            catch (Exception ex)
            {
                picImagen.Image = null;
                MessageBox.Show("No se pudo cargar la imagen");
            } 
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                lstImagenes.Items.Add(archivo.FileName);
                lstImagenes.SelectedItem = archivo.FileName;
            }
        }

        private void lstImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImagenes.SelectedItem == null) return;

            string ruta0Url = lstImagenes.SelectedItem.ToString();
            cargarImagen(ruta0Url);
        }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            if (lstImagenes.SelectedIndex < 0) return;
            lstImagenes.Items.RemoveAt(lstImagenes.SelectedIndex);
            picImagen.Image = null;
        }
    }
}
