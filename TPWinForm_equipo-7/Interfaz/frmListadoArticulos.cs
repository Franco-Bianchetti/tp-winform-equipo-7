using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace TPWinForm_equipo_7.Interfaz
{
    public partial class frmListadoArticulos : Form
    {
        private List<Articulo> articulos = new List<Articulo>();

        public frmListadoArticulos()
        {
            InitializeComponent();
        }

        private void frmListadoArticulos_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                articulos = negocio.ListarArticulos();
                dgvArticulos.DataSource = articulos;

                if (dgvArticulos.Columns["Imagenes"] != null)
                    dgvArticulos.Columns["Imagenes"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo frm = new frmAltaArticulo();
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            Articulo seleccionado =
                (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar =
                new frmAltaArticulo(seleccionado);

            modificar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            Articulo seleccionado =
                (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Seguro que querés eliminar \"{seleccionado.Nombre}\"?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes)
                return;

            articulos.Remove(seleccionado);

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = articulos;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            Articulo seleccionado =
                (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            // Pendiente
            // frmDetalleArticulo frm = new frmDetalleArticulo(seleccionado);
            // frm.ShowDialog();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticulos.CurrentRow == null)
                    return;

                Articulo seleccionado =
                    (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

                if (seleccionado == null)
                    return;

                if (seleccionado.Imagenes != null &&
                    seleccionado.Imagenes.Count > 0)
                {
                    cargarImagen(
                        seleccionado.Imagenes[0].ImagenUrl);
                }
                else
                {
                    pbxArticulo.Image = null;
                }
            }
            catch
            {
                pbxArticulo.Image = null;
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                if (string.IsNullOrEmpty(imagen))
                {
                    pbxArticulo.Image = null;
                    return;
                }

                pbxArticulo.Load(imagen);
            }
            catch
            {
                pbxArticulo.Image = null;
            }

        }
    }
}