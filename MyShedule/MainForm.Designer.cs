﻿namespace MyShedule
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dgvShedule = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShedule = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbCreateClearShedule = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbCreateShedule = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveSheduleToFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSheduleFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbView = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsbBrushTrigger = new System.Windows.Forms.ToolStripButton();
            this.tsbFreeTime = new System.Windows.Forms.ToolStripButton();
            this.tsbBlockTime = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbEducationLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.tbsTeachers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbWatchTrigger = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDown = new System.Windows.Forms.ToolStripButton();
            this.tsbUp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvDistribute = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectLesson2 = new System.Windows.Forms.Button();
            this.txtTypeLesson2 = new System.Windows.Forms.Label();
            this.txtRoom2 = new System.Windows.Forms.Label();
            this.txtDiscipline2 = new System.Windows.Forms.Label();
            this.txtTeacher2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectLesson1 = new System.Windows.Forms.Button();
            this.txtTypeLesson1 = new System.Windows.Forms.Label();
            this.txtRoom1 = new System.Windows.Forms.Label();
            this.txtDiscipline1 = new System.Windows.Forms.Label();
            this.txtTeacher1 = new System.Windows.Forms.Label();
            this.btnExchangeLessons = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvShedule
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvShedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShedule.Location = new System.Drawing.Point(0, 28);
            this.dgvShedule.Margin = new System.Windows.Forms.Padding(4);
            this.dgvShedule.Name = "dgvShedule";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShedule.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvShedule.RowHeadersWidth = 51;
            this.dgvShedule.RowTemplate.Height = 28;
            this.dgvShedule.Size = new System.Drawing.Size(1131, 410);
            this.dgvShedule.TabIndex = 0;
            this.dgvShedule.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShedule_CellContentClick);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.tsbShedule,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cmbView,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tsbBrushTrigger,
            this.tsbFreeTime,
            this.tsbBlockTime,
            this.toolStripSeparator4,
            this.tsbOptions,
            this.toolStripDropDownButton1,
            this.tsbWatchTrigger});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1131, 28);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 25);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Visible = false;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 25);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            this.bindingNavigatorCountItem.Visible = false;
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 25);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Visible = false;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 25);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            this.bindingNavigatorMoveFirstItem.Visible = false;
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 25);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem.Visible = false;
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 28);
            this.bindingNavigatorSeparator.Visible = false;
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(65, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem.Visible = false;
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 28);
            this.bindingNavigatorSeparator1.Visible = false;
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 25);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            this.bindingNavigatorMoveNextItem.Visible = false;
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 25);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            this.bindingNavigatorMoveLastItem.Visible = false;
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbShedule
            // 
            this.tsbShedule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreateClearShedule,
            this.tsbCreateShedule,
            this.tsiExportExcel,
            this.tsmiSaveSheduleToFile,
            this.tsmiOpenSheduleFromFile});
            this.tsbShedule.Image = global::MyShedule.Properties.Resources.clock;
            this.tsbShedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShedule.Name = "tsbShedule";
            this.tsbShedule.Size = new System.Drawing.Size(125, 25);
            this.tsbShedule.Text = "Расписание";
            // 
            // tsbCreateClearShedule
            // 
            this.tsbCreateClearShedule.Image = global::MyShedule.Properties.Resources.picture_empty;
            this.tsbCreateClearShedule.Name = "tsbCreateClearShedule";
            this.tsbCreateClearShedule.Size = new System.Drawing.Size(304, 26);
            this.tsbCreateClearShedule.Text = "Создать пустое расписание";
            this.tsbCreateClearShedule.Click += new System.EventHandler(this.tsbCreateClearShedule_Click);
            // 
            // tsbCreateShedule
            // 
            this.tsbCreateShedule.Image = global::MyShedule.Properties.Resources.clock_play;
            this.tsbCreateShedule.Name = "tsbCreateShedule";
            this.tsbCreateShedule.Size = new System.Drawing.Size(304, 26);
            this.tsbCreateShedule.Text = "Сгенерировать расписание";
            this.tsbCreateShedule.Click += new System.EventHandler(this.tsbCreateShedule_Click);
            // 
            // tsiExportExcel
            // 
            this.tsiExportExcel.Image = global::MyShedule.Properties.Resources.page_white_word;
            this.tsiExportExcel.Name = "tsiExportExcel";
            this.tsiExportExcel.Size = new System.Drawing.Size(304, 26);
            this.tsiExportExcel.Text = "Экспорт в Word";
            this.tsiExportExcel.Click += new System.EventHandler(this.tsiExportExcel_Click);
            // 
            // tsmiSaveSheduleToFile
            // 
            this.tsmiSaveSheduleToFile.Image = global::MyShedule.Properties.Resources.page_save1;
            this.tsmiSaveSheduleToFile.Name = "tsmiSaveSheduleToFile";
            this.tsmiSaveSheduleToFile.Size = new System.Drawing.Size(304, 26);
            this.tsmiSaveSheduleToFile.Text = "Сохранить расписание";
            this.tsmiSaveSheduleToFile.Click += new System.EventHandler(this.tsmiSaveSheduleToFile_Click);
            // 
            // tsmiOpenSheduleFromFile
            // 
            this.tsmiOpenSheduleFromFile.Image = global::MyShedule.Properties.Resources.clock_link;
            this.tsmiOpenSheduleFromFile.Name = "tsmiOpenSheduleFromFile";
            this.tsmiOpenSheduleFromFile.Size = new System.Drawing.Size(304, 26);
            this.tsmiOpenSheduleFromFile.Text = "Открыть расписание из файла";
            this.tsmiOpenSheduleFromFile.Click += new System.EventHandler(this.tsmiOpenSheduleFromFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(38, 25);
            this.toolStripLabel1.Text = "Вид:";
            // 
            // cmbView
            // 
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(160, 28);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(81, 25);
            this.toolStripLabel2.Text = "Занятость:";
            // 
            // tsbBrushTrigger
            // 
            this.tsbBrushTrigger.Image = global::MyShedule.Properties.Resources.pencil_add;
            this.tsbBrushTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBrushTrigger.Name = "tsbBrushTrigger";
            this.tsbBrushTrigger.Size = new System.Drawing.Size(57, 25);
            this.tsbBrushTrigger.Text = "Вкл";
            this.tsbBrushTrigger.Click += new System.EventHandler(this.tsbBrushTrigger_Click);
            // 
            // tsbFreeTime
            // 
            this.tsbFreeTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFreeTime.Image = global::MyShedule.Properties.Resources.time;
            this.tsbFreeTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFreeTime.Name = "tsbFreeTime";
            this.tsbFreeTime.Size = new System.Drawing.Size(29, 25);
            this.tsbFreeTime.Text = "Освободить часы занятия";
            this.tsbFreeTime.Click += new System.EventHandler(this.tsbFreeTime_Click);
            // 
            // tsbBlockTime
            // 
            this.tsbBlockTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBlockTime.Image = global::MyShedule.Properties.Resources.time_delete;
            this.tsbBlockTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBlockTime.Name = "tsbBlockTime";
            this.tsbBlockTime.Size = new System.Drawing.Size(29, 25);
            this.tsbBlockTime.Text = "Проставить занятость часам";
            this.tsbBlockTime.Click += new System.EventHandler(this.tsbBlockTime_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // tsbOptions
            // 
            this.tsbOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbOptions.Image = global::MyShedule.Properties.Resources.cog_edit;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(108, 25);
            this.tsbOptions.Text = "Настройки";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEducationLoad,
            this.tsbRooms,
            this.tbsTeachers});
            this.toolStripDropDownButton1.Image = global::MyShedule.Properties.Resources.pictures;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(137, 25);
            this.toolStripDropDownButton1.Text = "Справочники";
            // 
            // tsbEducationLoad
            // 
            this.tsbEducationLoad.Image = global::MyShedule.Properties.Resources.status_away;
            this.tsbEducationLoad.Name = "tsbEducationLoad";
            this.tsbEducationLoad.Size = new System.Drawing.Size(201, 26);
            this.tsbEducationLoad.Text = "Нагрузка";
            this.tsbEducationLoad.Click += new System.EventHandler(this.tsbEducationLoad_Click);
            // 
            // tsbRooms
            // 
            this.tsbRooms.Image = global::MyShedule.Properties.Resources.door_open;
            this.tsbRooms.Name = "tsbRooms";
            this.tsbRooms.Size = new System.Drawing.Size(201, 26);
            this.tsbRooms.Text = "Аудитории";
            this.tsbRooms.Click += new System.EventHandler(this.tsbRooms_Click);
            // 
            // tbsTeachers
            // 
            this.tbsTeachers.Name = "tbsTeachers";
            this.tbsTeachers.Size = new System.Drawing.Size(201, 26);
            this.tbsTeachers.Text = "Преподаватели";
            this.tbsTeachers.Click += new System.EventHandler(this.tbsTeachers_Click);
            // 
            // tsbWatchTrigger
            // 
            this.tsbWatchTrigger.Image = global::MyShedule.Properties.Resources.table_row_insert;
            this.tsbWatchTrigger.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWatchTrigger.Name = "tsbWatchTrigger";
            this.tsbWatchTrigger.Size = new System.Drawing.Size(124, 25);
            this.tsbWatchTrigger.Text = "Показать все";
            this.tsbWatchTrigger.Click += new System.EventHandler(this.tsbWatchTrigger_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvShedule);
            this.splitContainer1.Panel1.Controls.Add(this.bindingNavigator1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1131, 610);
            this.splitContainer1.SplitterDistance = 465;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDown,
            this.tsbUp,
            this.toolStripSeparator5,
            this.toolStripLabel3,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 438);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1131, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbDown
            // 
            this.tsbDown.Image = global::MyShedule.Properties.Resources.arrow_down;
            this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDown.Name = "tsbDown";
            this.tsbDown.Size = new System.Drawing.Size(83, 24);
            this.tsbDown.Text = "Скрыть";
            this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
            // 
            // tsbUp
            // 
            this.tsbUp.Image = global::MyShedule.Properties.Resources.arrow_up;
            this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUp.Name = "tsbUp";
            this.tsbUp.Size = new System.Drawing.Size(97, 24);
            this.tsbUp.Text = "Показать";
            this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(194, 24);
            this.toolStripLabel3.Text = "Дополнительные функции";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1131, 140);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvDistribute);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1123, 111);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Состояния генерации";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvDistribute
            // 
            this.lvDistribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDistribute.HideSelection = false;
            this.lvDistribute.Location = new System.Drawing.Point(4, 4);
            this.lvDistribute.Margin = new System.Windows.Forms.Padding(4);
            this.lvDistribute.Name = "lvDistribute";
            this.lvDistribute.Size = new System.Drawing.Size(1115, 103);
            this.lvDistribute.TabIndex = 0;
            this.lvDistribute.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.btnExchangeLessons);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1123, 111);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Перемещение занятий";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Обменять местами занятия";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectLesson2);
            this.groupBox2.Controls.Add(this.txtTypeLesson2);
            this.groupBox2.Controls.Add(this.txtRoom2);
            this.groupBox2.Controls.Add(this.txtDiscipline2);
            this.groupBox2.Controls.Add(this.txtTeacher2);
            this.groupBox2.Location = new System.Drawing.Point(619, 23);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(590, 130);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Занятие 2";
            // 
            // btnSelectLesson2
            // 
            this.btnSelectLesson2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectLesson2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectLesson2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectLesson2.Image = global::MyShedule.Properties.Resources.cursor;
            this.btnSelectLesson2.Location = new System.Drawing.Point(8, 23);
            this.btnSelectLesson2.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectLesson2.Name = "btnSelectLesson2";
            this.btnSelectLesson2.Size = new System.Drawing.Size(98, 57);
            this.btnSelectLesson2.TabIndex = 45;
            this.btnSelectLesson2.Text = "Выбрать";
            this.btnSelectLesson2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelectLesson2.UseVisualStyleBackColor = true;
            this.btnSelectLesson2.Click += new System.EventHandler(this.btnSelectLesson2_Click);
            // 
            // txtTypeLesson2
            // 
            this.txtTypeLesson2.AutoSize = true;
            this.txtTypeLesson2.Location = new System.Drawing.Point(130, 94);
            this.txtTypeLesson2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTypeLesson2.Name = "txtTypeLesson2";
            this.txtTypeLesson2.Size = new System.Drawing.Size(91, 17);
            this.txtTypeLesson2.TabIndex = 44;
            this.txtTypeLesson2.Text = "Тип занятия";
            // 
            // txtRoom2
            // 
            this.txtRoom2.AutoSize = true;
            this.txtRoom2.Location = new System.Drawing.Point(130, 70);
            this.txtRoom2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtRoom2.Name = "txtRoom2";
            this.txtRoom2.Size = new System.Drawing.Size(79, 17);
            this.txtRoom2.TabIndex = 43;
            this.txtRoom2.Text = "Аудитория";
            // 
            // txtDiscipline2
            // 
            this.txtDiscipline2.AutoSize = true;
            this.txtDiscipline2.Location = new System.Drawing.Point(130, 48);
            this.txtDiscipline2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtDiscipline2.Name = "txtDiscipline2";
            this.txtDiscipline2.Size = new System.Drawing.Size(90, 17);
            this.txtDiscipline2.TabIndex = 42;
            this.txtDiscipline2.Text = "Дисциплина";
            // 
            // txtTeacher2
            // 
            this.txtTeacher2.AutoSize = true;
            this.txtTeacher2.Location = new System.Drawing.Point(130, 23);
            this.txtTeacher2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTeacher2.Name = "txtTeacher2";
            this.txtTeacher2.Size = new System.Drawing.Size(111, 17);
            this.txtTeacher2.TabIndex = 41;
            this.txtTeacher2.Text = "Преподаватель";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectLesson1);
            this.groupBox1.Controls.Add(this.txtTypeLesson1);
            this.groupBox1.Controls.Add(this.txtRoom1);
            this.groupBox1.Controls.Add(this.txtDiscipline1);
            this.groupBox1.Controls.Add(this.txtTeacher1);
            this.groupBox1.Location = new System.Drawing.Point(11, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(484, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Занятие 1";
            // 
            // btnSelectLesson1
            // 
            this.btnSelectLesson1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelectLesson1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectLesson1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectLesson1.Image = global::MyShedule.Properties.Resources.cursor;
            this.btnSelectLesson1.Location = new System.Drawing.Point(377, 23);
            this.btnSelectLesson1.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectLesson1.Name = "btnSelectLesson1";
            this.btnSelectLesson1.Size = new System.Drawing.Size(99, 57);
            this.btnSelectLesson1.TabIndex = 41;
            this.btnSelectLesson1.Text = "Выбрать";
            this.btnSelectLesson1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelectLesson1.UseVisualStyleBackColor = true;
            this.btnSelectLesson1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTypeLesson1
            // 
            this.txtTypeLesson1.AutoSize = true;
            this.txtTypeLesson1.Location = new System.Drawing.Point(21, 94);
            this.txtTypeLesson1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTypeLesson1.Name = "txtTypeLesson1";
            this.txtTypeLesson1.Size = new System.Drawing.Size(91, 17);
            this.txtTypeLesson1.TabIndex = 40;
            this.txtTypeLesson1.Text = "Тип занятия";
            // 
            // txtRoom1
            // 
            this.txtRoom1.AutoSize = true;
            this.txtRoom1.Location = new System.Drawing.Point(21, 70);
            this.txtRoom1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtRoom1.Name = "txtRoom1";
            this.txtRoom1.Size = new System.Drawing.Size(79, 17);
            this.txtRoom1.TabIndex = 39;
            this.txtRoom1.Text = "Аудитория";
            // 
            // txtDiscipline1
            // 
            this.txtDiscipline1.AutoSize = true;
            this.txtDiscipline1.Location = new System.Drawing.Point(21, 48);
            this.txtDiscipline1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtDiscipline1.Name = "txtDiscipline1";
            this.txtDiscipline1.Size = new System.Drawing.Size(90, 17);
            this.txtDiscipline1.TabIndex = 38;
            this.txtDiscipline1.Text = "Дисциплина";
            // 
            // txtTeacher1
            // 
            this.txtTeacher1.AutoSize = true;
            this.txtTeacher1.Location = new System.Drawing.Point(21, 23);
            this.txtTeacher1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTeacher1.Name = "txtTeacher1";
            this.txtTeacher1.Size = new System.Drawing.Size(111, 17);
            this.txtTeacher1.TabIndex = 37;
            this.txtTeacher1.Text = "Преподаватель";
            // 
            // btnExchangeLessons
            // 
            this.btnExchangeLessons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExchangeLessons.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExchangeLessons.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExchangeLessons.Image = global::MyShedule.Properties.Resources.arrow_refresh;
            this.btnExchangeLessons.Location = new System.Drawing.Point(509, 46);
            this.btnExchangeLessons.Margin = new System.Windows.Forms.Padding(4);
            this.btnExchangeLessons.Name = "btnExchangeLessons";
            this.btnExchangeLessons.Size = new System.Drawing.Size(101, 57);
            this.btnExchangeLessons.TabIndex = 35;
            this.btnExchangeLessons.Text = "Обменять";
            this.btnExchangeLessons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExchangeLessons.UseVisualStyleBackColor = true;
            this.btnExchangeLessons.Click += new System.EventHandler(this.btnExchangeLessons_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1131, 610);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Составление расписания";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShedule;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cmbView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsbBrushTrigger;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbFreeTime;
        private System.Windows.Forms.ToolStripButton tsbBlockTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton tsbShedule;
        private System.Windows.Forms.ToolStripMenuItem tsbCreateClearShedule;
        private System.Windows.Forms.ToolStripMenuItem tsbCreateShedule;
        private System.Windows.Forms.ToolStripMenuItem tsiExportExcel;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsbEducationLoad;
        private System.Windows.Forms.ToolStripMenuItem tsbRooms;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDown;
        private System.Windows.Forms.ToolStripButton tsbUp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvDistribute;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton tsbWatchTrigger;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExchangeLessons;
        private System.Windows.Forms.Label txtTypeLesson2;
        private System.Windows.Forms.Label txtRoom2;
        private System.Windows.Forms.Label txtDiscipline2;
        private System.Windows.Forms.Label txtTeacher2;
        private System.Windows.Forms.Button btnSelectLesson1;
        private System.Windows.Forms.Label txtTypeLesson1;
        private System.Windows.Forms.Label txtRoom1;
        private System.Windows.Forms.Label txtDiscipline1;
        private System.Windows.Forms.Label txtTeacher1;
        private System.Windows.Forms.Button btnSelectLesson2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveSheduleToFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSheduleFromFile;
        private System.Windows.Forms.ToolStripMenuItem tbsTeachers;

    }
}

