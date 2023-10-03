using GrupoLeyLoginForm.Properties;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace GrupoLeyLoginForm
{
    public partial class MainForm : Form
    {
        #region Global
        string? identifier = "";

        readonly ErrorProvider errorProvider = new();

        public MainForm()
        {
            InitializeComponent();
            ReadConfigFile();
            SetConfigData();

            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
#if !DEBUG
            chKiosk.Visible = principal.IsInRole(WindowsBuiltInRole.Administrator);
            lblIdentifier.Visible = principal.IsInRole(WindowsBuiltInRole.Administrator);
            btn_config.Visible = principal.IsInRole(WindowsBuiltInRole.Administrator);
#else
            lblEmployeeName.Text = "Está en debug";
#endif
        }
        #endregion

        #region ConfigFile
        public static void ReadConfigFile()
        {
            int counter = 0;
            foreach (string line in File.ReadLines(@"config.ini"))
            {
                string propertyName = counter switch
                {
                    0 => "LoginUrl",
                    1 => "Database",
                    2 => "DefaultBrowser",
                    3 => "NetworkInterface",
                    4 => "AutoCompleteLogins",
                    5 => "AutoCompleteCredentials",
                    6 => "Devices",
                    _ => "",
                };
                if (!string.IsNullOrEmpty(propertyName))
                {
                    Settings.Default[propertyName] = line;
                }
                counter++;
            }
            Settings.Default.Save();
        }
        public void SetConfigData()
        {
            identifier = GetIdentifier(Settings.Default.NetworkInterface);
            if (!string.IsNullOrEmpty(Settings.Default.NetworkInterface))
            {
                lblIdentifier.Text = Settings.Default.NetworkInterface;
                txtIdentifier.Text = identifier;
            }
            else
            {
                txtIdentifier.Text = identifier;
            }

            if (Settings.Default.LoginUrl == null)
            {
                MessageBox.Show("No hay URL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Settings.Default.Database == null)
            {
                MessageBox.Show("No hay Base de datos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Settings.Default.DefaultBrowser != null)
            {
                btnLogin.Image = Settings.Default.DefaultBrowser switch
                {
                    "Edge" => Resources.edge_logo,
                    "Chrome" => Resources.chrome_logo,
                    "Firefox" => Resources.firefox_logo,
                    _ => Resources.edge_logo,
                };
                btnLogin.Image = null;
            }
            if (Settings.Default.AutoCompleteLogins != null)
            {
                txtLogin.AutoCompleteCustomSource = new AutoCompleteStringCollection();

                string auto_complete_logins = Settings.Default.AutoCompleteLogins;
                var logins = auto_complete_logins.Split(";");

                foreach (var item in logins)
                {
                    txtLogin.AutoCompleteCustomSource.Add(item);
                }
            }
            if (Settings.Default.AutoCompleteCredentials != null)
            {
                txtCredential.AutoCompleteCustomSource = new AutoCompleteStringCollection();

                string auto_complete_credentials = Settings.Default.AutoCompleteCredentials;
                var credentials = auto_complete_credentials.Split(";");

                foreach (var credential in credentials)
                {
                    txtCredential.AutoCompleteCustomSource.Add(credential);
                }
            }
        }
        #endregion

        #region Identifier
        public static string? GetIdentifier(string? interface_name)
        {
            var network_interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in network_interfaces)
            {
                if (nic.OperationalStatus == OperationalStatus.Up
                    && (string.IsNullOrEmpty(interface_name) || nic.Name == interface_name))
                {
                    return AddressBytesToString(nic.GetPhysicalAddress().GetAddressBytes());
                }
            }

            return string.Empty;
        }

        private static string AddressBytesToString(byte[] addressBytes)
        {
            return string.Join(":", (from b in addressBytes select b.ToString("X2")).ToArray());
        }
        #endregion

        #region LoginButton
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                DoSelenimLogin();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DoSelenimLogin();
        }

        private async void DoSelenimLogin()
        {
            if (ValidateChildren(ValidationConstraints.Enabled) && GetIsValid())
            {
                if (await PreLogin() == true)
                {
                    List<string> arguments = new()
                    {
                        "--profile-directory=Default",
                        "--use-system-default-printer"
                    };
                    if (chKiosk.Checked)
                    {
                        arguments.Add("--kiosk-printing");
                    }
                    switch (Settings.Default.DefaultBrowser)
                    {
                        case "Edge":
                            new DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                            EdgeOptions edge_options = new();
                            arguments.Add("--remote-allow-origins=*");
                            edge_options.AddArguments(arguments);
                            SeleniumLogin(new EdgeDriver(edge_options));
                            break;
                        case "Chrome":
                            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                            ChromeOptions chrome_options = new();
                            chrome_options.AddArguments(arguments);
                            SeleniumLogin(new ChromeDriver(chrome_options));
                            break;
                        case "Firefox":
                            new DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                            FirefoxOptions firefox_options = new();
                            firefox_options.AddArguments(arguments);
                            SeleniumLogin(new FirefoxDriver(firefox_options));
                            break;
                        default:
                            SeleniumLogin(new EdgeDriver());
                            break;
                    }
                }
            }
        }
        #endregion

        #region PreLogin
        private async Task<bool> PreLogin()
        {
            lblMessage.Text = "¡Cargando!";
            lblEmployeeName.Text = "Empleado";

            var odooRequest = new OdooRequest<OdooParamsPreAuthenticate>
            {
                Params = new()
                {
                    Db = Settings.Default.Database,
                    Login = txtLogin.Text,
                    Password = txtPassword.Text,
                    Credential = txtCredential.Text,
                    Nip = txtNip.Text,
                    Identifier = identifier
                }
            };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var data = JsonConvert.SerializeObject(odooRequest, serializerSettings);

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(Settings.Default.LoginUrl);

                HttpContent body = new StringContent(data, Encoding.UTF8, "application/json");

                var response = client.PostAsync("/web/session/pre_authenticate", body).Result;

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var odooResponse = JsonConvert.DeserializeObject<OdooResponse<OdooResultPreAuthenticate>>(content);

                        if (odooResponse != null)
                        {
                            if (odooResponse.Error != null)
                            {
                                lblMessage.Text = odooResponse.Error.Data?.Message;
                                lblMessage.ForeColor = Color.PaleVioletRed;
                                return false;
                            }
                            else if (odooResponse.Result != null)
                            {
                                if (!string.IsNullOrEmpty(odooResponse.Result.Employee_name))
                                {
                                    lblEmployeeName.Text = odooResponse.Result.Employee_name;
                                }
                                else
                                {
                                    lblEmployeeName.Text = "Empleado";
                                }

                                if (odooResponse.Result.Log_id == 0)
                                {
                                    return false;
                                }

                                if (odooResponse.Result.Success)
                                {
                                    return true;
                                }
                                else
                                {
                                    lblMessage.Text = odooResponse.Result.Message;
                                    lblMessage.ForeColor = Color.PaleVioletRed;
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "¡Error!";
                lblMessage.ForeColor = Color.PaleVioletRed;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            lblMessage.Text = "¡Algo salió mal!";
            lblMessage.ForeColor = Color.PaleVioletRed;
            return false;
        }
        #endregion

        #region SeleniumLogin
        private void SeleniumLogin(WebDriver driver)
        {
            try
            {
                string login = txtLogin.Text;
                string password = txtPassword.Text;
                string credential = txtCredential.Text;
                string nip = txtNip.Text;

                var server = new Uri(Settings.Default.LoginUrl);
                var url = new Uri(server, "/web/custom_login_page");
                //string url = Settings.Default.LoginUrl + "/web/custom_login_page";
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);

                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(3));

                wait.Until(e => e.FindElement(By.Id("db"))).Clear();
                driver.FindElement(By.Id("db")).SendKeys(Settings.Default.Database);

                driver.FindElement(By.Id("login")).SendKeys(login);
                driver.FindElement(By.Id("password")).SendKeys(password);

                wait.Until(e => e.FindElement(By.Id("credential"))).SendKeys(credential);
                wait.Until(e => e.FindElement(By.Id("nip"))).SendKeys(nip);

                wait.Until(e => e.FindElement(By.Id("identifier"))).SendKeys(identifier);
                wait.Until(e => e.FindElement(By.Id("devices"))).SendKeys(Settings.Default.Devices.ToString());

                driver.FindElement(By.TagName("form")).Submit();

                //var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                //wait.Until(wt => wt.FindElement(By.Id("")));
                //driver.Close();
                //driver.Dispose();
                lblMessage.Text = "¡Correcto! " + DateTime.Now;
                lblMessage.ForeColor = Color.LightSeaGreen;
#if !DEBUG
                Close();
#endif
            }
            catch (Exception ex)
            {
                lblMessage.Text = "¡Error!";
                lblMessage.ForeColor = Color.PaleVioletRed;
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Validations
        private bool GetIsValid()
        {
            lblMessage.ForeColor = Color.IndianRed;

            return
                !string.IsNullOrEmpty(txtLogin.Text)
                && !string.IsNullOrEmpty(txtPassword.Text)
                && !string.IsNullOrEmpty(txtCredential.Text)
                && !string.IsNullOrEmpty(txtNip.Text);
        }
        private void txtLogin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var txtObject = (TextBox)sender;

            if (string.IsNullOrEmpty(txtObject.Text))
            {
                //txtObject.Focus();
                errorProvider.SetError(txtObject, "¡Por favor ingrese el valor: " + txtObject.AccessibleName + "!");
            }
            else
            {
                errorProvider.SetError(txtObject, null);
            }
        }
        #endregion

        #region Extra Buttons

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm config = new();
            config.ShowDialog();
        }

        private void btnViewPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnViewPassword.ForeColor = txtPassword.UseSystemPasswordChar ? Color.DimGray : Color.Teal;
        }

        private void btnViewNip_Click(object sender, EventArgs e)
        {
            txtNip.UseSystemPasswordChar = !txtNip.UseSystemPasswordChar;
            btnViewNip.ForeColor = txtNip.UseSystemPasswordChar ? Color.DimGray : Color.Teal;
        }
        #endregion

        private void lblVersion_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}