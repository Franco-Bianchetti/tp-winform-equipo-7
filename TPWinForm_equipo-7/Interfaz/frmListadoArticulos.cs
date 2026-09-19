using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TPWinForm_equipo_7.Interfaz
{
    public partial class frmListadoArticulos : Form
    {
        private List<Imagen> listaImagen;
        private int indiceImagen = 0;
        private List<Articulo> articulos = new List<Articulo>();
        public frmListadoArticulos()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = textBox1.Text.Trim().ToUpper();

            if (filtro.Length >= 2)
            {
                listaFiltrada = articulos.FindAll(x =>
                    (x.Nombre != null && x.Nombre.ToUpper().Contains(filtro)) ||
                    (x.Codigo != null && x.Codigo.ToUpper().Contains(filtro)) ||
                    (x.Marca != null && x.Marca.Descripcion != null && x.Marca.Descripcion.ToUpper().Contains(filtro)) ||
                    (x.Categoria != null && x.Categoria.Descripcion != null && x.Categoria.Descripcion.ToUpper().Contains(filtro)));
            }
            else
            {
                listaFiltrada = articulos;
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;

            if (dgvArticulos.Columns["Imagenes"] != null)
                dgvArticulos.Columns["Imagenes"].Visible = false;

            actualizarVisor();
        }
        private void actualizarVisor()
        {
            if (dgvArticulos.CurrentRow != null && dgvArticulos.CurrentRow.DataBoundItem != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                if (seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
                {
                    if (indiceImagen >= seleccionado.Imagenes.Count)
                        indiceImagen = 0;

                    cargarImagen(seleccionado.Imagenes[indiceImagen].ImagenUrl);
                    lblContadorImagen.Text = $"{indiceImagen + 1} / {seleccionado.Imagenes.Count}";
                }
                else
                {
                    cargarImagen("");
                    lblContadorImagen.Text = "0 / 0";
                }
            }
            else
            {
                cargarImagen("");
                lblContadorImagen.Text = "0 / 0";
            }
        }
        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                articulos = negocio.ListarArticulos();
                dgvArticulos.DataSource = articulos;

                if (dgvArticulos.Columns["Imagenes"] != null)
                    dgvArticulos.Columns["Imagenes"].Visible = false;

                actualizarVisor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message);
            }
        }

        private void frmListadoArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Clear();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Precio");
            cboCampo.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo frm = new frmAltaArticulo();
            frm.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un articulo.");
                return;
            }

            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            ArticuloNegocio negocio = new ArticuloNegocio();

            DialogResult confirmacion = MessageBox.Show(
                $"¿Seguro que querés eliminar \"{seleccionado.Nombre}\"?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)

                try
                {
                    negocio.Eliminar(seleccionado.Id);
                    cargar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message);
                }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo detalle = new frmAltaArticulo(seleccionado, true);
            detalle.ShowDialog();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null) return;

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            if (seleccionado == null) return;

            indiceImagen = 0;

            if (seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
            {
                cargarImagen(seleccionado.Imagenes[indiceImagen].ImagenUrl);
                lblContadorImagen.Text = $"{indiceImagen + 1} / {seleccionado.Imagenes.Count}";
            }
            else
            {
                cargarImagen(""); 
                lblContadorImagen.Text = "0 / 0";
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://st2.depositphotos.com/2586633/46477/v/950/depositphotos_464771766-stock-illustration-no-photo-or-blank-image.jpg");
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null) return;

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            if (seleccionado != null && seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
            {
                indiceImagen++;

                if (indiceImagen >= seleccionado.Imagenes.Count)
                    indiceImagen = 0;

                cargarImagen(seleccionado.Imagenes[indiceImagen].ImagenUrl);
                lblContadorImagen.Text = $"{indiceImagen + 1} / {seleccionado.Imagenes.Count}";
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null) return;

            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            if (seleccionado != null && seleccionado.Imagenes != null && seleccionado.Imagenes.Count > 0)
            {
                indiceImagen--;

                if (indiceImagen < 0)
                    indiceImagen = seleccionado.Imagenes.Count - 1;

                cargarImagen(seleccionado.Imagenes[indiceImagen].ImagenUrl);
                lblContadorImagen.Text = $"{indiceImagen + 1} / {seleccionado.Imagenes.Count}";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem?.ToString();

            
            cboCriterio.Items.Clear();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }

            if (cboCriterio.Items.Count > 0)
                cboCriterio.SelectedIndex = 0;
        }

        private void brnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (cboCampo.SelectedIndex < 0 || cboCriterio.SelectedIndex < 0)
                {
                    MessageBox.Show("Por favor, seleccione Campo y Criterio.");
                    return;
                }

                if (cboCampo.SelectedItem.ToString() == "Precio")
                {
                    if (string.IsNullOrWhiteSpace(textBox2.Text) || !decimal.TryParse(textBox2.Text.Trim(), out _))
                    {
                        MessageBox.Show("Para filtrar por Precio, ingrese un número válido.");
                        return;
                    }
                }

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = textBox2.Text.Trim();

                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

                if (dgvArticulos.Columns["Imagenes"] != null)
                    dgvArticulos.Columns["Imagenes"].Visible = false;

                actualizarVisor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }
    private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
 