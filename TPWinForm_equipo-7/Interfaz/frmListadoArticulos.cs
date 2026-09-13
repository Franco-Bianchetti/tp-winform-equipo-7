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

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmAltaArticulo frm = new frmAltaArticulo();
            frm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un articulo.");
                return;
            }

            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un artículo.");
                return;
            }

            int fila = dgvArticulos.SelectedRows[0].Index;
            Articulo seleccionado = articulos[fila];

            DialogResult confirmacion = MessageBox.Show(
                $"¿Seguro que querés eliminar \"{seleccionado.Nombre}\"?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            articulos.RemoveAt(fila); 
            // CargarGrilla(); 
        }
    }
}
