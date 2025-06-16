using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SecureQRFields.Models;
using SecureQRFields.Services;
using SecureQRFields.Utils;

namespace SecureQRFields
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            CargarDatosPredeterminados();
        }

        // Agregar filas con datos predeterminados
        private void CargarDatosPredeterminados()
        {
            dataGridCampos.Rows.Add("ServerAddress", "", "Encriptado");
            dataGridCampos.Rows.Add("PortNumber", "", "Encriptado");
            dataGridCampos.Rows.Add("DatabaseName", "", "Encriptado");
            dataGridCampos.Rows.Add("Username", "", "Encriptado");
            dataGridCampos.Rows.Add("Password", "", "Encriptado");
        }

        // Evento principal al presionar "Generar QR"
        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            var campos = ObtenerCamposDesdeTabla();

            if (campos.Count == 0)
            {
                MessageBox.Show("No hay campos válidos para generar QR.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Generar JSON protegido
                string jsonFinal = JsonHelper.GenerarJsonProtegido(campos);

                // 2. Generar código QR
                Bitmap qrImage = QRService.GenerarQRDesdeTexto(jsonFinal);

                // 3. Mostrar QR en PictureBox
                picQRPreview.Image = qrImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el QR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Extraer todos los campos válidos del DataGridView
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

        // Evento sin uso de momento
        private void picQRPreview_Click(object sender, EventArgs e)
        {
        }

        // Evento sin uso de momento
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
