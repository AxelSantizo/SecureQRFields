using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SecureQRFields.Models;
using SecureQRFields.Services;
using SecureQRFields.Utils;
using SecureQRFields.Data;

namespace SecureQRFields
{
    public partial class FormMain : Form
    {
        private List<SucursalConnectionInfo> sucursalesDisponibles;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                var repo = new SucursalRepository();
                sucursalesDisponibles = repo.ObtenerSucursales();

                comboSucursales.DisplayMember = "NombreSucursal";
                comboSucursales.ValueMember = "NombreSucursal";
                comboSucursales.DataSource = sucursalesDisponibles;
                comboSucursales.SelectedIndex = -1;

                // Limpiar tabla al cargar
                dataGridCampos.Rows.Clear();
                picQRPreview.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar sucursales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSucursales.SelectedIndex < 0)
                return;

            var sucursal = (SucursalConnectionInfo)comboSucursales.SelectedItem;

            // 1. Limpiar
            dataGridCampos.Rows.Clear();

            // 2. Agregar campos
            AgregarCampo("Host", sucursal.Server);
            AgregarCampo("Port", "3306");
            AgregarCampo("Database", sucursal.Database);
            AgregarCampo("UserName", sucursal.Uid);
            AgregarCampo("Password", sucursal.Pwd);

            // 3. Generar QR automáticamente
            GenerarQR();
        }

        private void AgregarCampo(string campo, string valor)
        {
            int index = dataGridCampos.Rows.Add();
            var fila = dataGridCampos.Rows[index];
            fila.Cells["colCampo"].Value = campo;
            fila.Cells["colValor"].Value = valor;
            fila.Cells["colCodificacion"].Value = "Encriptado"; // Por defecto
        }

        private void GenerarQR()
        {
            var campos = ObtenerCamposDesdeTabla();

            if (campos.Count == 0)
            {
                MessageBox.Show("No hay campos válidos para generar QR.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string jsonFinal = JsonHelper.GenerarJsonProtegido(campos);
                Bitmap qrImage = QRService.GenerarQRDesdeTexto(jsonFinal);
                picQRPreview.Image = qrImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el QR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<FieldEntry> ObtenerCamposDesdeTabla()
        {
            var listaCampos = new List<FieldEntry>();

            foreach (DataGridViewRow fila in dataGridCampos.Rows)
            {
                if (fila.IsNewRow) continue;

                string campo = fila.Cells["colCampo"].Value?.ToString()?.Trim();
                string valor = fila.Cells["colValor"].Value?.ToString()?.Trim();
                string tipoCod = fila.Cells["colCodificacion"].Value?.ToString()?.Trim();

                if (string.IsNullOrEmpty(campo) || string.IsNullOrEmpty(valor) || string.IsNullOrEmpty(tipoCod))
                    continue;

                FieldEncodingType encodingType = FieldEncodingType.PlainText;

                switch (tipoCod)
                {
                    case "Encriptado":
                        encodingType = FieldEncodingType.Encrypted;
                        break;
                    case "Hasheado":
                        encodingType = FieldEncodingType.Hashed;
                        break;
                }

                listaCampos.Add(new FieldEntry
                {
                    FieldName = campo,
                    OriginalValue = valor,
                    EncodingType = encodingType
                });
            }

            return listaCampos;
        }

        private void picQRPreview_Click(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            GenerarQR();
        }
    }
}
