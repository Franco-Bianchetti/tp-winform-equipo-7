namespace TPWinForm_equipo_7.Interfaz
{
    partial class frmListadoArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.lblContadorImagen = new System.Windows.Forms.Label();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblcriterio = new System.Windows.Forms.Label();
            this.lblcapo = new System.Windows.Forms.Label();
            this.cboCampo = new System.Windows.Forms.ComboBox();
            this.cboCriterio = new System.Windows.Forms.ComboBox();
            this.lblFiltroavanzado = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.brnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(15, 99);
            this.dgvArticulos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 51;
            this.dgvArticulos.RowTemplate.Height = 24;
            this.dgvArticulos.Size = new System.Drawing.Size(385, 239);
            this.dgvArticulos.TabIndex = 0;
            this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbxArticulo.Location = new System.Drawing.Point(404, 99);
            this.pbxArticulo.Margin = new System.Windows.Forms.Padding(2);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(160, 239);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxArticulo.TabIndex = 1;
            this.pbxArticulo.TabStop = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(15, 355);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(74, 27);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "&Agregar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(93, 355);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(74, 27);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(171, 355);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(74, 27);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDetalle.Location = new System.Drawing.Point(249, 355);
            this.btnDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(74, 27);
            this.btnDetalle.TabIndex = 5;
            this.btnDetalle.Text = "&Detalles";
            this.btnDetalle.UseVisualStyleBackColor = false;
            // 
            // lblContadorImagen
            // 
            this.lblContadorImagen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblContadorImagen.AutoSize = true;
            this.lblContadorImagen.Location = new System.Drawing.Point(472, 340);
            this.lblContadorImagen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContadorImagen.Name = "lblContadorImagen";
            this.lblContadorImagen.Size = new System.Drawing.Size(24, 13);
            this.lblContadorImagen.TabIndex = 6;
            this.lblContadorImagen.Text = "1/1";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnterior.Location = new System.Drawing.Point(404, 355);
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(30, 19);
            this.btnAnterior.TabIndex = 7;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSiguiente.Location = new System.Drawing.Point(534, 359);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(30, 19);
            this.btnSiguiente.TabIndex = 8;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(32, 58);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(67, 13);
            this.lblFiltro.TabIndex = 9;
            this.lblFiltro.Text = "Filtro rápido :";
            this.lblFiltro.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblcriterio
            // 
            this.lblcriterio.AutoSize = true;
            this.lblcriterio.Location = new System.Drawing.Point(328, 420);
            this.lblcriterio.Name = "lblcriterio";
            this.lblcriterio.Size = new System.Drawing.Size(42, 13);
            this.lblcriterio.TabIndex = 11;
            this.lblcriterio.Text = "Criterio:";
            // 
            // lblcapo
            // 
            this.lblcapo.AutoSize = true;
            this.lblcapo.Location = new System.Drawing.Point(191, 420);
            this.lblcapo.Name = "lblcapo";
            this.lblcapo.Size = new System.Drawing.Size(43, 13);
            this.lblcapo.TabIndex = 12;
            this.lblcapo.Text = "Campo:";
            // 
            // cboCampo
            // 
            this.cboCampo.FormattingEnabled = true;
            this.cboCampo.Location = new System.Drawing.Point(141, 436);
            this.cboCampo.Name = "cboCampo";
            this.cboCampo.Size = new System.Drawing.Size(121, 21);
            this.cboCampo.TabIndex = 13;
            this.cboCampo.SelectedIndexChanged += new System.EventHandler(this.cboCampo_SelectedIndexChanged);
            // 
            // cboCriterio
            // 
            this.cboCriterio.FormattingEnabled = true;
            this.cboCriterio.Location = new System.Drawing.Point(280, 436);
            this.cboCriterio.Name = "cboCriterio";
            this.cboCriterio.Size = new System.Drawing.Size(121, 21);
            this.cboCriterio.TabIndex = 14;
            this.cboCriterio.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lblFiltroavanzado
            // 
            this.lblFiltroavanzado.AutoSize = true;
            this.lblFiltroavanzado.Location = new System.Drawing.Point(413, 420);
            this.lblFiltroavanzado.Name = "lblFiltroavanzado";
            this.lblFiltroavanzado.Size = new System.Drawing.Size(83, 13);
            this.lblFiltroavanzado.TabIndex = 15;
            this.lblFiltroavanzado.Text = "Filtro Avanzado:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(407, 436);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // brnBuscar
            // 
            this.brnBuscar.Location = new System.Drawing.Point(314, 462);
            this.brnBuscar.Name = "brnBuscar";
            this.brnBuscar.Size = new System.Drawing.Size(75, 23);
            this.brnBuscar.TabIndex = 17;
            this.brnBuscar.Text = "Buscar";
            this.brnBuscar.UseVisualStyleBackColor = true;
            this.brnBuscar.Click += new System.EventHandler(this.brnBuscar_Click);
            // 
            // frmListadoArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(950, 514);
            this.Controls.Add(this.brnBuscar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblFiltroavanzado);
            this.Controls.Add(this.cboCriterio);
            this.Controls.Add(this.cboCampo);
            this.Controls.Add(this.lblcapo);
            this.Controls.Add(this.lblcriterio);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.lblContadorImagen);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.dgvArticulos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(966, 411);
            this.Name = "frmListadoArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Articulos";
            this.Load += new System.EventHandler(this.frmListadoArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Label lblContadorImagen;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblcriterio;
        private System.Windows.Forms.Label lblcapo;
        private System.Windows.Forms.ComboBox cboCampo;
        private System.Windows.Forms.ComboBox cboCriterio;
        private System.Windows.Forms.Label lblFiltroavanzado;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button brnBuscar;
    }
}