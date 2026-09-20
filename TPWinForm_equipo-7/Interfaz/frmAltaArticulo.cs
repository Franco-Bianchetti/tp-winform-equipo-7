using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Dominio;


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
        public frmAltaArticulo(Articulo articulo, bool sololectura = false)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = sololectura ? "Detalle Articulo" : "Modificar Articulo"; 
            if (sololectura)
            {
                bloquearControles();
            }
        }
        private void bloquearControles()
        {
            txtCodigo.ReadOnly = true;
            txtNombre.ReadOnly = true;
            txtDescripcion.ReadOnly = true;
            txtPrecio.ReadOnly = true;
            txtUrlImagen.ReadOnly = true;
            cboMarca.Enabled = false;
            cboCategoria.Enabled = false;
            btnGuardar.Visible = false;
            btnAgregarImagen.Visible = false;
            btnQuitarImagen.Visible = false;
            btnLimpiar.Visible = false;
            btnCancelar.Text = "Cerrar";
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

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.");
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
            {
                articulo.Imagenes.Add(
                    new Imagen
                    {
                        ImagenUrl = item.ToString()
                    });
            }

            ArticuloNegocio negocio = new ArticuloNegocio();

            if (articulo.Id == 0 && negocio.ExisteCodigo(txtCodigo.Text))
            {
                MessageBox.Show("Ya existe un artículo con ese código. Ingrese uno nuevo");
                return;
            }

            if (articulo.Id == 0)
            {
                negocio.Agregar(articulo);
                MessageBox.Show("Artículo agregado correctamente.");
            }
            else
            {
                negocio.Modificar(articulo);
                MessageBox.Show("Artículo modificado correctamente.");
            }

            Close();
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(imagen))
                {
                    picImagen.Image = null;
                    return;
                }

                picImagen.Load(imagen);
            }
            catch
            {
                picImagen.Image = null;
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrlImagen.Text))
            {
                MessageBox.Show("Ingrese una URL.");
                return;
            }

            string url = txtUrlImagen.Text.Trim();

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                MessageBox.Show("La URL ingresada no es válida.");
                return;
            }

            string urlLower = url.ToLower();

            if (!(urlLower.Contains(".jpg") ||
                  urlLower.Contains(".jpeg") ||
                  urlLower.Contains(".png") ||
                  urlLower.Contains(".webp")))
            {
                MessageBox.Show("La URL debe apuntar a una imagen (.jpg, .jpeg, .png o .webp).");
                return;
            }

            if (lstImagenes.Items.Contains(url))
            {
                MessageBox.Show("La imagen ya fue agregada para este artículo.");
                return;
            }

            lstImagenes.Items.Add(url);
            lstImagenes.SelectedItem = url;

            txtUrlImagen.Clear();
        }

        private void lstImagenes_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (lstImagenes.SelectedItem == null)return;

            string url = lstImagenes.SelectedItem.ToString();
    
            cargarImagen(url);
         }

        private void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            if (lstImagenes.SelectedIndex < 0) return;
            lstImagenes.Items.RemoveAt(lstImagenes.SelectedIndex);
            picImagen.Image = null;
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.ValueMember = "Id";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.ValueMember = "Id";

                cboMarca.SelectedIndex = -1;
                cboCategoria.SelectedIndex = -1;

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();

                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;

                    lstImagenes.Items.Clear();

                    foreach (Imagen img in articulo.Imagenes)
                    {
                        lstImagenes.Items.Add(img.ImagenUrl);
                    }

                    if (lstImagenes.Items.Count > 0)
                    {
                        lstImagenes.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUrlImagen.Clear();
            picImagen.Image = null;
            txtUrlImagen.Focus();
        }
    }
}
