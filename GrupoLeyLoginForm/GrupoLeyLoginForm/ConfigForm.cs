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

        public MainForm? MainForm { get; set; }

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
                sw.WriteLine("[]");
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
    }
}
