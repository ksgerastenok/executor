using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace AutoRun
{
    public partial class Settings : Form
    {
        private Int32 code;
        private static Settings instance;

        static Settings()
        {
            Settings.instance = new Settings();

            return;
        }

        private Settings()
        {
            this.InitializeComponent();

            return;
        }

        public static Settings Instance
        {
            get
            {
                return Settings.instance;
            }
        }

        private void Settings_Load(Object sender, EventArgs e)
        {
            this.code = 0;
            this.ProcessSettings("load");
            this.btnSave.Enabled = ((!((this.tbidMega.Text == String.Empty) || (this.tbHost.Text == String.Empty) || (this.tbPort.Text == String.Empty) || (this.tbService.Text == String.Empty) || (this.tbLogin.Text == String.Empty) || (this.tbPassword.Text == String.Empty))) && (!((this.code == 0) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.dbHost) && (this.tbPort.Text == Properties.Settings.Default.dbPort) && (this.tbService.Text == Properties.Settings.Default.dbService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword))))) && (!((this.code == 1) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.srvHost) && (this.tbPort.Text == Properties.Settings.Default.srvPort) && (this.tbService.Text == Properties.Settings.Default.srvService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword))))));

            return;
        }

        private void btnSave_Click(Object sender, EventArgs e)
        {
            this.code = ((this.code + 0) % 2);
            this.ProcessSettings("save");
            this.btnSave.Enabled = ((!((this.tbidMega.Text == String.Empty) || (this.tbHost.Text == String.Empty) || (this.tbPort.Text == String.Empty) || (this.tbService.Text == String.Empty) || (this.tbLogin.Text == String.Empty) || (this.tbPassword.Text == String.Empty))) && (!((this.code == 0) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.dbHost) && (this.tbPort.Text == Properties.Settings.Default.dbPort) && (this.tbService.Text == Properties.Settings.Default.dbService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword))))) && (!((this.code == 1) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.srvHost) && (this.tbPort.Text == Properties.Settings.Default.srvPort) && (this.tbService.Text == Properties.Settings.Default.srvService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword))))));

            return;
        }

        private void btnNext_Click(Object sender, EventArgs e)
        {
            this.code = ((this.code + 1) % 2);
            this.ProcessSettings("load");
            this.btnSave.Enabled = ((!((this.tbidMega.Text == String.Empty) || (this.tbHost.Text == String.Empty) || (this.tbPort.Text == String.Empty) || (this.tbService.Text == String.Empty) || (this.tbLogin.Text == String.Empty) || (this.tbPassword.Text == String.Empty))) && (!((this.code == 0) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.dbHost) && (this.tbPort.Text == Properties.Settings.Default.dbPort) && (this.tbService.Text == Properties.Settings.Default.dbService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword))))) && (!((this.code == 1) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.srvHost) && (this.tbPort.Text == Properties.Settings.Default.srvPort) && (this.tbService.Text == Properties.Settings.Default.srvService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword))))));

            return;
        }

        private void btnClose_Click(Object sender, EventArgs e)
        {
            this.Close();

            return;
        }

        private void tbCommon_TextChanged(Object sender, EventArgs e)
        {
            this.btnSave.Enabled = ((!((this.tbidMega.Text == String.Empty) || (this.tbHost.Text == String.Empty) || (this.tbPort.Text == String.Empty) || (this.tbService.Text == String.Empty) || (this.tbLogin.Text == String.Empty) || (this.tbPassword.Text == String.Empty))) && (!((this.code == 0) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.dbHost) && (this.tbPort.Text == Properties.Settings.Default.dbPort) && (this.tbService.Text == Properties.Settings.Default.dbService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword))))) && (!((this.code == 1) && ((this.tbidMega.Text == Properties.Settings.Default.idMega) && (this.tbHost.Text == Properties.Settings.Default.srvHost) && (this.tbPort.Text == Properties.Settings.Default.srvPort) && (this.tbService.Text == Properties.Settings.Default.srvService) && (this.tbLogin.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin)) && (this.tbPassword.Text == CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword))))));

            return;
        }

        private void ProcessSettings(String action)
        {
            switch (this.code)
            {
                case 0:
                {
                    switch (action)
                    {
                        case "load":
                        {
                            Properties.Settings.Default.Reload();
                            this.tbidMega.Text = Properties.Settings.Default.idMega;
                            this.tbHost.Text = Properties.Settings.Default.dbHost;
                            this.tbPort.Text = Properties.Settings.Default.dbPort;
                            this.tbService.Text = Properties.Settings.Default.dbService;
                            this.tbLogin.Text = CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin);
                            this.tbPassword.Text = CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword);
                        }
                        break;
                        case "save":
                        {
                            Properties.Settings.Default.idMega = this.tbidMega.Text;
                            Properties.Settings.Default.dbHost = this.tbHost.Text;
                            Properties.Settings.Default.dbPort = this.tbPort.Text;
                            Properties.Settings.Default.dbService = this.tbService.Text;
                            Properties.Settings.Default.dbLogin = CRYUtil.Instance.Encrypt(this.tbLogin.Text);
                            Properties.Settings.Default.dbPassword = CRYUtil.Instance.Encrypt(this.tbPassword.Text);
                            Properties.Settings.Default.Save();
                        }
                        break;
                        default:
                        {
                            if ((!(String.Format("{0}", "Некорректное значение параметра") == String.Empty)))
                            {
                                throw new Exception(String.Format("{0}", "Некорректное значение параметра"));
                            }
                        }
                        break;
                    }
                    this.btnNext.Text = String.Format("{0}", "Service >>");
                    this.gbSettings.Text = String.Format("{0}", "Database");
                    this.tbPort.ReadOnly = false;
                    this.tbService.ReadOnly = false;
                }
                break;
                case 1:
                {
                    switch (action)
                    {
                        case "load":
                        {
                            Properties.Settings.Default.Reload();
                            this.tbidMega.Text = Properties.Settings.Default.idMega;
                            this.tbHost.Text = Properties.Settings.Default.srvHost;
                            this.tbPort.Text = Properties.Settings.Default.srvPort;
                            this.tbService.Text = Properties.Settings.Default.srvService;
                            this.tbLogin.Text = CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin);
                            this.tbPassword.Text = CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword);
                        }
                        break;
                        case "save":
                        {
                            Properties.Settings.Default.idMega = this.tbidMega.Text;
                            Properties.Settings.Default.srvHost = this.tbHost.Text;
                            Properties.Settings.Default.srvPort = this.tbPort.Text;
                            Properties.Settings.Default.srvService = this.tbService.Text;
                            Properties.Settings.Default.srvLogin = CRYUtil.Instance.Encrypt(this.tbLogin.Text);
                            Properties.Settings.Default.srvPassword = CRYUtil.Instance.Encrypt(this.tbPassword.Text);
                            Properties.Settings.Default.Save();
                        }
                        break;
                        default:
                        {
                            if ((!(String.Format("{0}", "Некорректное значение параметра") == String.Empty)))
                            {
                                throw new Exception(String.Format("{0}", "Некорректное значение параметра"));
                            }
                        }
                        break;
                    }
                    this.btnNext.Text = String.Format("{0}", "<< Database");
                    this.gbSettings.Text = String.Format("{0}", "Service");
                    this.tbPort.ReadOnly = true;
                    this.tbService.ReadOnly = true;
                }
                break;
                default:
                {
                    if ((!(String.Format("{0}", "Некорректное значение параметра") == String.Empty)))
                    {
                        throw new Exception(String.Format("{0}", "Некорректное значение параметра"));
                    }
                }
                break;
            }

            return;
        }
    }
}
