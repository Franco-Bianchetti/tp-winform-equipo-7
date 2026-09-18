using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Dominio;
using Negocio;

namespace TPWinForm_equipo_7.Interfaz
{
    public partial class frmListadoMarcas : Form
    {
        private List<Marca> listaMarcas;

        public frmListadoMarcas()
        {
            InitializeComponent();
        }

        private void frmListadoMarcas_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                listaMarcas = negocio.listar();

                dgvMarcas.DataSource = null;
                dgvMarcas.DataSource = listaMarcas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaMarca frm = new frmAltaMarca();
            frm.ShowDialog();

            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca.");
                return;
            }

            Marca seleccionada =
                (Marca)dgvMarcas.CurrentRow.DataBoundItem;

            frmAltaMarca frm =
                new frmAltaMarca(seleccionada);

            frm.ShowDialog();

            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una marca.");
                return;
            }

            Marca seleccionada =
                (Marca)dgvMarcas.CurrentRow.DataBoundItem;

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea eliminar la marca?",
                    "Eliminar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                MarcaNegocio negocio =
                    new MarcaNegocio();

                negocio.eliminar(seleccionada.Id);

                cargar();
            }
        }
    }
}