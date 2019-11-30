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
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components;

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
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(Boolean disposing)
        {
            if ((disposing) && (!(this.components == null)))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            this.gbSettings = new GroupBox();
            this.tbidMega = new TextBox();
            this.lblidMega = new Label();
            this.tbPassword = new TextBox();
            this.lblPassword = new Label();
            this.tbLogin = new TextBox();
            this.lblLogin = new Label();
            this.tbPort = new TextBox();
            this.tbService = new TextBox();
            this.tbHost = new TextBox();
            this.lblService = new Label();
            this.lblPort = new Label();
            this.lblHost = new Label();
            this.btnSave = new Button();
            this.btnClose = new Button();
            this.btnNext = new Button();
            this.gbControl = new GroupBox();
            this.gbSettings.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSettings
            // 
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
            // 
            // tbidMega
            // 
            this.tbidMega.Location = new Point(216, 49);
            this.tbidMega.Name = "tbidMega";
            this.tbidMega.Size = new Size(75, 20);
            this.tbidMega.TabIndex = 2;
            this.tbidMega.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            // 
            // lblidMega
            // 
            this.lblidMega.AutoSize = true;
            this.lblidMega.Location = new Point(165, 52);
            this.lblidMega.Name = "lblidMega";
            this.lblidMega.Size = new Size(45, 13);
            this.lblidMega.TabIndex = 10;
            this.lblidMega.Text = "idMega:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new Point(68, 126);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new Size(223, 20);
            this.tbPassword.TabIndex = 5;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(6, 129);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(56, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new Point(68, 100);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new Size(223, 20);
            this.tbLogin.TabIndex = 4;
            this.tbLogin.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new Point(6, 103);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new Size(36, 13);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Login:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new Point(68, 49);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new Size(70, 20);
            this.tbPort.TabIndex = 1;
            this.tbPort.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            // 
            // tbService
            // 
            this.tbService.Location = new Point(68, 75);
            this.tbService.Name = "tbService";
            this.tbService.Size = new Size(223, 20);
            this.tbService.TabIndex = 3;
            this.tbService.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            // 
            // tbHost
            // 
            this.tbHost.Location = new Point(68, 23);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new Size(223, 20);
            this.tbHost.TabIndex = 0;
            this.tbHost.TextChanged += new EventHandler(this.tbCommon_TextChanged);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new Point(6, 78);
            this.lblService.Name = "lblService";
            this.lblService.Size = new Size(46, 13);
            this.lblService.TabIndex = 2;
            this.lblService.Text = "Service:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new Point(6, 52);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new Size(29, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port:";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new Point(6, 26);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new Size(32, 13);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host:";
            // 
            // btnSave
            // 
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
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this.gbControl.Controls.Add(this.btnClose);
            this.gbControl.Controls.Add(this.btnNext);
            this.gbControl.Controls.Add(this.btnSave);
            this.gbControl.Location = new Point(2, 176);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new Size(297, 51);
            this.gbControl.TabIndex = 1;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Действия";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(301, 229);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Load += new EventHandler(this.Settings_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
