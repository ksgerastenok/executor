using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace AutoRun
{
    public partial class Settings : Object
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components;
        private Form frmMain;
        private Label lblHost;
        private Label lblPort;
        private Label lblLogin;
        private Label lblidMega;
        private Label lblService;
        private Label lblPassword;
        private Button btnSave;
        private Button btnNext;
        private Button btnClose;
        private TextBox tbHost;
        private TextBox tbPort;
        private TextBox tbLogin;
        private TextBox tbidMega;
        private TextBox tbService;
        private TextBox tbPassword;
        private GroupBox gbControl;
        private GroupBox gbSettings;

        /// <summary>
        /// Конструктор.
        /// </summary>
        private Settings()
        {
            this.InitializeComponent();

            return;
        }

        /// <summary>
        /// Получить форму.
        /// </summary>
        private Form MainForm
        {
            get
            {
                return this.frmMain;
            }
        }

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        private void Settings_Disposed(Object sender, EventArgs e)
        {
            this.components.Dispose();
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            //
            // components
            //
            this.components = new Container();
            //
            // tbidMega
            //
            this.tbidMega = new TextBox();
            this.tbidMega.Location = new Point(216, 49);
            this.tbidMega.Name = "tbidMega";
            this.tbidMega.Size = new Size(75, 20);
            this.tbidMega.TabIndex = 2;
            this.tbidMega.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            //
            // lblidMega
            //
            this.lblidMega = new Label();
            this.lblidMega.AutoSize = true;
            this.lblidMega.Location = new Point(165, 52);
            this.lblidMega.Name = "lblidMega";
            this.lblidMega.Size = new Size(45, 13);
            this.lblidMega.TabIndex = 10;
            this.lblidMega.Text = "idMega:";
            //
            // tbPassword
            //
            this.tbPassword = new TextBox();
            this.tbPassword.Location = new Point(68, 126);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new Size(223, 20);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            //
            // lblPassword
            //
            this.lblPassword = new Label();
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(6, 129);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(56, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            //
            // tbLogin
            //
            this.tbLogin = new TextBox();
            this.tbLogin.Location = new Point(68, 100);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new Size(223, 20);
            this.tbLogin.TabIndex = 4;
            this.tbLogin.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            //
            // lblLogin
            //
            this.lblLogin = new Label();
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new Point(6, 103);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new Size(36, 13);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Login:";
            //
            // tbPort
            //
            this.tbPort = new TextBox();
            this.tbPort.Location = new Point(68, 49);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new Size(70, 20);
            this.tbPort.TabIndex = 1;
            this.tbPort.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            //
            // tbService
            //
            this.tbService = new TextBox();
            this.tbService.Location = new Point(68, 75);
            this.tbService.Name = "tbService";
            this.tbService.Size = new Size(223, 20);
            this.tbService.TabIndex = 3;
            this.tbService.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            //
            // tbHost
            //
            this.tbHost = new TextBox();
            this.tbHost.Location = new Point(68, 23);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new Size(223, 20);
            this.tbHost.TabIndex = 0;
            this.tbHost.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            //
            // lblService
            //
            this.lblService = new Label();
            this.lblService.AutoSize = true;
            this.lblService.Location = new Point(6, 78);
            this.lblService.Name = "lblService";
            this.lblService.Size = new Size(46, 13);
            this.lblService.TabIndex = 2;
            this.lblService.Text = "Service:";
            //
            // lblPort
            //
            this.lblPort = new Label();
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new Point(6, 52);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new Size(29, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port:";
            //
            // lblHost
            //
            this.lblHost = new Label();
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new Point(6, 26);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new Size(32, 13);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host:";
            //
            // btnSave
            //
            this.btnSave = new Button();
            this.btnSave.Location = new Point(107, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(88, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            //
            // btnClose
            //
            this.btnClose = new Button();
            this.btnClose.DialogResult = DialogResult.Cancel;
            this.btnClose.Location = new Point(9, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(92, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            //
            // btnNext
            //
            this.btnNext = new Button();
            this.btnNext.Location = new Point(201, 22);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new Size(90, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Service >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new EventHandler(this.btnNext_Click);
            //
            // gbControl
            //
            this.gbControl = new GroupBox();
            this.gbControl.Controls.Add(this.btnClose);
            this.gbControl.Controls.Add(this.btnNext);
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new Point(2, 176);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new Size(297, 51);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Действия";
            this.gbControl.SuspendLayout();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            //
            // gbSettings
            //
            this.gbSettings = new GroupBox();
            this.gbSettings.Controls.Add(this.tbidMega);
            this.gbSettings.Controls.Add(this.lblidMega);
            this.gbSettings.Controls.Add(this.tbPassword);
            this.gbSettings.Controls.Add(this.lblPassword);
            this.gbSettings.Controls.Add(this.tbLogin);
            this.gbSettings.Controls.Add(this.lblLogin);
            this.gbSettings.Controls.Add(this.tbPort);
            this.gbSettings.Controls.Add(this.tbService);
            this.gbSettings.Controls.Add(this.tbHost);
            this.gbSettings.Controls.Add(this.lblService);
            this.gbSettings.Controls.Add(this.lblPort);
            this.gbSettings.Controls.Add(this.lblHost);
            this.gbSettings.Location = new Point(2, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new Size(297, 158);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Database";
            this.gbSettings.SuspendLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            //
            // Settings
            //
            this.frmMain = new Form();
            this.frmMain.AutoScaleDimensions = new SizeF(6F, 13F);
            this.frmMain.AutoScaleMode = AutoScaleMode.Font;
            this.frmMain.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.frmMain.ClientSize = new Size(301, 229);
            this.frmMain.Controls.Add(this.gbControl);
            this.frmMain.Controls.Add(this.gbSettings);
            this.frmMain.MaximizeBox = false;
            this.frmMain.MinimizeBox = false;
            this.frmMain.Name = "Settings";
            this.frmMain.ShowIcon = false;
            this.frmMain.ShowInTaskbar = false;
            this.frmMain.StartPosition = FormStartPosition.CenterParent;
            this.frmMain.Text = "Настройки";
            this.frmMain.Load += new EventHandler(this.Settings_Load);
            this.frmMain.Disposed += new EventHandler(this.Settings_Disposed);
            this.frmMain.SuspendLayout();
            this.frmMain.ResumeLayout(false);
            this.frmMain.PerformLayout();

            return;
        }

        #endregion
    }
}
