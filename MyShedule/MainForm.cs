﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using Yogesh.Extensions;
using MyShedule.SheduleClasses;
using MySql.Data.MySqlClient;
using SD = System.Data;
using Org.BouncyCastle.Crypto.Engines;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace MyShedule
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            if (dgvShedule.ColumnCount <= 0)
                cmbView.Enabled = false;
            else
                cmbView.Enabled = true;

            LoadDictionatyes();
        }

        public EducationLoadAdapter EducationAdapter;
        public dsShedule SheduleDataSet;
        public SheduleWeeks Shedule;
        //public Employments emps;
        public List<SheduleRoom> Rooms;

        public List<SheduleTeacher> Teachers;

        public List<SheduleGroup> Groups;

        public List<SheduleDiscipline> Disciplines;

        public bool BrushActive = false;

        public bool WatchAll = true;

        private void LoadDictionatyes()
        {
            SheduleDataSet = new dsShedule();
            Rooms = new List<SheduleRoom>();
            Teachers = new List<SheduleTeacher>();
            Groups = new List<SheduleGroup>();
            Disciplines = new List<SheduleDiscipline>();

            try
            {
                string filename = @"Нагрузка.xml";
                SheduleDataSet.Education.ReadXml(filename);
                EducationAdapter = new EducationLoadAdapter(DictionaryConverter.EducationToList(SheduleDataSet));
            }
            catch (Exception)
            {
                MessageBox.Show("Не могу открыть файл c нагрузкой");
            }

            try
            {
                string filename = @"Аудитории.xml";
                SheduleDataSet.Room.ReadXml(filename);
                Rooms = DictionaryConverter.RoomsToList(SheduleDataSet);
            }
            catch (Exception)
            {
                MessageBox.Show("Не могу открыть файл с аудиториями");
            }

            try
            {
                string filename = @"Преподаватели.xml";
                SheduleDataSet.Teacher.ReadXml(filename);
                Teachers = DictionaryConverter.TeachersToList(SheduleDataSet);
            }
            catch (Exception)
            {
                MessageBox.Show("Не могу открыть файл с преподавателями");
            }

            try
            {
                string filename = @"Группы.xml";
                SheduleDataSet.Group.ReadXml(filename);
                Groups = DictionaryConverter.GroupsToList(SheduleDataSet);
            }
            catch (Exception)
            {
                MessageBox.Show("Не могу открыть файл с группами");
            }

            try
            {
                string filename = @"Дисциплины.xml";
                SheduleDataSet.Discipline.ReadXml(filename);
                Disciplines = DictionaryConverter.DisciplinesToList(SheduleDataSet);
            }
            catch (Exception)
            {
                MessageBox.Show("Не могу открыть файл с дисциплинами");
            }
        }

        private SettingShedule GetSetting()
        {
            SettingsAplication stg = new SettingsAplication();

            return new SettingShedule(stg.CountWeeksShedule, stg.CountDayEducationalWeek, stg.CountDaysShedule,
                 stg.CountLessonsOfDay, stg.CountEducationalWeekBySem, stg.MaxCountLessonsOfWeekDay, stg.MaxCountLessonsOfWeekEnd,
                 stg.FirstLessonsOfWeekDay, stg.FirstLessonsOfWeekEnd, stg.LastLessonsOfWeekDay, stg.LastLessonsOfWeekEnd);
        }

        private void InitDiatribiteList()
        {
            lvDistribute.View = System.Windows.Forms.View.Details;
            lvDistribute.Columns.Clear();
            lvDistribute.Columns.Add("Состояние", 150);
            lvDistribute.Columns.Add("Элемент нагрузки", 600);
            lvDistribute.Columns.Add("Причина", 400);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            //emps = new Employments();

            //SettingShedule setting = GetSetting();
            //shedule = new SheduleWeeks(Rooms, setting);

            //InitMainForm
            this.WindowState = FormWindowState.Maximized;
            splitContainer1.Panel2Collapsed = true;

            InitTabControl();

            InitDiatribiteList();

            //Init combo box view projections
            InitCmbViewProjection();

            //Init Main Grid
            //InitDataGridView();

            //Brushes
            tsbBlockTime.Enabled = false;
            tsbFreeTime.Enabled = false;
            BrushActive = false;

            //Events
            this.cmbView.SelectedIndexChanged += new EventHandler(cmbView_SelectedIndexChanged);
            this.dgvShedule.CellDoubleClick += new DataGridViewCellEventHandler(dgvShedule_CellDoubleClick);
            this.dgvShedule.CellClick += new DataGridViewCellEventHandler(dgvShedule_CellClick);
            this.dgvShedule.MouseEnter += new EventHandler(dgvShedule_MouseEnter);
            this.dgvShedule.MouseLeave += new EventHandler(dgvShedule_MouseLeave);
        }

        private void InitTabControl()
        {
            ImageList list = new ImageList();
            list.Images.Add(MyShedule.Properties.Resources.comment);
            list.Images.Add(MyShedule.Properties.Resources.arrow_refresh);
            tabControl1.ImageList = list;
            tabControl1.TabPages[0].ImageIndex = 0;
            tabControl1.TabPages[1].ImageIndex = 1;
        }

        void dgvShedule_MouseLeave(object sender, EventArgs e)
        {
            if (BrushActive)
                this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        void dgvShedule_MouseEnter(object sender, EventArgs e)
        {
            if (BrushActive)
                this.Cursor = System.Windows.Forms.Cursors.Hand;
        }


        void cmbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvShedule = TableGUIManager.FillDataGrid(Shedule, dgvShedule, ViewShedule, EducationAdapter, Rooms, WatchAll);
        }

        private void InitCmbViewProjection()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = SheduleView.BasicViews;
            cmbView.ComboBox.DisplayMember = "Description";
            cmbView.ComboBox.ValueMember = "TypeCode";
            cmbView.ComboBox.DataSource = bs;
            cmbView.AutoSize = false;
            cmbView.Width = 170;
            cmbView.Select(0, 0);
        }


        public View ViewShedule
        {
            get
            {
                return (View)Convert.ToInt32(cmbView.ComboBox.SelectedValue);
            }
        }


        public bool CheckInputData
        {
            get
            {
                bool check = true;
                if (EducationAdapter.Items.Count == 0)
                {
                    MessageBox.Show("Нагрузка не задана, составьте или загрузите нагрузку!");
                    check = false;
                }

                if (Rooms.Count == 0)
                {
                    MessageBox.Show("Аудитории не заданы, заполните список аудиторий!");
                    check = false;
                }
                return check;
            }
        }

        private void tsbCreateShedule_Click(object sender, EventArgs e)
        {
            if (!CheckInputData)
                return;

            CreateSheduleForm frmShedule = new CreateSheduleForm();

            if (frmShedule.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            SheduleGenerator reactor = new SheduleGenerator(EducationAdapter, Rooms, GetSetting(),
                frmShedule.FirstDaySem, Shedule == null ? new Employments() : Shedule.Employments);

            Shedule = reactor.Generate();

            UpdateTableShedule();

            UpdateDistributeList(reactor.Results);

            WatchTriggerStateChange(false);

            if (dgvShedule.ColumnCount <= 0)
                cmbView.Enabled = false;
            else
                cmbView.Enabled = true;
        }

        private void UpdateDistributeList(List<DistributeResult> results)
        {
            lvDistribute.Items.Clear();
            ImageList imgList = new ImageList();
            imgList.Images.Add(MyShedule.Properties.Resources.accept);
            imgList.Images.Add(MyShedule.Properties.Resources.cancel);
            lvDistribute.SmallImageList = imgList;

            foreach (DistributeResult r in results)
            {
                string complete = r.Complete ? "успешно" : "не распределена";
                ListViewItem item = new ListViewItem(complete);
                item.SubItems.Add(r.ItemInfo);
                item.SubItems.Add(r.Reason);
                item.ImageIndex = r.Complete ? 0 : 1;
                lvDistribute.Items.Add(item);

            }
        }

        private void tsbEducationLoad_Click(object sender, EventArgs e)
        {
            EdicationLoadForm frmEdicationLoad = new EdicationLoadForm(Teachers, Disciplines);
            frmEdicationLoad.SheduleDataSet = SheduleDataSet;
            frmEdicationLoad.ShowDialog();
            EducationAdapter = new EducationLoadAdapter(DictionaryConverter.EducationToList(frmEdicationLoad.SheduleDataSet));
        }


        void dgvShedule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 1 || e.RowIndex < 0)
                return;

            LessonForm frmLesson = new LessonForm();
            ShedulePointer Tag = dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag as ShedulePointer;
            frmLesson.txtSheduleTime.Text = SheduleTime.GetDescription(Tag.Time1);
            frmLesson.Employments = Shedule.Employments;
            frmLesson.ds = SheduleDataSet;
            frmLesson.Adapter = EducationAdapter;
            frmLesson.Rooms = Rooms;
            frmLesson.curClmn = dgvShedule.CurrentCell.ColumnIndex;

            frmLesson.Time1 = Tag.Time1;
            frmLesson.Lesson1 = Shedule.GetLesson(Tag.Time1, Tag.Room1);

            frmLesson.Time2 = Tag.Time2;
            frmLesson.Lesson2 = Shedule.GetLesson(Tag.Time2, Tag.Room2);

            frmLesson.Shedule = Shedule;

            if (frmLesson.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                UpdateTableShedule();

        }

        private void UpdateTableShedule()
        {
            dgvShedule = TableGUIManager.InitializeGrid(dgvShedule, Shedule.Setting.CountWeeksShedule,
                Shedule.Setting.CountDaysEducationWeek);

            dgvShedule = TableGUIManager.FillDataGrid(Shedule, dgvShedule, ViewShedule,
                EducationAdapter, Rooms, WatchAll);
        }

        private void tsbCreateClearShedule_Click(object sender, EventArgs e)
        {
            if (!CheckInputData)
                return;

            CreateSheduleForm frmShedule = new CreateSheduleForm();
            if (frmShedule.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            Shedule = new SheduleWeeks(Rooms, GetSetting(), frmShedule.FirstDaySem);

            UpdateTableShedule();

            WatchTriggerStateChange(true);

            if (dgvShedule.ColumnCount <= 0)
                cmbView.Enabled = false;
            else
                cmbView.Enabled = true;
        }


        #region BRUSH WOKERS

        private void tsbBrushTrigger_Click(object sender, EventArgs e)
        {
            ChangeBrushState();
        }

        private void ChangeBrushState(bool value)
        {
            BrushActive = value;
            UpdateBrushUI();
        }

        private void ChangeBrushState()
        {
            BrushActive = !BrushActive;
            UpdateBrushUI();
        }

        private void UpdateBrushUI()
        {
            tsbBlockTime.Enabled = BrushActive;
            tsbFreeTime.Enabled = BrushActive;

            this.Cursor = BrushActive ? System.Windows.Forms.Cursors.Hand : System.Windows.Forms.Cursors.Default;
            tsbFreeTime.Checked = !BrushActive;
            tsbBlockTime.Checked = BrushActive;
            tsbBrushTrigger.Image = BrushActive ? MyShedule.Properties.Resources.pencil_delete : MyShedule.Properties.Resources.pencil_add;
            tsbBrushTrigger.Text = BrushActive ? "Выкл" : "Вкл";
        }


        void dgvShedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dgvShedule.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (BrushActive)
                {
                    if (tsbFreeTime.Checked)
                        TimeFree(cell);
                    if (tsbBlockTime.Checked)
                        TimeBlocked(cell);
                }
                else
                {
                    ViewSelectLesson(cell);
                }
            }
        }

        private void TimeFree(DataGridViewCell cell)
        {
            ShedulePointer pointer = cell.Tag as ShedulePointer;
            SetCellFreeStyle(cell, pointer);

            SheduleLesson lesson1 = Shedule.GetLesson(pointer.Time1, pointer.Room1);
            if (lesson1 != null)
                lesson1.Clear();

            SheduleLesson lesson2 = Shedule.GetLesson(pointer.Time2, pointer.Room2);
            if (lesson2 != null)
                lesson2.Clear();

            string Name = dgvShedule.Rows[cell.RowIndex].Cells[0].Value.ToString();
            Shedule.Employments.RemoveInView(ViewShedule, new Employment(Name, pointer.Time1, ReasonEmployment.Another));
            Shedule.Employments.RemoveInView(ViewShedule, new Employment(Name, pointer.Time2, ReasonEmployment.Another));
        }

        private static void SetCellFreeStyle(DataGridViewCell cell, ShedulePointer pointer)
        {
            cell.Value = String.Empty;
            cell.Style.BackColor = (pointer.Time1.DayNumber > (int)Day.Friday) ? Color.LightBlue : new DataGridViewCellStyle().BackColor;
        }

        private void TimeBlocked(DataGridViewCell cell)
        {
            TimeFree(cell);

            ShedulePointer pointer = cell.Tag as ShedulePointer;
            string Name = dgvShedule.Rows[cell.RowIndex].Cells[0].Value.ToString();
            SetCellBlockedStyle(cell);

            Shedule.Employments.AddInView(ViewShedule, new Employment(Name, pointer.Time1, ReasonEmployment.UserBlocked));
            Shedule.Employments.AddInView(ViewShedule, new Employment(Name, pointer.Time2, ReasonEmployment.UserBlocked));
        }

        private void SetCellBlockedStyle(DataGridViewCell cell)
        {
            cell.Style.BackColor = Color.LightPink;
            cell.Value = "Занято";
            cell.Style.Font = new Font(FontFamily.GenericSansSerif, 12);
            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void tsbFreeTime_Click(object sender, EventArgs e)
        {
            tsbFreeTime.Checked = true;
            tsbBlockTime.Checked = false;
        }

        private void tsbBlockTime_Click(object sender, EventArgs e)
        {
            tsbBlockTime.Checked = true;
            tsbFreeTime.Checked = false;
        }

        #endregion

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            SheduleSettingForm frmSetting = new SheduleSettingForm();
            frmSetting.ShowDialog();
        }

        private void tsbRooms_Click(object sender, EventArgs e)
        {
            RoomsForm frmRoom = new RoomsForm();
            frmRoom.ds = SheduleDataSet;
            frmRoom.ShowDialog();
            Rooms = DictionaryConverter.RoomsToList(frmRoom.ds);
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = false;
        }

        private void tsbWatchTrigger_Click(object sender, EventArgs e)
        {
            WatchTriggerStateChange();
        }

        private void WatchTriggerStateChange()
        {
            if (Shedule == null)
                return;

            WatchAll = !WatchAll;
            WatchUpdateUI();
        }

        private void WatchTriggerStateChange(bool value)
        {
            if (Shedule == null)
                return;

            WatchAll = value;
            WatchUpdateUI();
        }

        private void WatchUpdateUI()
        {
            tsbWatchTrigger.Text = WatchAll ? "Показать часть" : "Показать все";
            tsbWatchTrigger.Image = WatchAll ? MyShedule.Properties.Resources.table_row_delete : MyShedule.Properties.Resources.table_row_insert;
            tsbWatchTrigger.Checked = WatchAll;

            dgvShedule = TableGUIManager.InitializeGrid(dgvShedule, Shedule.Setting.CountWeeksShedule, Shedule.Setting.CountDaysEducationWeek);
            dgvShedule = TableGUIManager.FillDataGrid(Shedule, dgvShedule, ViewShedule, EducationAdapter, Rooms, WatchAll);
        }

        public int NumSelectLesson = 0;

        public SheduleLesson L1;
        public SheduleLesson L2;
        public SheduleLesson L3;
        public SheduleLesson L4;
        public SheduleTime T1;
        public SheduleTime T2;
        public SheduleTime T3;
        public SheduleTime T4;
        private int coloumnIndLs1;
        private int rowIndLs1;
        private int coloumnIndLs2;
        private int rowIndLs2;
        private DataGridViewCell c1;
        private DataGridViewCell c2;
        private bool isFirstTime = true;
        private void button1_Click(object sender, EventArgs e)
        {
            NumSelectLesson = 1;
        }

        private void btnSelectLesson2_Click(object sender, EventArgs e)
        {
            NumSelectLesson = 2;
        }

        private void ExchangeLessons(SheduleLesson item1, SheduleLesson item2, SheduleTime time1, SheduleTime time2)
        {
            if(c1 == c2 && isFirstTime)
            { return; }
            if (item1 != null && item2 != null)
            {
                SheduleLesson tmp1 = item1.Copy();
                item1.Time = item2.Time.Copy();
                item1.Dates = item2.Dates;
                item2.Time = tmp1.Time.Copy();
                item2.Dates = tmp1.Dates;
                DataGridViewCell c3;
                Shedule.GetLesson(time1, item2.Room).UpdateFields(item2.Teacher, item2.Discipline, item2.Groups, item2.Type, item2.Dates);
                Shedule.GetLesson(time2, item1.Room).UpdateFields(item1.Teacher, item1.Discipline, item1.Groups, item1.Type, item1.Dates);
                if(isFirstTime)
                {
                    c3 = c1;
                    c1 = c2;
                    c2 = c3;
                }

            }
            else if (!(time1 is null) && !(time2 is null))
            {
                if (item1 == null && item2 != null)
                {
                    SheduleLesson lsn = Shedule.GetLesson(time1, item2.Room).Copy();
                    Shedule.GetLesson(time1, item2.Room).UpdateFields(item2.Teacher, item2.Discipline, item2.Groups, item2.Type, lsn.Dates);
                    if(isFirstTime) c2 = c1;
                    
                    item2.Clear();
                }
                else if (item1 != null && item2 == null)
                {
                    SheduleLesson lsn = Shedule.GetLesson(time2, item1.Room).Copy();
                    Shedule.GetLesson(time2, item1.Room).UpdateFields(item1.Teacher, item1.Discipline, item1.Groups, item1.Type, lsn.Dates);
                    if (isFirstTime) c1 = c2;
                    item1.Clear();
                }
                isFirstTime = false;
            }
        }

        private void btnExchangeLessons_Click(object sender, EventArgs e)
        {
            try
            {
                isFirstTime = true;
                c1 = dgvShedule.Rows[rowIndLs1].Cells[coloumnIndLs1];
                c2 = dgvShedule.Rows[rowIndLs2].Cells[coloumnIndLs2];

                ExchangeLessons(L1, L3, T1, T3);
                if (c1 == c2)
                {
                    rowIndLs1 = rowIndLs2;
                    coloumnIndLs1 = coloumnIndLs2;
                }
                else 
                {
                    int bufferIndex = rowIndLs1;
                    rowIndLs1 = rowIndLs2;
                    rowIndLs2 = bufferIndex;
                    bufferIndex = coloumnIndLs1;
                    coloumnIndLs1 = coloumnIndLs2;
                    coloumnIndLs2 = bufferIndex;
                }
                ExchangeLessons(L2, L4, T2, T4);

                UpdateTableShedule();
                c1 = dgvShedule.Rows[rowIndLs1].Cells[coloumnIndLs1];
                c2 = dgvShedule.Rows[rowIndLs2].Cells[coloumnIndLs2];
                NumSelectLesson = 1;
                ViewSelectLesson(c1);
                NumSelectLesson = 2;
                ViewSelectLesson(c2);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Выберете две ячейки, которые вы хотели бы поменять.");
            }
        }

        private void SetDataSelectLessonForm(SheduleLesson item1, SheduleLesson item2, Label txtTeacher, Label txtDiscipline,
             Label txtRoom, Label txtTypeLesson)
        {
            if (item1 == null && item2 == null)
            {
                txtTeacher.Text = txtDiscipline.Text = txtRoom.Text = txtTypeLesson.Text = String.Empty;
                return;
            }

            txtTeacher.Text = (item1 != null ? item1.Teacher : String.Empty) + " / " + (item2 != null ? item2.Teacher : String.Empty);

            txtDiscipline.Text = (item1 != null ? item1.Discipline : String.Empty) + " / " + (item2 != null ? item2.Discipline : String.Empty);

            txtRoom.Text = (item1 != null ? item1.Room : String.Empty) + " / " + (item2 != null ? item2.Room : String.Empty);

            txtTypeLesson.Text = (item1 != null ? SheduleLessonType.Description(item1.Type) : String.Empty) + " / " +
                                 (item2 != null ? SheduleLessonType.Description(item2.Type) : String.Empty);
        }

        private void ViewSelectLesson(DataGridViewCell cell)
        {
            ShedulePointer Tag = cell.Tag as ShedulePointer;

            SheduleLesson lesson1 = Shedule.GetLesson(Tag.Time1, Tag.Room1);
            SheduleLesson lesson2 = Shedule.GetLesson(Tag.Time2, Tag.Room2);

            if (NumSelectLesson == 1)
            {
                SetDataSelectLessonForm(lesson1, lesson2, txtTeacher1, txtDiscipline1, txtRoom1, txtTypeLesson1);
                coloumnIndLs1 = cell.ColumnIndex;
                rowIndLs1 = cell.RowIndex;
                L1 = lesson1;
                L2 = lesson2;
                T1 = Tag.Time1.Copy();
                T2 = Tag.Time2.Copy();
            }
            else if (NumSelectLesson == 2)
            {
                SetDataSelectLessonForm(lesson1, lesson2, txtTeacher2, txtDiscipline2, txtRoom2, txtTypeLesson2);
                coloumnIndLs2 = cell.ColumnIndex;
                rowIndLs2 = cell.RowIndex;
                L3 = lesson1;
                L4 = lesson2;
                T3 = Tag.Time1.Copy();
                T4 = Tag.Time2.Copy();
            }

            NumSelectLesson = 0;
        }

        private void tsiExportExcel_Click(object sender, EventArgs e)
        {
            ChooseGroupsForm choose = new ChooseGroupsForm();

            choose.adapter = EducationAdapter;
            choose.Rooms = Rooms;

            if (choose.ShowDialog() == System.Windows.Forms.DialogResult.OK && choose.ChooseNames.Count > 0)
            {
                ExportShedule exp = new ExportShedule();
                exp.NameElements = choose.ChooseNames;
                exp.shedule = Shedule;
                exp.view = choose.ChooseView;
                exp.Export();
            }
        }

        private void tsmiSaveSheduleToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog frmSave = new SaveFileDialog();
            frmSave.FileName = "расписание.xml";
            frmSave.Filter = "(*.xml)|*.xml";

            if (frmSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    SheduleSerializer.SaveData(frmSave.FileName, Shedule);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void tsmiOpenSheduleFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog frmOpen = new OpenFileDialog();
            frmOpen.DefaultExt = "xml";
            frmOpen.Filter = "(*.xml)|*.xml";

            if (frmOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Shedule = SheduleSerializer.ReadData(frmOpen.FileName);

                    if (Shedule != null)
                        Shedule.Employments.Clear();

                    UpdateTableShedule();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dgvShedule.ColumnCount <= 0)
                    cmbView.Enabled = false;
                else
                    cmbView.Enabled = true;
            }
        }

        private void tbsTeachers_Click(object sender, EventArgs e)
        {
            TeachersForm frmTeacher = new TeachersForm();
            frmTeacher.ds = SheduleDataSet;
            frmTeacher.ShowDialog();
            Teachers = DictionaryConverter.TeachersToList(frmTeacher.ds);
        }

        private void tsbGroups_Click(object sender, EventArgs e)
        {
            GroupForm frmGroup = new GroupForm();
            frmGroup.ds = SheduleDataSet;
            frmGroup.ShowDialog();
            Groups = DictionaryConverter.GroupsToList(frmGroup.ds);
        }

        private void tsbDisciplines_Click(object sender, EventArgs e)
        {
            DisciplineForm frmDiscipline = new DisciplineForm();
            frmDiscipline.ds = SheduleDataSet;
            frmDiscipline.ShowDialog();
            Disciplines = DictionaryConverter.DisciplinesToList(frmDiscipline.ds);
        }

        private void tsiExport_Excel_Click(object sender, EventArgs e)
        {
            string fileName;
            try
            {
                SaveFileDialog newExcelFile = new SaveFileDialog();
                newExcelFile.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                newExcelFile.Title = "Экспортировать в эксель";
                newExcelFile.FileName = this.cmbView.Text + " (" + DateTime.Now.ToString("yyyy-MM-dd") + ")";

                if (newExcelFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = newExcelFile.FileName;
                    var workbook = new XLWorkbook();
                    var worksheet = workbook.Worksheets.Add(this.Text);
                    for (int indexColoumn = 0; indexColoumn < dgvShedule.Columns.Count; indexColoumn++)
                    {
                        worksheet.Cell(1, indexColoumn + 1).Value = dgvShedule.Columns[indexColoumn].HeaderText;
                    }
                    for (int i = 0; i < dgvShedule.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvShedule.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dgvShedule.Rows[i].Cells[j].Value.ToString();
                            if (worksheet.Cell(i + 2, j + 1).Value.ToString().Length > 0)
                            {
                                XLAlignmentHorizontalValues align;

                                switch (dgvShedule.Rows[i].Cells[j].Style.Alignment)
                                {
                                    case DataGridViewContentAlignment.BottomRight:
                                        align = XLAlignmentHorizontalValues.Right;
                                        break;
                                    case DataGridViewContentAlignment.MiddleRight:
                                        align = XLAlignmentHorizontalValues.Right;
                                        break;
                                    case DataGridViewContentAlignment.TopRight:
                                        align = XLAlignmentHorizontalValues.Right;
                                        break;

                                    case DataGridViewContentAlignment.BottomCenter:
                                        align = XLAlignmentHorizontalValues.Center;
                                        break;
                                    case DataGridViewContentAlignment.MiddleCenter:
                                        align = XLAlignmentHorizontalValues.Center;
                                        break;
                                    case DataGridViewContentAlignment.TopCenter:
                                        align = XLAlignmentHorizontalValues.Center;
                                        break;
                                    default:
                                        align = XLAlignmentHorizontalValues.Left;
                                        break;
                                }
                                worksheet.Cell(i + 2, j + 1).Style.Alignment.Horizontal = align;
                                XLColor xlColor = XLColor.FromColor(dgvShedule.Rows[i].Cells[j].Style.SelectionBackColor);
                                worksheet.Cell(i + 2, j + 1).AddConditionalFormat().WhenLessThan(1).Fill.SetBackgroundColor(xlColor);
                                worksheet.Cell(i + 2, j + 1).Style.Font.FontName = dgvShedule.Font.Name;
                                worksheet.Cell(i + 2, j + 1).Style.Font.FontSize = dgvShedule.Font.Size;
                            }
                        }
                    }
                    workbook.SaveAs(fileName);
                    MessageBox.Show("Расписание успешно экспортировано.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Файл с таким именем уже сущетсвует и в данный момент открыт, если хотите перезаписать его, то закройте уже открытй файл.");
            }
        }

        private void addShedule()
        {
            var dateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var addSheduleScript = $"INSERT INTO `shedules` (`date`)" + $"values ('{dateTime}')";
            using (MySqlDataAdapter shedule = new MySqlDataAdapter(addSheduleScript, SheduleClasses.Connect.connect))
            {
                using (SD.DataTable sheduleTable = new SD.DataTable())
                {
                    shedule.Fill(sheduleTable);
                }
            }
        }

        private int getLastSheduleID()
        {
            int lastSheduleID = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(SheduleClasses.Connect.connect))
                {
                    connection.Open();
                    var addSheduleScript = "SELECT id FROM shedules ORDER BY ID DESC LIMIT 1;";

                    using (MySqlCommand command = new MySqlCommand(addSheduleScript, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Чтение значения ID из результирующего набора
                                lastSheduleID = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении ID расписания: " + ex.Message);
            }

            return lastSheduleID;
        }

        private void addGroup(int idShedule, string nameGroup)
        {
            var addSheduleScript = $"INSERT INTO `groups` (`shedule_id`,`Name`)" + $"values ('{idShedule}','{nameGroup}')";
            using (MySqlDataAdapter group = new MySqlDataAdapter(addSheduleScript, SheduleClasses.Connect.connect))
            {
                using (SD.DataTable groupTable = new SD.DataTable())
                {
                    group.Fill(groupTable);
                }
            }
        }

        private int getLastGroupID()
        {
            int lastGroupID = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(SheduleClasses.Connect.connect))
                {
                    connection.Open();
                    var addSheduleScript = "SELECT id FROM example_app.groups ORDER BY ID DESC LIMIT 1;";

                    using (MySqlCommand command = new MySqlCommand(addSheduleScript, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Чтение значения ID из результирующего набора
                                lastGroupID = reader.GetInt32(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при получении ID расписания: " + ex.Message);
            }

            return lastGroupID;
        }

        private void addLesson(int idGroup, string nameGroup, string dateTime, string hours, string type, string discipline, string teacher, string room)
        {
            var addSheduleScript = $"SET FOREIGN_KEY_CHECKS=0;INSERT INTO `lessons` (`id_group`,`name_group`,`date_time`,`hours`,`type`,`discipline`,`teacher`,`room`)" + $"values ('{idGroup}','{nameGroup}','{dateTime}','{hours}','{type}','{discipline}','{teacher}','{room}')";
            using (MySqlDataAdapter group = new MySqlDataAdapter(addSheduleScript, SheduleClasses.Connect.connect))
            {
                using (SD.DataTable groupTable = new SD.DataTable())
                {
                    group.Fill(groupTable);
                }
            }
        }

        private void exportDb(object sender, EventArgs e)
        {
            try
            {
            SheduleClasses.Connect.mycon = new MySqlConnection(SheduleClasses.Connect.connect);
            SheduleClasses.Connect.mycon.Open();
            addShedule();
            var idShedule = getLastSheduleID();
            foreach (var group in SheduleDataSet.Group)
            {
                addGroup(idShedule, group.Name);
                var idGroup = getLastGroupID();
                var lessons = Shedule.GetLessonsGroup(group.Name).ToList();
                foreach (var lesson in lessons)
                {
                    foreach (var dateLs in lesson.Dates)
                    {
                        String hour = lesson.Time.Description.Split(' ')[3];
                        addLesson(idGroup, group.Name, dateLs.ToString("yyyy-MM-dd HH:mm:ss"), hour, lesson.Type.ToString(), lesson.Discipline, lesson.Teacher, lesson.Room);
                    }
                }
            }
            MessageBox.Show("Экспорт расписания прошел успешно!");
            Connect.mycon.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ошибка добавления расписания в БД");
            }
        }

        private void tsiCSV_export_Click(object sender, EventArgs e)
        {

            SaveFileDialog frmSave = new SaveFileDialog();
            frmSave.Filter = "(*.csv)|*.csv";
            frmSave.FileName = "shcedule1.csv";
            if (frmSave.ShowDialog() == DialogResult.OK && frmSave.FileName != "")
            {
                // Проверяем наличие файла
                if (File.Exists(frmSave.FileName) == true)
                {
                    try
                    {
                        File.Delete(frmSave.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                StreamWriter writer = new StreamWriter(frmSave.FileName, false, Encoding.GetEncoding(1251));

                string csvHeadRow = "";
                foreach (DataGridViewColumn column in dgvShedule.Columns)
                {
                    string value = column.HeaderText;
                    value = value.Replace("\n", " ");
                    if (value.IndexOf("\r") != -1)
                    {
                        value = value.Insert(0, "\"");
                        value = value.Insert(value.Length - 1, "\"");
                        value = value.Replace("\r", "\r\n");
                    }
                    csvHeadRow += value + ";";
                }
                writer.WriteLine(csvHeadRow);

                foreach (DataGridViewRow row in dgvShedule.Rows)
                {
                    string csvRow = "";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string value = cell.Value.ToString();
                        value = value.Replace("\n", " ");
                        if (value.IndexOf("\r") != -1)
                        {
                            value = value.Insert(0, "\"");
                            value = value.Insert(value.Length - 1, "\"");
                            value = value.Replace("\r", "\r\n");
                        }

                        csvRow += value + ";";
                    }
                    writer.WriteLine(csvRow);
                }

                writer.Close();
            }
        }
    }
}
