using GrupoLeyLoginForm.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;

namespace GrupoLeyLoginForm
{
    public partial class ConfigForm : Form
    {
        readonly ErrorProvider errorProvider = new();
        private CancellationTokenSource? cancellationTokenSourceDatabases;
        private CancellationTokenSource? cancellationTokenSourceDevices;

        public MainForm? MainForm { get; set; }

        public List<OdooDevice> devices = new();

        public ConfigForm()
        {
            InitializeComponent();
            var mainFormAux = Application.OpenForms["MainForm"];
            if (mainFormAux != null)
            {
                MainForm = (MainForm)mainFormAux;
            }
            SetConfigData();
        }

        public void SetConfigData()
        {
            txtUrl.Text = Settings.Default.LoginUrl;
            cbDatabase.Text = Settings.Default.Database;

            cbBrowsers.SelectedItem = Settings.Default.DefaultBrowser;

            if (Settings.Default.AutoCompleteLogins != null)
            {
                string[] logins = Settings.Default.AutoCompleteLogins.Split(";");

                foreach (var item in logins)
                {
                    dgvLogins.Rows.Add(item);
                }
            }

            if (Settings.Default.AutoCompleteCredentials != null)
            {
                string[] credentials = Settings.Default.AutoCompleteCredentials.Split(";");

                foreach (var item in credentials)
                {
                    dgvCredentials.Rows.Add(item);
                }
            }

            if (Settings.Default.Devices != null)
            {
                var dataTable = JsonConvert.DeserializeObject<DataTable>(Settings.Default.Devices);
                List<(string, Type)> columns = new() {
                    ("id", typeof(int)),
                    ("identifier", typeof(string)),
                    ("name", typeof(string)),
                    ("type", typeof(string)),
                    ("iot_id", typeof(int)),
                    ("iot_ip", typeof(string))
                };
                if (dataTable != null)
                {
                    if (dataTable.Rows.Count == 0)
                    {
                        dataTable = new DataTable();
                    }

                    foreach ((string, Type) col in columns)
                    {
                        if (!dataTable.Columns.Contains(col.Item1))
                        {
                            dataTable.Columns.Add(new DataColumn(col.Item1, col.Item2));
                        }
                    }
                }


                dgvDevices.DataSource = dataTable;

                dgvDevices.Columns["id"].HeaderText = "ID";
                dgvDevices.Columns["id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvDevices.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDevices.Columns["id"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvDevices.Columns["identifier"].HeaderText = "Identificador";
                dgvDevices.Columns["identifier"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDevices.Columns["identifier"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvDevices.Columns["identifier"].Visible = false;
                dgvDevices.Columns["name"].HeaderText = "Dispositivo";
                dgvDevices.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDevices.Columns["name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvDevices.Columns["type"].HeaderText = "Tipo";
                dgvDevices.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvDevices.Columns["type"].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvDevices.Columns["iot_id"].HeaderText = "IoT ID";
                dgvDevices.Columns["iot_id"].Visible = false;
                dgvDevices.Columns["iot_ip"].HeaderText = "IoT IP";
                dgvDevices.Columns["iot_ip"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvDevices.Columns["iot_ip"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var network_interfaces = NetworkInterface.GetAllNetworkInterfaces();
            cbNetwork.Items.Add("");
            foreach (NetworkInterface nic in network_interfaces)
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    cbNetwork.Items.Add(nic.Name);
                }
            }
            cbNetwork.SelectedItem = Settings.Default.NetworkInterface;
        }
        private static string AddressBytesToString(byte[] addressBytes)
        {
            return string.Join(":", (from b in addressBytes select b.ToString("X2")).ToArray());
        }

        #region Validation
        private void TxtUrl_TextChanged(object sender, EventArgs e)
        {
            btn_reload_db.Text = "Recargar";
            btnReloadDevices.Text = "Recargar";
        }
        private void TxtConfig_validating(object sender, CancelEventArgs e)
        {
            var txtObject = (TextBox)sender;

            if (string.IsNullOrEmpty(txtObject.Text))
            {
                //txt_object.Focus();
                errorProvider.SetError(txtObject, "¡Por favor ingrese el valor: " + txtObject.AccessibleName + "!");
            }
            else
            {
                errorProvider.SetError(txtObject, null);
            }
        }
        #endregion

        #region Save/Cancel
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Settings.Default["LoginUrl"] = txtUrl.Text;
            Settings.Default["Database"] = cbDatabase.Text;
            Settings.Default["DefaultBrowser"] = cbBrowsers.SelectedItem;
            var logins = dgvLogins.Rows
               .Cast<DataGridViewRow>()
               .Select(x => x.Cells[0].Value)
               .Where(x => x != null)
               .ToList();
            Settings.Default["AutoCompleteLogins"] = string.Join(";", logins);
            var credentials = dgvCredentials.Rows
                .Cast<DataGridViewRow>()
                .Where(x => x.Cells[0].Value != null)
                .Select(x => x.Cells[0].Value?.ToString()?.Trim())
                .ToList();
            Settings.Default["AutoCompleteCredentials"] = string.Join(";", credentials);
            Settings.Default["Devices"] = JsonConvert.SerializeObject(dgvDevices.DataSource);
            Settings.Default["NetworkInterface"] = cbNetwork.SelectedItem;
            Settings.Default.Save();

            ConfigurationManager.RefreshSection("appSettings");

            using (var sw = new StreamWriter("config.ini"))
            {
                sw.WriteLine(Settings.Default.LoginUrl);
                sw.WriteLine(Settings.Default.Database);
                sw.WriteLine(Settings.Default.DefaultBrowser);
                sw.WriteLine(Settings.Default.NetworkInterface);
                sw.WriteLine(Settings.Default.AutoCompleteLogins);
                sw.WriteLine(Settings.Default.AutoCompleteCredentials);
                sw.WriteLine(Settings.Default.Devices);
                //sw.WriteLine("Neftalí Michelet");
            }

            MessageBox.Show("Guardado", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MainForm?.SetConfigData();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            cancellationTokenSourceDatabases?.Cancel();
            this.Close();
        }
        #endregion

        #region Reload Databases
        private async void BtnReloadDB_click(object sender, EventArgs e)
        {
            btn_reload_db.Text = "Cargando";
            string[] items = Array.Empty<string>();

            cancellationTokenSourceDatabases?.Cancel();
            cancellationTokenSourceDatabases = new CancellationTokenSource();
            await Task.Run(() =>
            {
                items = ListDatabasesAsync(cancellationTokenSourceDatabases.Token).Result;
            });

            if (items.Length > 0)
            {
                btn_reload_db.Text = "¡LISTO!";
                cbDatabase.Items.Clear();
                foreach (string item in items)
                {
                    cbDatabase.Items.Add(item);
                }
                if (string.IsNullOrEmpty(cbDatabase.Text))
                {
                    cbDatabase.SelectedIndex = 0;
                }
            }
            else
            {
                btn_reload_db.Text = "Recargar";
            }
        }
        private async Task<string[]> ListDatabasesAsync(CancellationToken cancellationToken)
        {
            string[] result = Array.Empty<string>();

            var tcs = new TaskCompletionSource<string[]>(cancellationToken);

            var odooRequest = new OdooRequest<Dummy> { Params = new() };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var data = JsonConvert.SerializeObject(odooRequest, serializerSettings);

            try
            {
                HttpClientHandler clientHandler = new()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };
                using var client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(txtUrl.Text);

                HttpContent body = new StringContent(data, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/web/database/list", body, cancellationToken).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken);
                    if (!string.IsNullOrEmpty(content))
                    {
                        var odooResponse = JsonConvert.DeserializeObject<OdooResponse<string[]>>(content);

                        if (odooResponse != null && odooResponse.Result != null)
                        {
                            result = odooResponse.Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    _ = MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            tcs.SetResult(result);

            return await tcs.Task;
        }
        #endregion

        #region Reload Devices
        private async void BtnReloadDevices_Click(object sender, EventArgs e)
        {
            btnReloadDevices.Text = "Cargando";

            cancellationTokenSourceDevices?.Cancel();
            cancellationTokenSourceDevices = new CancellationTokenSource();
            await Task.Run(() =>
            {
                devices = ListDevicesAsync(cancellationTokenSourceDevices.Token).Result;
            });

            if (devices.Count > 0)
            {
                btnReloadDevices.Text = "¡LISTO!";
                cbDevice.Items.Clear();
                foreach (OdooDevice item in devices)
                {
                    cbDevice.Items.Add($"{item.name} ({item.iot_ip.Replace("\t", "")}) {item.type}");
                }
                cbDevice.SelectedIndex = 0;
            }
            else
            {
                btnReloadDevices.Text = "Recargar";
            }
        }
        private async Task<List<OdooDevice>> ListDevicesAsync(CancellationToken cancellationToken)
        {
            List<OdooDevice> result = new();

            var tcs = new TaskCompletionSource<List<OdooDevice>>(cancellationToken);

            var odooRequest = new OdooRequest<Dummy> { Params = new() };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var data = JsonConvert.SerializeObject(odooRequest, serializerSettings);

            try
            {
                HttpClientHandler clientHandler = new()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                };
                using var client = new HttpClient(clientHandler);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(txtUrl.Text);

                HttpContent body = new StringContent(data, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/custom_login/device/list", body, cancellationToken).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync(cancellationToken);
                    if (!string.IsNullOrEmpty(content))
                    {
                        var odooResponse = JsonConvert.DeserializeObject<OdooResponse<List<OdooDevice>>>(content);

                        if (odooResponse != null && odooResponse.Result != null)
                        {
                            result = odooResponse.Result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!cancellationToken.IsCancellationRequested)
                {
                    _ = MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            tcs.SetResult(result);

            return await tcs.Task;
        }
        #endregion

        #region Datagrid Devices

        private void BtnAddDevice_Click(object sender, EventArgs e)
        {
            if (cbDevice.SelectedIndex >= 0)
            {
                var device = devices[cbDevice.SelectedIndex];
                var dataTable = (DataTable)dgvDevices.DataSource;

                var registro = dataTable.Rows
                    .Cast<DataRow>()
                    .SingleOrDefault(r => r["id"].ToString() == device.id.ToString());

                if (registro == null)
                {
                    dataTable.Rows.Add(device.id, device.identifier, device.name, device.type, device.iot_id, device.iot_ip);

                    dgvDevices.Refresh();
                }
            }
        }

        private void Dbv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {
                MoveUp((DataGridView)sender);
                e.Handled = true;
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                MoveDown((DataGridView)sender);
                e.Handled = true;
            }
        }

        private static void MoveUp(DataGridView dataGridView)
        {
            if (dataGridView.RowCount > 0)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int firstIndex = dataGridView.SelectedRows.Cast<DataGridViewRow>().Min(x => x.Index);
                    int lastIndex = dataGridView.SelectedRows.Cast<DataGridViewRow>().Max(x => x.Index);

                    if (firstIndex - 1 >= 0)
                    {
                        var dataTable = (DataTable)dataGridView.DataSource;
                        MoveDataRowTo(dataTable.Rows[firstIndex - 1], lastIndex);
                    }
                }
            }
        }

        private static void MoveDown(DataGridView dataGridView)
        {
            if (dataGridView.RowCount > 0)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int rowCount = dataGridView.Rows.Count;

                    int firstIndex = dataGridView.SelectedRows.Cast<DataGridViewRow>().Min(x => x.Index);
                    int lastIndex = dataGridView.SelectedRows.Cast<DataGridViewRow>().Max(x => x.Index);

                    if (lastIndex + 1 < rowCount)
                    {
                        var dataTable = (DataTable)dataGridView.DataSource;
                        if (dataTable != null)
                        {
                            MoveDataRowTo(dataTable.Rows[lastIndex + 1], firstIndex);
                        }
                    }
                }
            }
        }

        public static void MoveDataRowTo(DataRow dataRow, int destination)
        {
            DataTable parentTable = dataRow.Table;
            int rowIndex = parentTable.Rows.IndexOf(dataRow);

            if (rowIndex >= 0)
            {
                DataRow newDataRow = parentTable.NewRow();

                for (int index = 0; index < dataRow.ItemArray.Length; index++)
                    newDataRow[index] = dataRow[index];

                parentTable.Rows.Remove(dataRow);
                parentTable.Rows.InsertAt(newDataRow, destination);
            }
        }
        #endregion
    }
}
