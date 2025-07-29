namespace SecureQRFields
{
    partial class FormMain
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
            this.dataGridCampos = new System.Windows.Forms.DataGridView();
            this.colCampo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodificacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnGenerarQR = new System.Windows.Forms.Button();
            this.picQRPreview = new System.Windows.Forms.PictureBox();
            this.comboSucursales = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridCampos
            // 
            this.dataGridCampos.AllowUserToOrderColumns = true;
            this.dataGridCampos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCampos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCampo,
            this.colValor,
            this.colCodificacion});
            this.dataGridCampos.Location = new System.Drawing.Point(-3, -1);
            this.dataGridCampos.Name = "dataGridCampos";
            this.dataGridCampos.Size = new System.Drawing.Size(634, 238);
            this.dataGridCampos.TabIndex = 0;
            this.dataGridCampos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colCampo
            // 
            this.colCampo.HeaderText = "Campo";
            this.colCampo.Name = "colCampo";
            // 
            // colValor
            // 
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            // 
            // colCodificacion
            // 
            this.colCodificacion.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colCodificacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.colCodificacion.HeaderText = "Codificación";
            this.colCodificacion.Items.AddRange(new object[] {
            "Texto plano",
            "Encriptado",
            "Hasheado"});
            this.colCodificacion.Name = "colCodificacion";
            // 
            // btnGenerarQR
            // 
            this.btnGenerarQR.Location = new System.Drawing.Point(31, 258);
            this.btnGenerarQR.Name = "btnGenerarQR";
            this.btnGenerarQR.Size = new System.Drawing.Size(288, 40);
            this.btnGenerarQR.TabIndex = 2;
            this.btnGenerarQR.Text = "Generar QR";
            this.btnGenerarQR.UseVisualStyleBackColor = true;
            this.btnGenerarQR.Click += new System.EventHandler(this.btnGenerarQR_Click);
            // 
            // picQRPreview
            // 
            this.picQRPreview.Location = new System.Drawing.Point(166, 324);
            this.picQRPreview.Name = "picQRPreview";
            this.picQRPreview.Size = new System.Drawing.Size(288, 225);
            this.picQRPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRPreview.TabIndex = 3;
            this.picQRPreview.TabStop = false;
            this.picQRPreview.Click += new System.EventHandler(this.picQRPreview_Click);
            // 
            // comboSucursales
            // 
            this.comboSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSucursales.FormattingEnabled = true;
            this.comboSucursales.Location = new System.Drawing.Point(380, 277);
            this.comboSucursales.Name = "comboSucursales";
            this.comboSucursales.Size = new System.Drawing.Size(195, 21);
            this.comboSucursales.TabIndex = 4;
            this.comboSucursales.SelectedIndexChanged += new System.EventHandler(this.comboSucursales_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione Sucursal";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 566);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboSucursales);
            this.Controls.Add(this.picQRPreview);
            this.Controls.Add(this.btnGenerarQR);
            this.Controls.Add(this.dataGridCampos);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picQRPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridCampos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCampo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewComboBoxColumn colCodificacion;
        private System.Windows.Forms.Button btnGenerarQR;
        private System.Windows.Forms.PictureBox picQRPreview;
        private System.Windows.Forms.ComboBox comboSucursales;
        private System.Windows.Forms.Label label1;
    }
}