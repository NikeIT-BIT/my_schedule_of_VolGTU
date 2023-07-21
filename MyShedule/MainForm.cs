﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyShedule
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);

            LoadDictionatyes();
        }

        public EducationLoadAdapter EducationAdapter;
        public dsShedule SheduleDataSet;
        public SheduleWeeks Shedule;
        //public Employments emps;
        public List<SheduleRoom> Rooms;

        public List<SheduleTeacher> Teachers;

        public bool BrushActive = false;

        public bool WatchAll = true;

        private void LoadDictionatyes()
        {
            SheduleDataSet = new dsShedule();
            Rooms = new List<SheduleRoom>();
            Teachers = new List<SheduleTeacher>();

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
            if(BrushActive)
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
            EdicationLoadForm frmEdicationLoad = new EdicationLoadForm(Teachers);
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
            if (frmShedule.ShowDialog() != DialogResult.OK)
                return;

            Shedule = new SheduleWeeks(Rooms, GetSetting(), frmShedule.FirstDaySem);

            UpdateTableShedule();

            WatchTriggerStateChange(true);                           
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
            if (item1 != null && item2 != null)
            {
                SheduleLesson tmp1 = item1.Copy();
                item1.Time = item2.Time.Copy();
                item2.Time = tmp1.Time.Copy();
            }
            else if (item1 == null && item2 != null)
            {
                Shedule.GetLesson(time1, item2.Room).UpdateFields(item2.Teacher, item2.Discipline, item2.Groups, item2.Type, item2.Dates);
                item2.Clear();
            }
            else if (item1 != null && item2 == null)
            {
                Shedule.GetLesson(time2, item1.Room).UpdateFields(item1.Teacher, item1.Discipline, item1.Groups, item1.Type, item1.Dates);
                item1.Clear();
            }
        }

        private void btnExchangeLessons_Click(object sender, EventArgs e)
        {
            ExchangeLessons(L1, L3, T1, T3);
            ExchangeLessons(L2, L4, T2, T4);
            UpdateTableShedule();
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
                                 (item1 != null ? SheduleLessonType.Description(item2.Type) : String.Empty);
        }

        private void ViewSelectLesson(DataGridViewCell cell)
        {
            ShedulePointer Tag = cell.Tag as ShedulePointer;

            SheduleLesson lesson1 = Shedule.GetLesson(Tag.Time1, Tag.Room1);
            SheduleLesson lesson2 = Shedule.GetLesson(Tag.Time2, Tag.Room2);

            if (NumSelectLesson == 1)
            {
                SetDataSelectLessonForm(lesson1, lesson2, txtTeacher1, txtDiscipline1, txtRoom1, txtTypeLesson1);

                L1 = lesson1;
                L2 = lesson2;
                T1 = Tag.Time1.Copy();
                T2 = Tag.Time2.Copy();
            }
            else if (NumSelectLesson == 2)
            {
                SetDataSelectLessonForm(lesson1, lesson2, txtTeacher2, txtDiscipline2, txtRoom2, txtTypeLesson2);

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

            if (frmOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Shedule = SheduleSerializer.ReadData(frmOpen.FileName);

                    UpdateTableShedule();

                    if (Shedule != null)
                        Shedule.Employments.Clear();

                    WatchTriggerStateChange(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void tbsTeachers_Click(object sender, EventArgs e)
        {
            TeachersForm frmTeacher = new TeachersForm();
            frmTeacher.ds = SheduleDataSet;
            frmTeacher.ShowDialog();
            Teachers = DictionaryConverter.TeachersToList(frmTeacher.ds);

            //!!!!!!!!!!!!!!!!!!1
        }

        private void dgvShedule_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
