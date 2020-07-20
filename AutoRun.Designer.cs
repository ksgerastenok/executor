using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace AutoRun
{
    public partial class AutoRun : Object
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private IContainer components;
        private Form frmMain;
        private Timer timer;
        private Label lblEnd;
        private Label lblCount;
        private Label lblError;
        private Label lblLists;
        private Label lblNormal;
        private Label lblInterval;
        private Button btnExecute;
        private Button btnRefresh;
        private Button btnClearLog;
        private Button btnSettings;
        private CheckBox cbAutoExec;
        private GroupBox gbLog;
        private GroupBox gbType;
        private GroupBox gbLists;
        private GroupBox gbControl;
        private GroupBox gbSettings;
        private RadioButton rbEnd;
        private RadioButton rbCount;
        private RadioButton rbError;
        private RadioButton rbLists;
        private RadioButton rbNormal;
        private RichTextBox rtbLog;
        private StatusStrip ssStatus;
        private DataGridView dgvLists;
        private NumericUpDown numCount;
        private NumericUpDown numLists;
        private NumericUpDown numTimer;
        private ToolStripProgressBar pbProgress;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblComment;
        private ToolStripStatusLabel lblProgress;
        private DataGridViewTextBoxColumn dgvCNTNew;
        private DataGridViewTextBoxColumn dgvWRKEnd;
        private DataGridViewTextBoxColumn dgvLSTType;
        private DataGridViewTextBoxColumn dgvWRKError;
        private DataGridViewTextBoxColumn dgvCNTPartial;
        private DataGridViewTextBoxColumn dgvCNTProcess;
        private DataGridViewTextBoxColumn dgvCNTTerminate;
        private DataGridViewTextBoxColumn dgvWRKNormal;
        private DataGridViewCheckBoxColumn dgvCheck;
        private BackgroundWorker bgWorker;

        /// <summary>
        /// Конструктор.
        /// </summary>
        private AutoRun()
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
        private void AutoRun_Disposed(Object sender, EventArgs e)
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
            // timer
            //
            this.timer = new Timer(this.components);
            this.timer.Interval = 10000;
            this.timer.Tick += new EventHandler(this.timer_Tick);
            //
            // lblLists
            //
            this.lblLists = new Label();
            this.lblLists.AutoSize = true;
            this.lblLists.Size = new Size(78, 13);
            this.lblLists.Location = new Point(6, 21);
            this.lblLists.TabIndex = 19;
            this.lblLists.Name = "lblLists";
            this.lblLists.Text = "Списков (шт.):";
            //
            // lblInterval
            //
            this.lblInterval = new Label();
            this.lblInterval.AutoSize = true;
            this.lblInterval.Size = new Size(99, 13);
            this.lblInterval.Location = new Point(6, 81);
            this.lblInterval.TabIndex = 21;
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Text = "Автозапуск (сек.):";
            //
            // btnExecute
            //
            this.btnExecute = new Button();
            this.btnExecute.Size = new Size(285, 30);
            this.btnExecute.Location = new Point(6, 19);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Text = "Запустить";
            this.btnExecute.Click += new EventHandler(this.btnExecute_Click);
            //
            // btnClearLog
            //
            this.btnClearLog = new Button();
            this.btnClearLog.Size = new Size(708, 30);
            this.btnClearLog.Location = new Point(6, 187);
            this.btnClearLog.TabIndex = 0;
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Text = "Очистить";
            this.btnClearLog.Click += new EventHandler(this.btnClearLog_Click);
            //
            // lblError
            //
            this.lblError = new Label();
            this.lblError.AutoSize = true;
            this.lblError.Size = new Size(58, 13);
            this.lblError.Location = new Point(6, 85);
            this.lblError.TabIndex = 2;
            this.lblError.Name = "lblError";
            this.lblError.Text = "В ошибки:";
            //
            // lblEnd
            //
            this.lblEnd = new Label();
            this.lblEnd.AutoSize = true;
            this.lblEnd.Size = new Size(58, 13);
            this.lblEnd.Location = new Point(6, 51);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Text = "До конца:";
            //
            // lblNormal
            //
            this.lblNormal = new Label();
            this.lblNormal.AutoSize = true;
            this.lblNormal.Size = new Size(74, 13);
            this.lblNormal.Location = new Point(6, 18);
            this.lblNormal.TabIndex = 2;
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Text = "Нормальная:";
            //
            // rbNormal
            //
            this.rbNormal = new RadioButton();
            this.rbNormal.AutoSize = true;
            this.rbNormal.Checked = true;
            this.rbNormal.Size = new Size(14, 13);
            this.rbNormal.Location = new Point(110, 18);
            this.rbNormal.TabStop = true;
            this.rbNormal.TabIndex = 0;
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.CheckedChanged += new EventHandler(this.rbCommon_CheckedChanged);
            //
            // rbEnd
            //
            this.rbEnd = new RadioButton();
            this.rbEnd.AutoSize = true;
            this.rbEnd.Size = new Size(14, 13);
            this.rbEnd.Location = new Point(110, 51);
            this.rbEnd.TabStop = true;
            this.rbEnd.TabIndex = 1;
            this.rbEnd.UseVisualStyleBackColor = true;
            this.rbEnd.Name = "rbEnd";
            this.rbEnd.CheckedChanged += new EventHandler(this.rbCommon_CheckedChanged);
            //
            // rbError
            //
            this.rbError = new RadioButton();
            this.rbError.AutoSize = true;
            this.rbError.Size = new Size(14, 13);
            this.rbError.Location = new Point(110, 85);
            this.rbError.TabStop = true;
            this.rbError.TabIndex = 2;
            this.rbError.UseVisualStyleBackColor = true;
            this.rbError.Name = "rbError";
            this.rbError.CheckedChanged += new EventHandler(this.rbCommon_CheckedChanged);
            //
            // gbLog
            //
            this.gbLog = new GroupBox();
            this.gbLog.SuspendLayout();
            this.gbLog.Controls.Add(this.rtbLog);
            this.gbLog.Controls.Add(this.btnClearLog);
            this.gbLog.Size = new Size(720, 220);
            this.gbLog.Location = new Point(201, 12);
            this.gbLog.TabStop = false;
            this.gbLog.TabIndex = 3;
            this.gbLog.Name = "gbLog";
            this.gbLog.Text = "Протокол";
            this.gbLog.ResumeLayout(false);
            this.gbLog.PerformLayout();
            //
            // rtbLog
            //
            this.rtbLog = new RichTextBox();
            this.rtbLog.Size = new Size(708, 169);
            this.rtbLog.Location = new Point(6, 15);
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            this.rtbLog.TabIndex = 1;
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Text = String.Empty;
            //
            // numCount
            //
            this.numCount = new NumericUpDown();
            this.numCount.BeginInit();
            this.numCount.Minimum = 5;
            this.numCount.Maximum = 750;
            this.numCount.Increment = 5;
            this.numCount.Value = 50;
            this.numCount.Size = new Size(45, 20);
            this.numCount.Location = new Point(141, 49);
            this.numCount.ReadOnly = true;
            this.numCount.TabIndex = 3;
            this.numCount.TextAlign = HorizontalAlignment.Right;
            this.numCount.Name = "numCount";
            this.numCount.ValueChanged += new EventHandler(this.numCommon_ValueChanged);
            this.numCount.EndInit();
            //
            // rbCount
            //
            this.rbCount = new RadioButton();
            this.rbCount.AutoSize = true;
            this.rbCount.Size = new Size(14, 13);
            this.rbCount.Location = new Point(110, 51);
            this.rbCount.TabIndex = 2;
            this.rbCount.UseVisualStyleBackColor = true;
            this.rbCount.Name = "rbCount";
            //
            // lblCount
            //
            this.lblCount = new Label();
            this.lblCount.AutoSize = true;
            this.lblCount.Size = new Size(71, 13);
            this.lblCount.Location = new Point(6, 51);
            this.lblCount.TabIndex = 10;
            this.lblCount.Name = "lblCount";
            this.lblCount.Text = "Строк (тыс.):";
            //
            // rbLists
            //
            this.rbLists = new RadioButton();
            this.rbLists.Checked = true;
            this.rbLists.AutoSize = true;
            this.rbLists.Size = new Size(14, 13);
            this.rbLists.Location = new Point(110, 21);
            this.rbLists.TabStop = true;
            this.rbLists.TabIndex = 0;
            this.rbLists.UseVisualStyleBackColor = true;
            this.rbLists.Name = "rbLists";
            this.rbLists.CheckedChanged += new EventHandler(this.rbCommon_CheckedChanged);
            //
            // cbAutoExec
            //
            this.cbAutoExec = new CheckBox();
            this.cbAutoExec.AutoSize = true;
            this.cbAutoExec.Size = new Size(15, 14);
            this.cbAutoExec.Location = new Point(110, 81);
            this.cbAutoExec.TabIndex = 4;
            this.cbAutoExec.UseVisualStyleBackColor = true;
            this.cbAutoExec.Name = "cbAutoExec";
            this.cbAutoExec.CheckedChanged += new EventHandler(this.cbAutoExec_CheckedChanged);
            //
            // numLists
            //
            this.numLists = new NumericUpDown();
            this.numLists.BeginInit();
            this.numLists.Minimum = 5;
            this.numLists.Maximum = 350;
            this.numLists.Increment = 5;
            this.numLists.Value = 75;
            this.numLists.Size = new Size(45, 20);
            this.numLists.Location = new Point(141, 19);
            this.numLists.ReadOnly = true;
            this.numLists.TabIndex = 1;
            this.numLists.TextAlign = HorizontalAlignment.Right;
            this.numLists.Name = "numLists";
            this.numLists.ValueChanged += new EventHandler(this.numCommon_ValueChanged);
            this.numLists.EndInit();
            //
            // numTimer
            //
            this.numTimer = new NumericUpDown();
            this.numTimer.BeginInit();
            this.numTimer.Minimum = 5;
            this.numTimer.Maximum = 300;
            this.numTimer.Increment = 5;
            this.numTimer.Value = 25;
            this.numTimer.Size = new Size(45, 20);
            this.numTimer.Location = new Point(141, 79);
            this.numTimer.ReadOnly = true;
            this.numTimer.TabIndex = 5;
            this.numTimer.TextAlign = HorizontalAlignment.Right;
            this.numTimer.Name = "numTimer";
            this.numTimer.ValueChanged += new EventHandler(this.numCommon_ValueChanged);
            this.numTimer.EndInit();
            //
            // btnSettings
            //
            this.btnSettings = new Button();
            this.btnSettings.Size = new Size(286, 30);
            this.btnSettings.Location = new Point(626, 19);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Text = "Настройки";
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);
            //
            // bgWorker
            //
            this.bgWorker = new BackgroundWorker();
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            //
            // dgvCheck
            //
            this.dgvCheck = new DataGridViewCheckBoxColumn();
            this.dgvCheck.Resizable = DataGridViewTriState.True;
            this.dgvCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvCheck.Width = 68;
            this.dgvCheck.HeaderText = "Обработка";
            this.dgvCheck.Name = "dgvCheck";
            //
            // dgvLSTType
            //
            this.dgvLSTType = new DataGridViewTextBoxColumn();
            this.dgvLSTType.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvLSTType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvLSTType.HeaderText = "Тип списка";
            this.dgvLSTType.DataPropertyName = "LSTType";
            this.dgvLSTType.ReadOnly = true;
            this.dgvLSTType.Name = "dgvLSTType";
            //
            // dgvCNTNew
            //
            this.dgvCNTNew = new DataGridViewTextBoxColumn();
            this.dgvCNTNew.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvCNTNew.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvCNTNew.HeaderText = "Новые\n(списков / строк)";
            this.dgvCNTNew.DataPropertyName = "CNTNew";
            this.dgvCNTNew.ReadOnly = true;
            this.dgvCNTNew.Name = "dgvCNTNew";
            //
            // dgvCNTPartial
            //
            this.dgvCNTPartial = new DataGridViewTextBoxColumn();
            this.dgvCNTPartial.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvCNTPartial.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvCNTPartial.HeaderText = "Частичные\n(списков / строк)";
            this.dgvCNTPartial.DataPropertyName = "CNTPartial";
            this.dgvCNTPartial.ReadOnly = true;
            this.dgvCNTPartial.Name = "dgvCNTPartial";
            //
            // dgvCNTProcess
            //
            this.dgvCNTProcess = new DataGridViewTextBoxColumn();
            this.dgvCNTProcess.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvCNTProcess.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvCNTProcess.HeaderText = "Обрабатываются\n(списков / строк)";
            this.dgvCNTProcess.DataPropertyName = "CNTProcess";
            this.dgvCNTProcess.ReadOnly = true;
            this.dgvCNTProcess.Name = "dgvCNTProcess";
            //
            // dgvCNTTerminate
            //
            this.dgvCNTTerminate = new DataGridViewTextBoxColumn();
            this.dgvCNTTerminate.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvCNTTerminate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvCNTTerminate.HeaderText = "Прерванные\n(списков / строк)";
            this.dgvCNTTerminate.DataPropertyName = "CNTTerminate";
            this.dgvCNTTerminate.ReadOnly = true;
            this.dgvCNTTerminate.Name = "dgvCNTTerminate";
            //
            // dgvWRKNormal
            //
            this.dgvWRKNormal = new DataGridViewTextBoxColumn();
            this.dgvWRKNormal.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvWRKNormal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvWRKNormal.HeaderText = "В нормальную\n(списков / строк)";
            this.dgvWRKNormal.DataPropertyName = "WRKNormal";
            this.dgvWRKNormal.ReadOnly = true;
            this.dgvWRKNormal.Name = "dgvWRKNormal";
            //
            // dgvWRKEnd
            //
            this.dgvWRKEnd = new DataGridViewTextBoxColumn();
            this.dgvWRKEnd.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvWRKEnd.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvWRKEnd.HeaderText = "До конца\n(списков / строк)";
            this.dgvWRKEnd.DataPropertyName = "WRKEnd";
            this.dgvWRKEnd.ReadOnly = true;
            this.dgvWRKEnd.Name = "dgvWRKEnd";
            //
            // dgvWRKError
            //
            this.dgvWRKError = new DataGridViewTextBoxColumn();
            this.dgvWRKError.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dgvWRKError.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvWRKError.HeaderText = "В ошибки\n(списков / строк)";
            this.dgvWRKError.DataPropertyName = "WRKError";
            this.dgvWRKError.ReadOnly = true;
            this.dgvWRKError.Name = "dgvWRKError";
            //
            // gbLists
            //
            this.gbLists = new GroupBox();
            this.gbLists.SuspendLayout();            
            this.gbLists.Size = new Size(918, 238);
            this.gbLists.Location = new Point(3, 238);
            this.gbLists.Controls.Add(this.dgvLists);
            this.gbLists.TabIndex = 7;
            this.gbLists.TabStop = false;
            this.gbLists.Name = "gbLists";
            this.gbLists.Text = "Списки";
            this.gbLists.ResumeLayout(false);
            this.gbLists.PerformLayout();
            //
            // btnRefresh
            //
            this.btnRefresh = new Button();
            this.btnRefresh.Size = new Size(285, 30);
            this.btnRefresh.Location = new Point(316, 19);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            //
            // lblProgress
            //
            this.lblProgress = new ToolStripStatusLabel();
            this.lblProgress.Size = new Size(63, 17);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Text = "Прогресс:";
            //
            // pbProgress
            //
            this.pbProgress = new ToolStripProgressBar();
            this.pbProgress.AutoSize = false;
            this.pbProgress.Size = new Size(475, 16);
            this.pbProgress.Name = "pbProgress";
            //
            // lblStatus
            //
            this.lblStatus = new ToolStripStatusLabel();
            this.lblStatus.Size = new Size(46, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Статус:";
            //
            // lblComment
            //
            this.lblComment = new ToolStripStatusLabel();
            this.lblComment.Size = new Size(64, 17);
            this.lblComment.Name = "lblComment";
            this.lblComment.Text = "Ожидание";
            //
            // gbControl
            //
            this.gbControl = new GroupBox();
            this.gbControl.SuspendLayout();
            this.gbControl.Size = new Size(918, 53);
            this.gbControl.Location = new Point(3, 482);
            this.gbControl.Controls.Add(this.btnSettings);
            this.gbControl.Controls.Add(this.btnRefresh);
            this.gbControl.Controls.Add(this.btnExecute);
            this.gbControl.TabIndex = 2;
            this.gbControl.TabStop = false;
            this.gbControl.Name = "gbControl";
            this.gbControl.Text = "Действия";
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            //
            // gbType
            //
            this.gbType = new GroupBox();
            this.gbType.SuspendLayout();
            this.gbType.Controls.Add(this.lblError);
            this.gbType.Controls.Add(this.lblEnd);
            this.gbType.Controls.Add(this.lblNormal);
            this.gbType.Controls.Add(this.rbNormal);
            this.gbType.Controls.Add(this.rbEnd);
            this.gbType.Controls.Add(this.rbError);
            this.gbType.Size = new Size(190, 110);
            this.gbType.Location = new Point(3, 12);
            this.gbType.TabStop = false;
            this.gbType.TabIndex = 0;
            this.gbType.Name = "gbType";
            this.gbType.Text = "Режим";
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            //
            // gbSettings
            //
            this.gbSettings = new GroupBox();
            this.gbSettings.SuspendLayout();
            this.gbSettings.Size = new Size(190, 105);
            this.gbSettings.Location = new Point(3, 127);
            this.gbSettings.Controls.Add(this.rbCount);
            this.gbSettings.Controls.Add(this.rbLists);
            this.gbSettings.Controls.Add(this.cbAutoExec);
            this.gbSettings.Controls.Add(this.numCount);
            this.gbSettings.Controls.Add(this.numLists);
            this.gbSettings.Controls.Add(this.numTimer);
            this.gbSettings.Controls.Add(this.lblCount);
            this.gbSettings.Controls.Add(this.lblLists);
            this.gbSettings.Controls.Add(this.lblInterval);
            this.gbSettings.TabStop = false;
            this.gbSettings.TabIndex = 1;
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Text = "Настройки";
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            //
            // ssStatus
            //
            this.ssStatus = new StatusStrip();
            this.ssStatus.SuspendLayout();
            this.ssStatus.Size = new Size(924, 22);
            this.ssStatus.Location = new Point(0, 538);
            this.ssStatus.Items.Add(this.lblProgress);
            this.ssStatus.Items.Add(this.lblProgress);
            this.ssStatus.Items.Add(this.lblStatus);
            this.ssStatus.Items.Add(this.lblComment);
            this.ssStatus.Items.Add(this.pbProgress);
            this.ssStatus.TabIndex = 8;
            this.ssStatus.Name = "ssStatus";
            this.ssStatus.Text = "ssStatus";
            this.ssStatus.ResumeLayout(false);
            this.ssStatus.PerformLayout();
            //
            // dgvLists
            //
            this.dgvLists = new DataGridView();
            this.dgvLists.AllowUserToAddRows = false;
            this.dgvLists.AllowUserToDeleteRows = false;
            this.dgvLists.AllowUserToResizeRows = false;
            this.dgvLists.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            this.dgvLists.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLists.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            this.dgvLists.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvLists.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.WindowText;
            this.dgvLists.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            this.dgvLists.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            this.dgvLists.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLists.Columns.Add(this.dgvCheck);
            this.dgvLists.Columns.Add(this.dgvLSTType);
            this.dgvLists.Columns.Add(this.dgvCNTNew);
            this.dgvLists.Columns.Add(this.dgvCNTPartial);
            this.dgvLists.Columns.Add(this.dgvCNTProcess);
            this.dgvLists.Columns.Add(this.dgvCNTTerminate);
            this.dgvLists.Columns.Add(this.dgvWRKNormal);
            this.dgvLists.Columns.Add(this.dgvWRKEnd);
            this.dgvLists.Columns.Add(this.dgvWRKError);
            this.dgvLists.EditMode = DataGridViewEditMode.EditOnKeystroke;
            this.dgvLists.Size = new Size(906, 213);
            this.dgvLists.Location = new Point(6, 19);
            this.dgvLists.ShowRowErrors = false;
            this.dgvLists.ShowCellErrors = false;
            this.dgvLists.ShowEditingIcon = false;
            this.dgvLists.ShowCellToolTips = false;
            this.dgvLists.RowHeadersVisible = false;
            this.dgvLists.TabIndex = 6;
            this.dgvLists.Name = "dgvLists";
            this.dgvLists.CellContentClick += new DataGridViewCellEventHandler(this.dgvLists_CellContentClick);
            //
            // frmMain
            //
            this.frmMain = new Form();
            this.frmMain.ClientSize = new Size(924, 560);
            this.frmMain.Controls.Add(this.gbControl);
            this.frmMain.Controls.Add(this.gbLists);
            this.frmMain.Controls.Add(this.gbType);
            this.frmMain.Controls.Add(this.gbLog);
            this.frmMain.Controls.Add(this.gbSettings);
            this.frmMain.Controls.Add(this.ssStatus);
            this.frmMain.MaximizeBox = false;
            this.frmMain.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.frmMain.StartPosition = FormStartPosition.CenterScreen;
            this.frmMain.Name = "AutoRun";
            this.frmMain.Text = "Автоматическая обработка реестров";
            this.frmMain.Load += new EventHandler(this.AutoRun_Load);
            this.frmMain.Disposed += new EventHandler(this.AutoRun_Disposed);
            this.frmMain.ResumeLayout(false);
            this.frmMain.PerformLayout();
            this.frmMain.SuspendLayout();

            return;
        }

        #endregion
    }
}
