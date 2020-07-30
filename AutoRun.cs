using System;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace AutoRun
{
    public partial class AutoRun : Object
    {
        private Int32 code;
        private String message;
        private static AutoRun instance;

        static AutoRun()
        {
            AutoRun.instance = new AutoRun();

            return;
        }

        public static Form MainForm
        {
            get
            {
                return AutoRun.instance.MainForm;
            }
        }

        private void AutoRun_Load(Object sender, EventArgs e)
        {
            this.cbAutoExec.Checked = false;
            this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
            this.timer.Enabled = false;
            this.numLists.Enabled = this.rbLists.Checked;
            this.numCount.Enabled = this.rbCount.Checked;

            this.gbType.Enabled = false;
            this.gbLists.Enabled = false;
            this.gbSettings.Enabled = false;
            this.btnExecute.Enabled = false;
            this.btnRefresh.Enabled = ((!((Properties.Settings.Default.idMega == String.Empty) || (Properties.Settings.Default.dbHost == String.Empty) || (Properties.Settings.Default.dbPort == String.Empty) || (Properties.Settings.Default.dbService == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin) == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword) == String.Empty))) && (!((Properties.Settings.Default.idMega == String.Empty) || (Properties.Settings.Default.srvHost == String.Empty) || (Properties.Settings.Default.srvPort == String.Empty) || (Properties.Settings.Default.srvService == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin) == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword) == String.Empty))));
            this.btnSettings.Enabled = true;
            this.btnClearLog.Enabled = true;
            this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

            return;
        }

        private void btnClearLog_Click(Object sender, EventArgs e)
        {
            this.rtbLog.Clear();

            return;
        }

        private void btnRefresh_Click(Object sender, EventArgs e)
        {
            if ((!(this.bgWorker.IsBusy)))
            {
                this.code = 1;
                if ((this.code == 1))
                {
                    this.cbAutoExec.Checked = this.cbAutoExec.Checked;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = this.timer.Enabled;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.lblComment.Text = String.Format("{0}", "Ожидание");

                    this.gbType.Enabled = false;
                    this.gbLists.Enabled = false;
                    this.gbSettings.Enabled = false;
                    this.btnExecute.Enabled = false;
                    this.btnRefresh.Enabled = false;
                    this.btnSettings.Enabled = false;
                    this.btnClearLog.Enabled = false;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

                    this.bgWorker.RunWorkerAsync();
                }
            }
            else
            {
                this.code = this.code;
                if ((this.code == 1))
                {
                    this.cbAutoExec.Checked = this.cbAutoExec.Checked;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = this.timer.Enabled;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.lblComment.Text = String.Format("{0}", "Ожидание");

                    this.gbType.Enabled = false;
                    this.gbLists.Enabled = false;
                    this.gbSettings.Enabled = false;
                    this.btnExecute.Enabled = false;
                    this.btnRefresh.Enabled = false;
                    this.btnSettings.Enabled = false;
                    this.btnClearLog.Enabled = false;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

                    this.bgWorker.CancelAsync();
                }
            }

            return;
        }

        private void btnExecute_Click(Object sender, EventArgs e)
        {
            if ((!(this.bgWorker.IsBusy)))
            {
                this.code = 2;
                if ((this.code == 2))
                {
                    this.cbAutoExec.Checked = this.cbAutoExec.Checked;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = false;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.addToLog();
                    this.btnExecute.Text = String.Format("{0}", "Остановить");
                    this.lblComment.Text = String.Format("{0}", "Выполнение задания запущено");

                    this.gbType.Enabled = false;
                    this.gbLists.Enabled = false;
                    this.gbSettings.Enabled = false;
                    this.btnExecute.Enabled = true;
                    this.btnRefresh.Enabled = false;
                    this.btnSettings.Enabled = false;
                    this.btnClearLog.Enabled = false;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

                    this.bgWorker.RunWorkerAsync();
                }
            }
            else
            {
                this.code = this.code;
                if ((this.code == 2))
                {
                    this.cbAutoExec.Checked = false;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = this.cbAutoExec.Checked;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.addToLog();
                    this.btnExecute.Text = String.Format("{0}", "Запустить");
                    this.lblComment.Text = String.Format("{0}", "Выполнение задания остановлено");

                    this.gbType.Enabled = false;
                    this.gbLists.Enabled = false;
                    this.gbSettings.Enabled = false;
                    this.btnExecute.Enabled = false;
                    this.btnRefresh.Enabled = false;
                    this.btnSettings.Enabled = false;
                    this.btnClearLog.Enabled = false;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

                    this.bgWorker.CancelAsync();
                }
            }

            return;
        }

        private void btnSettings_Click(Object sender, EventArgs e)
        {
            this.cbAutoExec.Checked = false;
            this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
            this.timer.Enabled = this.cbAutoExec.Checked;
            this.numLists.Enabled = this.rbLists.Checked;
            this.numCount.Enabled = this.rbCount.Checked;

            if ((!(this.bgWorker.IsBusy)))
            {
                Settings.MainForm.ShowDialog();
            }

            this.gbType.Enabled = false;
            this.gbLists.Enabled = false;
            this.gbSettings.Enabled = false;
            this.btnExecute.Enabled = false;
            this.btnRefresh.Enabled = ((!((Properties.Settings.Default.idMega == String.Empty) || (Properties.Settings.Default.dbHost == String.Empty) || (Properties.Settings.Default.dbPort == String.Empty) || (Properties.Settings.Default.dbService == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin) == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword) == String.Empty))) && (!((Properties.Settings.Default.idMega == String.Empty) || (Properties.Settings.Default.srvHost == String.Empty) || (Properties.Settings.Default.srvPort == String.Empty) || (Properties.Settings.Default.srvService == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin) == String.Empty) || (CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword) == String.Empty))));
            this.btnSettings.Enabled = true;
            this.btnClearLog.Enabled = true;
            this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

            return;
        }

        private void timer_Tick(Object sender, EventArgs e)
        {
            this.cbAutoExec.Checked = this.cbAutoExec.Checked;
            this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
            this.timer.Enabled = false;
            this.numLists.Enabled = this.rbLists.Checked;
            this.numCount.Enabled = this.rbCount.Checked;

            if ((!(this.bgWorker.IsBusy)))
            {
                this.btnExecute.PerformClick();
            }

            this.gbType.Enabled = this.gbType.Enabled;
            this.gbLists.Enabled = this.gbLists.Enabled;
            this.gbSettings.Enabled = this.gbSettings.Enabled;
            this.btnExecute.Enabled = this.btnExecute.Enabled;
            this.btnRefresh.Enabled = this.btnRefresh.Enabled;
            this.btnSettings.Enabled = this.btnSettings.Enabled;
            this.btnClearLog.Enabled = this.btnClearLog.Enabled;
            this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

            return;
        }

        private void cbAutoExec_CheckedChanged(Object sender, EventArgs e)
        {
            if ((!(this.cbAutoExec.Checked)))
            {
                this.cbAutoExec.Checked = false;
                this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                this.timer.Enabled = this.cbAutoExec.Checked;
                this.numLists.Enabled = this.rbLists.Checked;
                this.numCount.Enabled = this.rbCount.Checked;

                this.gbType.Enabled = this.gbType.Enabled;
                this.gbLists.Enabled = this.gbLists.Enabled;
                this.gbSettings.Enabled = this.gbSettings.Enabled;
                this.btnExecute.Enabled = this.btnExecute.Enabled;
                this.btnRefresh.Enabled = this.btnRefresh.Enabled;
                this.btnSettings.Enabled = this.btnSettings.Enabled;
                this.btnClearLog.Enabled = this.btnClearLog.Enabled;
                this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);
            }

            return;
        }

        private void rbCommon_CheckedChanged(Object sender, EventArgs e)
        {
            this.cbAutoExec.Checked = false;
            this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
            this.timer.Enabled = this.cbAutoExec.Checked;
            this.numLists.Enabled = this.rbLists.Checked;
            this.numCount.Enabled = this.rbCount.Checked;

            this.gbType.Enabled = this.gbType.Enabled;
            this.gbLists.Enabled = this.gbLists.Enabled;
            this.gbSettings.Enabled = this.gbSettings.Enabled;
            this.btnExecute.Enabled = this.btnExecute.Enabled;
            this.btnRefresh.Enabled = this.btnRefresh.Enabled;
            this.btnSettings.Enabled = this.btnSettings.Enabled;
            this.btnClearLog.Enabled = this.btnClearLog.Enabled;
            this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

            return;
        }

        private void numCommon_ValueChanged(Object sender, EventArgs e)
        {
            this.cbAutoExec.Checked = false;
            this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
            this.timer.Enabled = this.cbAutoExec.Checked;
            this.numLists.Enabled = this.rbLists.Checked;
            this.numCount.Enabled = this.rbCount.Checked;

            this.gbType.Enabled = this.gbType.Enabled;
            this.gbLists.Enabled = this.gbLists.Enabled;
            this.gbSettings.Enabled = this.gbSettings.Enabled;
            this.btnExecute.Enabled = this.btnExecute.Enabled;
            this.btnRefresh.Enabled = this.btnRefresh.Enabled;
            this.btnSettings.Enabled = this.btnSettings.Enabled;
            this.btnClearLog.Enabled = this.btnClearLog.Enabled;
            this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

            return;
        }

        private void dgvLists_CellContentClick(Object sender, DataGridViewCellEventArgs e)
        {
            if ((!(this.dgvLists.CurrentCell == null)) && (this.dgvLists.CurrentCell.ColumnIndex == 0))
            {
                this.cbAutoExec.Checked = false;
                this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                this.timer.Enabled = this.cbAutoExec.Checked;
                this.numLists.Enabled = this.rbLists.Checked;
                this.numCount.Enabled = this.rbCount.Checked;

                this.gbType.Enabled = this.gbType.Enabled;
                this.gbLists.Enabled = this.gbLists.Enabled;
                this.gbSettings.Enabled = this.gbSettings.Enabled;
                this.btnExecute.Enabled = this.btnExecute.Enabled;
                this.btnRefresh.Enabled = this.btnRefresh.Enabled;
                this.btnSettings.Enabled = this.btnSettings.Enabled;
                this.btnClearLog.Enabled = this.btnClearLog.Enabled;
                this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);
            }

            return;
        }

        private String getQuery(String action)
        {
            String Result;
            Byte type;

            this.addToMessage(String.Format("{0}", "**************************************************"));
            this.addToMessage(String.Format("ТБ '{0}'", Properties.Settings.Default.idMega));
            this.addToMessage(String.Format("Обработка '{0}'", action));

            type = 0;
            if ((this.rbNormal.Checked))
            {
                type = 1;
                this.addToMessage(String.Format("{0}", "Режим 'Нормальная'"));
            }
            if ((this.rbEnd.Checked))
            {
                type = 2;
                this.addToMessage(String.Format("{0}", "Режим 'До конца'"));
            }
            if ((this.rbError.Checked))
            {
                type = 3;
                this.addToMessage(String.Format("{0}", "Режим 'В ошибки'"));
            }

            Result = String.Empty;
            if ((this.rbLists.Checked))
            {
                Result = String.Format("select unique t.listid, t.state, 0, t.restcount, t.state, {0} from(select unique t.id as listid, t.state as state, t.action as action, t.restcount as restcount, decode(t.division, 6, 'ФТ184(зачисления)', 12, 'Пластик(зачисления)', 2, 'Пластик(списания)', 3, 'Ф190(списания)', 5, decode(t.flowday, t.opdaybegin, 'Капитал.(new)', t.opdayend, 'Капитал.(new)', 'Капитал.(old)'), 4, decode(t.flowday, t.opdaybegin, 'Пролонг.(new)', t.opdayend, 'Пролонг.(new)', 'Пролонг.(old)')) as lsttype, nvl(((sum(decode(t.action, 0,           1, 0)) over(partition by decode(t.division, 6, 'ФТ184(зачисления)', 12, 'Пластик(зачисления)', 2, 'Пластик(списания)', 3, 'Ф190(списания)', 5, decode(t.flowday, t.opdaybegin, 'Капитал.(new)', t.opdayend, 'Капитал.(new)', 'Капитал.(old)'), 4, decode(t.flowday, t.opdaybegin, 'Пролонг.(new)', t.opdayend, 'Пролонг.(new)', 'Пролонг.(old)')) order by decode(t.state, 0, decode(t.userlogin, '*', 0, 1), 1, 3, 3, 1, t.state) asc, t.opdaybegin asc, t.listtype asc, t.id asc)) + (sum(decode(t.action, 0, 0,           1)) over())) /    1, 0) as cntwrk from schema.table t where(((t.flowday) in ((to_date('{1}', 'DD.MM.YYYY')))) and ((t.division) in ((2), (3), (4), (5), (6), (12))) and (not((t.state) in ((4), (5), (8)))) and ((t.mega) in (({2}))) and (not(((t.division) in ((2))) and ((t.branchno) in ((select unique t.branchno from schema.table t where(((t.flowday) in ((to_date('{1}', 'DD.MM.YYYY')))) and ((t.division) in ((12))) and (not((t.state) in ((4), (5), (8)))) and ((t.mega) in (({2}))))))))))) t where(((t.action) in ((0))) and ((t.lsttype) in (('{3}'))) and ((t.cntwrk) between (0) and ({4})))", type, DateTime.Now.ToString("dd.MM.yyyy"), Properties.Settings.Default.idMega, action, this.numLists.Value);
                this.addToMessage(String.Format("MAX cписков (шт.) '{0}'", this.numLists.Value));
            }
            if ((this.rbCount.Checked))
            {
                Result = String.Format("select unique t.listid, t.state, 0, t.restcount, t.state, {0} from(select unique t.id as listid, t.state as state, t.action as action, t.restcount as restcount, decode(t.division, 6, 'ФТ184(зачисления)', 12, 'Пластик(зачисления)', 2, 'Пластик(списания)', 3, 'Ф190(списания)', 5, decode(t.flowday, t.opdaybegin, 'Капитал.(new)', t.opdayend, 'Капитал.(new)', 'Капитал.(old)'), 4, decode(t.flowday, t.opdaybegin, 'Пролонг.(new)', t.opdayend, 'Пролонг.(new)', 'Пролонг.(old)')) as lsttype, nvl(((sum(decode(t.action, 0, t.restcount, 0)) over(partition by decode(t.division, 6, 'ФТ184(зачисления)', 12, 'Пластик(зачисления)', 2, 'Пластик(списания)', 3, 'Ф190(списания)', 5, decode(t.flowday, t.opdaybegin, 'Капитал.(new)', t.opdayend, 'Капитал.(new)', 'Капитал.(old)'), 4, decode(t.flowday, t.opdaybegin, 'Пролонг.(new)', t.opdayend, 'Пролонг.(new)', 'Пролонг.(old)')) order by decode(t.state, 0, decode(t.userlogin, '*', 0, 1), 1, 3, 3, 1, t.state) asc, t.opdaybegin asc, t.listtype asc, t.id asc)) + (sum(decode(t.action, 0, 0, t.restcount)) over())) / 1000, 0) as cntwrk from schema.table t where(((t.flowday) in ((to_date('{1}', 'DD.MM.YYYY')))) and ((t.division) in ((2), (3), (4), (5), (6), (12))) and (not((t.state) in ((4), (5), (8)))) and ((t.mega) in (({2}))) and (not(((t.division) in ((2))) and ((t.branchno) in ((select unique t.branchno from schema.table t where(((t.flowday) in ((to_date('{1}', 'DD.MM.YYYY')))) and ((t.division) in ((12))) and (not((t.state) in ((4), (5), (8)))) and ((t.mega) in (({2}))))))))))) t where(((t.action) in ((0))) and ((t.lsttype) in (('{3}'))) and ((t.cntwrk) between (0) and ({4})))", type, DateTime.Now.ToString("dd.MM.yyyy"), Properties.Settings.Default.idMega, action, this.numCount.Value);
                this.addToMessage(String.Format("MAX строк (тыс.) '{0}'", this.numCount.Value));
            }

            return Result;
        }

        

        private void setDataSource(Object dt)
        {
            Int32 i;
            Dictionary<Object, Object> state;

            state = new Dictionary<Object, Object>();
            for (i = 0; !(i == this.dgvLists.Rows.Count); i += 1)
            {
                try
                {
                    state[this.dgvLists.Rows[i].Cells[1].Value] = this.dgvLists.Rows[i].Cells[0].Value;
                }
                catch (Exception ex)
                {
                    state[this.dgvLists.Rows[i].Cells[1].Value] = false;
                }
            }
            if ((!(dt == null)))
            {
                this.dgvLists.DataSource = dt;
            }
            for (i = 0; !(i == this.dgvLists.Rows.Count); i += 1)
            {
                try
                {
                    this.dgvLists.Rows[i].Cells[0].Value = state[this.dgvLists.Rows[i].Cells[1].Value];
                }
                catch (Exception ex)
                {
                    this.dgvLists.Rows[i].Cells[0].Value = false;
                }
            }
            state = null;

            return;
        }

        private void addToMessage(String msg)
        {
            this.message = String.Format("{0}: {1}\n", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), msg) + this.message;

            return;
        }

        private void addToLog()
        {
            if ((!(this.message == String.Empty)))
            {
                this.rtbLog.Text = String.Format("{0}", this.message) + this.rtbLog.Text;
                this.message = String.Empty;
            }

            return;
        }

        private void bgWorker_DoWork(Object sender, DoWorkEventArgs e)
        {
            switch (this.code)
            {
                case 1:
                {
                    this.bgWorker_DoWork_Refresh(sender, e);
                }
                break;
                case 2:
                {
                    this.bgWorker_DoWork_ExecReg(sender, e);
                }
                break;
                default:
                {
                    this.addToMessage(String.Format("{0}", "Неизвестный код обработки"));
                }
                break;
            }

            return;
        }

        private void bgWorker_ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            switch (this.code)
            {
                case 1:
                {
                    this.bgWorker_ProgressChanged_Refresh(sender, e);
                }
                break;
                case 2:
                {
                    this.bgWorker_ProgressChanged_ExecReg(sender, e);
                }
                break;
                default:
                {
                    this.addToMessage(String.Format("{0}", "Неизвестный код обработки"));
                }
                break;
            }

            return;
        }

        private void bgWorker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            switch (this.code)
            {
                case 1:
                {
                    this.bgWorker_RunWorkerCompleted_Refresh(sender, e);
                }
                break;
                case 2:
                {
                    this.bgWorker_RunWorkerCompleted_ExecReg(sender, e);
                }
                break;
                default:
                {
                    this.addToMessage(String.Format("{0}", "Неизвестный код обработки"));
                }
                break;
            }

            return;
        }

        private void bgWorker_DoWork_ExecReg(Object sender, DoWorkEventArgs e)
        {
            Int32 i;
            Int32 k;
            DataTable list;

            try
            {
                list = new DataTable();
                SQLUtil.Instance.Connect(Properties.Settings.Default.dbHost, Properties.Settings.Default.dbPort, Properties.Settings.Default.dbService, CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin), CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword));
                REGUtil.Instance.Connect(Properties.Settings.Default.srvHost, Properties.Settings.Default.srvPort, Properties.Settings.Default.srvService, CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvLogin), CRYUtil.Instance.Decrypt(Properties.Settings.Default.srvPassword));
                for (k = 0; !(k == this.dgvLists.Rows.Count); k += 1)
                {
                    if ((this.dgvLists.Rows[k].Cells[0].Value.ToString() == String.Format("{0}", "True")))
                    {
                        if ((this.bgWorker.CancellationPending))
                        {
                            break;
                        }
                        try
                        {
                            list = SQLUtil.Instance.Execute(String.Format("{0}", this.getQuery(this.dgvLists.Rows[k].Cells[1].Value.ToString())));
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(String.Format("{0}", ex.Message));
                        }

                        this.bgWorker.ReportProgress(0);
                        this.addToMessage(String.Format("Списков '{0}'", list.Rows.Count));
                        for (i = 0; !(i == list.Rows.Count); i += 1)
                        {
                            if ((this.dgvLists.Rows[k].Cells[0].Value.ToString() == String.Format("{0}", "True")))
                            {
                                if ((this.bgWorker.CancellationPending))
                                {
                                    break;
                                }
                                try
                                {
                                    REGUtil.Instance.Execute(list.Rows[i].ItemArray[0].ToString(), list.Rows[i].ItemArray[1].ToString(), list.Rows[i].ItemArray[2].ToString(), list.Rows[i].ItemArray[3].ToString(), list.Rows[i].ItemArray[4].ToString(), list.Rows[i].ItemArray[5].ToString());
                                }
                                catch (Exception ex)
                                {
                                    this.addToMessage(String.Format("{0}", ex.Message));
                                }
                                this.bgWorker.ReportProgress((Int32)(((Double)(i + 1) / (Double)(list.Rows.Count)) * (Double)(100)));
                            }
                        }
                        this.addToMessage(String.Format("{0}", "Обработка завершена"));
                        this.bgWorker.ReportProgress(100);
                    }
                }
                REGUtil.Instance.Disconnect();
                SQLUtil.Instance.Disconnect();
                list = null;
            }
            catch (Exception ex)
            {
                this.addToMessage(String.Format("{0}", ex.Message));
            }

            if ((this.bgWorker.CancellationPending))
            {
                e.Cancel = true;
            }

            return;
        }

        private void bgWorker_ProgressChanged_ExecReg(Object sender, ProgressChangedEventArgs e)
        {
            this.addToLog();
            this.pbProgress.Value = e.ProgressPercentage;

            return;
        }

        private void bgWorker_RunWorkerCompleted_ExecReg(Object sender, RunWorkerCompletedEventArgs e)
        {
            if ((!(e.Cancelled)))
            {
                this.code = 0;
                if ((this.code == 0))
                {
                    this.cbAutoExec.Checked = this.cbAutoExec.Checked;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = this.cbAutoExec.Checked;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.addToLog();
                    this.btnExecute.Text = String.Format("{0}", "Запустить");
                    this.lblComment.Text = String.Format("{0}", "Выполнение задания завершено успешно");

                    this.gbType.Enabled = true;
                    this.gbLists.Enabled = true;
                    this.gbSettings.Enabled = true;
                    this.btnExecute.Enabled = true;
                    this.btnRefresh.Enabled = true;
                    this.btnSettings.Enabled = true;
                    this.btnClearLog.Enabled = true;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

                    this.btnRefresh.PerformClick();
                }
            }
            else
            {
                this.code = 0;
                if ((this.code == 0))
                {
                    this.cbAutoExec.Checked = false;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = this.cbAutoExec.Checked;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.addToLog();
                    this.btnExecute.Text = String.Format("{0}", "Запустить");
                    this.lblComment.Text = String.Format("{0}", "Выполнение задания отменено пользователем");

                    this.gbType.Enabled = true;
                    this.gbLists.Enabled = true;
                    this.gbSettings.Enabled = true;
                    this.btnExecute.Enabled = true;
                    this.btnRefresh.Enabled = true;
                    this.btnSettings.Enabled = true;
                    this.btnClearLog.Enabled = true;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);

                    this.btnRefresh.PerformClick();
                }
            }

            return;
        }

        private void bgWorker_DoWork_Refresh(Object sender, DoWorkEventArgs e)
        {
            try
            {
                SQLUtil.Instance.Connect(Properties.Settings.Default.dbHost, Properties.Settings.Default.dbPort, Properties.Settings.Default.dbService, CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbLogin), CRYUtil.Instance.Decrypt(Properties.Settings.Default.dbPassword));
                e.Result = SQLUtil.Instance.Execute(String.Format("select unique r.LSTType as LSTType, nvl(t.CNTNew, '0 / 0') as CNTNew, nvl(t.CNTPartial, '0 / 0') as CNTPartial, nvl(t.CNTProcess, '0 / 0') as CNTProcess, nvl(t.CNTTerminate, '0 / 0') as CNTTerminate, nvl(t.WRKNormal, '0 / 0') as WRKNormal, nvl(t.WRKEnd, '0 / 0') as WRKEnd, nvl(t.WRKError, '0 / 0') as WRKError from (select unique decode(t.division, 6, 'ФТ184(зачисления)', 12, 'Пластик(зачисления)', 2, 'Пластик(списания)', 3, 'Ф190(списания)', 5, decode(t.flowday, t.opdaybegin, 'Капитал.(new)', t.opdayend, 'Капитал.(new)', 'Капитал.(old)'), 4, decode(t.flowday, t.opdaybegin, 'Пролонг.(new)', t.opdayend, 'Пролонг.(new)', 'Пролонг.(old)')) as LSTType, sum(decode(t.state, 0, 1, 0)) || ' / ' || sum(decode(t.state, 0, t.restcount, 0)) as CNTNew, sum(decode(t.state, 1, 1, 0)) || ' / ' || sum(decode(t.state, 1, t.restcount, 0)) as CNTPartial, sum(decode(t.state, 2, 1, 0)) || ' / ' || sum(decode(t.state, 2, t.restcount, 0)) as CNTProcess, sum(decode(t.state, 3, 1, 0)) || ' / ' || sum(decode(t.state, 3, t.restcount, 0)) as CNTTerminate, sum(decode(t.action, 1, 1, 0)) || ' / ' || sum(decode(t.action, 1, t.restcount, 0)) as WRKNormal, sum(decode(t.action, 2, 1, 0)) || ' / ' || sum(decode(t.action, 2, t.restcount, 0)) as WRKEnd, sum(decode(t.action, 3, 1, 0)) || ' / ' || sum(decode(t.action, 3, t.restcount, 0)) as WRKError from schema.table t where(((t.flowday) in ((to_date('{0}', 'DD.MM.YYYY')))) and ((t.division) in ((2), (3), (4), (5), (6), (12))) and (not((t.state) in ((4), (5), (8)))) and ((t.mega) in (({1})))) group by(decode(t.division, 6, 'ФТ184(зачисления)', 12, 'Пластик(зачисления)', 2, 'Пластик(списания)', 3, 'Ф190(списания)', 5, decode(t.flowday, t.opdaybegin, 'Капитал.(new)', t.opdayend, 'Капитал.(new)', 'Капитал.(old)'), 4, decode(t.flowday, t.opdaybegin, 'Пролонг.(new)', t.opdayend, 'Пролонг.(new)', 'Пролонг.(old)')))) t, (select unique LSTType from(select unique 'Пролонг.(old)' as v1, 'Капитал.(old)' as v2, 'ФТ184(зачисления)' as v3, 'Пластик(зачисления)' as v4, 'Пластик(списания)' as v5, 'Ф190(списания)' as v6, 'Пролонг.(new)' as v7, 'Капитал.(new)' as v8 from dual) unpivot(LSTType for tp in (v1, v2, v3, v4, v5, v6, v7, v8))) r where(((t.LSTType(+)) in ((r.LSTType)))) order by decode(r.LSTType, 'Пролонг.(old)', 1, 'Капитал.(old)', 2, 'ФТ184(зачисления)', 3, 'Пластик(зачисления)', 4, 'Пластик(списания)', 5, 'Ф190(списания)', 6, 'Пролонг.(new)', 7, 'Капитал.(new)', 8) asc", DateTime.Now.ToString("dd.MM.yyyy"), Properties.Settings.Default.idMega));
                SQLUtil.Instance.Disconnect();
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                this.addToMessage(String.Format("{0}", ex.Message));
            }

            return;
        }

        private void bgWorker_ProgressChanged_Refresh(Object sender, ProgressChangedEventArgs e)
        {
            this.addToLog();
            this.pbProgress.Value = e.ProgressPercentage;

            return;
        }

        private void bgWorker_RunWorkerCompleted_Refresh(Object sender, RunWorkerCompletedEventArgs e)
        {
            if ((!(e.Cancelled)))
            {
                this.code = 0;
                if ((this.code == 0))
                {
                    this.cbAutoExec.Checked = this.cbAutoExec.Checked;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = this.timer.Enabled;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.addToLog();
                    this.setDataSource(e.Result);
                    this.lblComment.Text = String.Format("{0}", "Ожидание");

                    this.gbType.Enabled = true;
                    this.gbLists.Enabled = true;
                    this.gbSettings.Enabled = true;
                    this.btnExecute.Enabled = true;
                    this.btnRefresh.Enabled = true;
                    this.btnSettings.Enabled = true;
                    this.btnClearLog.Enabled = true;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);
                }
            }
            else
            {
                this.code = 0;
                if ((this.code == 0))
                {
                    this.cbAutoExec.Checked = false;
                    this.timer.Interval = (Int32)(this.numTimer.Value * 1000);
                    this.timer.Enabled = this.cbAutoExec.Checked;
                    this.numLists.Enabled = this.rbLists.Checked;
                    this.numCount.Enabled = this.rbCount.Checked;

                    this.addToLog();
                    this.setDataSource(null);
                    this.lblComment.Text = String.Format("{0}", "Ожидание");

                    this.gbType.Enabled = false;
                    this.gbLists.Enabled = false;
                    this.gbSettings.Enabled = false;
                    this.btnExecute.Enabled = false;
                    this.btnRefresh.Enabled = true;
                    this.btnSettings.Enabled = true;
                    this.btnClearLog.Enabled = true;
                    this.frmMain.Text = String.Format("ТБ[{0}] Автоматическая обработка реестров", Properties.Settings.Default.idMega);
                }
            }

            return;
        }
    }
}
