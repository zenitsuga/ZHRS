namespace MyHRS.Screens.Recruitment
{
    partial class HiringProcess
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbApplicationType = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbApplicationStatus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbApplicationDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.btnStatus = new System.Windows.Forms.Button();
            this.panelPersonalInfo = new System.Windows.Forms.Panel();
            this.tbPermanentAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPresentAdd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbGender = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNationality = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCivilStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEmailAdd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSuffix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMiddlename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFirstname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPersonalInfo = new System.Windows.Forms.Button();
            this.dgvHiringList = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbApplicantStatus = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cmsList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelPersonalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiringList)).BeginInit();
            this.cmsList.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 571);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Applicant Here";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(6, 42);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(286, 523);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(286, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 571);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(946, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblProgressStatus);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(304, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 571);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Record(s)";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(6, 537);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Update Information";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tbApplicationType);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.tbApplicationStatus);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.tbApplicationDate);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panelStatus);
            this.panel1.Controls.Add(this.panelPersonalInfo);
            this.panel1.Location = new System.Drawing.Point(6, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 514);
            this.panel1.TabIndex = 0;
            // 
            // tbApplicationType
            // 
            this.tbApplicationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbApplicationType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbApplicationType.Location = new System.Drawing.Point(74, 265);
            this.tbApplicationType.Name = "tbApplicationType";
            this.tbApplicationType.ReadOnly = true;
            this.tbApplicationType.Size = new System.Drawing.Size(203, 20);
            this.tbApplicationType.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 269);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Type:";
            // 
            // tbApplicationStatus
            // 
            this.tbApplicationStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbApplicationStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbApplicationStatus.Location = new System.Drawing.Point(74, 239);
            this.tbApplicationStatus.Name = "tbApplicationStatus";
            this.tbApplicationStatus.ReadOnly = true;
            this.tbApplicationStatus.Size = new System.Drawing.Size(203, 20);
            this.tbApplicationStatus.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Status:";
            // 
            // tbApplicationDate
            // 
            this.tbApplicationDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbApplicationDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbApplicationDate.Location = new System.Drawing.Point(74, 213);
            this.tbApplicationDate.Name = "tbApplicationDate";
            this.tbApplicationDate.ReadOnly = true;
            this.tbApplicationDate.Size = new System.Drawing.Size(203, 20);
            this.tbApplicationDate.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Date:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(2, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(627, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Application Information";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.Controls.Add(this.checkBox1);
            this.panelStatus.Controls.Add(this.cmbApplicantStatus);
            this.panelStatus.Controls.Add(this.label14);
            this.panelStatus.Controls.Add(this.dgvHiringList);
            this.panelStatus.Controls.Add(this.btnStatus);
            this.panelStatus.Location = new System.Drawing.Point(0, 299);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(630, 212);
            this.panelStatus.TabIndex = 1;
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.Location = new System.Drawing.Point(3, 3);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(627, 25);
            this.btnStatus.TabIndex = 0;
            this.btnStatus.Text = "Hiring List";
            this.btnStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatus.UseVisualStyleBackColor = false;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // panelPersonalInfo
            // 
            this.panelPersonalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPersonalInfo.Controls.Add(this.tbPermanentAddress);
            this.panelPersonalInfo.Controls.Add(this.label10);
            this.panelPersonalInfo.Controls.Add(this.tbPresentAdd);
            this.panelPersonalInfo.Controls.Add(this.label9);
            this.panelPersonalInfo.Controls.Add(this.tbGender);
            this.panelPersonalInfo.Controls.Add(this.label8);
            this.panelPersonalInfo.Controls.Add(this.tbNationality);
            this.panelPersonalInfo.Controls.Add(this.label7);
            this.panelPersonalInfo.Controls.Add(this.tbCivilStatus);
            this.panelPersonalInfo.Controls.Add(this.label6);
            this.panelPersonalInfo.Controls.Add(this.tbEmailAdd);
            this.panelPersonalInfo.Controls.Add(this.label5);
            this.panelPersonalInfo.Controls.Add(this.tbSuffix);
            this.panelPersonalInfo.Controls.Add(this.label4);
            this.panelPersonalInfo.Controls.Add(this.tbMiddlename);
            this.panelPersonalInfo.Controls.Add(this.label3);
            this.panelPersonalInfo.Controls.Add(this.tbFirstname);
            this.panelPersonalInfo.Controls.Add(this.label2);
            this.panelPersonalInfo.Controls.Add(this.tbLastname);
            this.panelPersonalInfo.Controls.Add(this.label1);
            this.panelPersonalInfo.Controls.Add(this.btnPersonalInfo);
            this.panelPersonalInfo.Location = new System.Drawing.Point(0, 0);
            this.panelPersonalInfo.Name = "panelPersonalInfo";
            this.panelPersonalInfo.Size = new System.Drawing.Size(630, 280);
            this.panelPersonalInfo.TabIndex = 0;
            // 
            // tbPermanentAddress
            // 
            this.tbPermanentAddress.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbPermanentAddress.Location = new System.Drawing.Point(114, 152);
            this.tbPermanentAddress.Name = "tbPermanentAddress";
            this.tbPermanentAddress.ReadOnly = true;
            this.tbPermanentAddress.Size = new System.Drawing.Size(483, 20);
            this.tbPermanentAddress.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Permanent Address:";
            // 
            // tbPresentAdd
            // 
            this.tbPresentAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbPresentAdd.Location = new System.Drawing.Point(114, 126);
            this.tbPresentAdd.Name = "tbPresentAdd";
            this.tbPresentAdd.ReadOnly = true;
            this.tbPresentAdd.Size = new System.Drawing.Size(484, 20);
            this.tbPresentAdd.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Present Address:";
            // 
            // tbGender
            // 
            this.tbGender.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbGender.Location = new System.Drawing.Point(336, 102);
            this.tbGender.Name = "tbGender";
            this.tbGender.ReadOnly = true;
            this.tbGender.Size = new System.Drawing.Size(177, 20);
            this.tbGender.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Gender:";
            // 
            // tbNationality
            // 
            this.tbNationality.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbNationality.Location = new System.Drawing.Point(99, 102);
            this.tbNationality.Name = "tbNationality";
            this.tbNationality.ReadOnly = true;
            this.tbNationality.Size = new System.Drawing.Size(153, 20);
            this.tbNationality.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nationality:";
            // 
            // tbCivilStatus
            // 
            this.tbCivilStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbCivilStatus.Location = new System.Drawing.Point(336, 78);
            this.tbCivilStatus.Name = "tbCivilStatus";
            this.tbCivilStatus.ReadOnly = true;
            this.tbCivilStatus.Size = new System.Drawing.Size(177, 20);
            this.tbCivilStatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Civil Status:";
            // 
            // tbEmailAdd
            // 
            this.tbEmailAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbEmailAdd.Location = new System.Drawing.Point(80, 78);
            this.tbEmailAdd.Name = "tbEmailAdd";
            this.tbEmailAdd.ReadOnly = true;
            this.tbEmailAdd.Size = new System.Drawing.Size(171, 20);
            this.tbEmailAdd.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email Address:";
            // 
            // tbSuffix
            // 
            this.tbSuffix.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbSuffix.Location = new System.Drawing.Point(336, 53);
            this.tbSuffix.Name = "tbSuffix";
            this.tbSuffix.ReadOnly = true;
            this.tbSuffix.Size = new System.Drawing.Size(262, 20);
            this.tbSuffix.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Suffix:";
            // 
            // tbMiddlename
            // 
            this.tbMiddlename.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbMiddlename.Location = new System.Drawing.Point(80, 54);
            this.tbMiddlename.Name = "tbMiddlename";
            this.tbMiddlename.ReadOnly = true;
            this.tbMiddlename.Size = new System.Drawing.Size(171, 20);
            this.tbMiddlename.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Middlename:";
            // 
            // tbFirstname
            // 
            this.tbFirstname.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbFirstname.Location = new System.Drawing.Point(336, 29);
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.ReadOnly = true;
            this.tbFirstname.Size = new System.Drawing.Size(188, 20);
            this.tbFirstname.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Firstname:";
            // 
            // tbLastname
            // 
            this.tbLastname.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbLastname.Location = new System.Drawing.Point(79, 30);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.ReadOnly = true;
            this.tbLastname.Size = new System.Drawing.Size(173, 20);
            this.tbLastname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lastname:";
            // 
            // btnPersonalInfo
            // 
            this.btnPersonalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPersonalInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPersonalInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonalInfo.Location = new System.Drawing.Point(3, 3);
            this.btnPersonalInfo.Name = "btnPersonalInfo";
            this.btnPersonalInfo.Size = new System.Drawing.Size(627, 23);
            this.btnPersonalInfo.TabIndex = 0;
            this.btnPersonalInfo.Text = "Personal Info";
            this.btnPersonalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonalInfo.UseVisualStyleBackColor = false;
            this.btnPersonalInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvHiringList
            // 
            this.dgvHiringList.AllowUserToAddRows = false;
            this.dgvHiringList.AllowUserToDeleteRows = false;
            this.dgvHiringList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHiringList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHiringList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHiringList.Location = new System.Drawing.Point(9, 57);
            this.dgvHiringList.Name = "dgvHiringList";
            this.dgvHiringList.ReadOnly = true;
            this.dgvHiringList.Size = new System.Drawing.Size(614, 152);
            this.dgvHiringList.TabIndex = 1;
            this.dgvHiringList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHiringList_CellContentClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Application Status:";
            // 
            // cmbApplicantStatus
            // 
            this.cmbApplicantStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplicantStatus.FormattingEnabled = true;
            this.cmbApplicantStatus.Location = new System.Drawing.Point(102, 33);
            this.cmbApplicantStatus.Name = "cmbApplicantStatus";
            this.cmbApplicantStatus.Size = new System.Drawing.Size(152, 21);
            this.cmbApplicantStatus.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(546, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Apply to All";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cmsList
            // 
            this.cmsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToListToolStripMenuItem,
            this.addToListToolStripMenuItem1});
            this.cmsList.Name = "cmsList";
            this.cmsList.Size = new System.Drawing.Size(132, 48);
            // 
            // addToListToolStripMenuItem
            // 
            this.addToListToolStripMenuItem.Name = "addToListToolStripMenuItem";
            this.addToListToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.addToListToolStripMenuItem.Text = "Refresh";
            this.addToListToolStripMenuItem.Click += new System.EventHandler(this.addToListToolStripMenuItem_Click);
            // 
            // addToListToolStripMenuItem1
            // 
            this.addToListToolStripMenuItem1.Name = "addToListToolStripMenuItem1";
            this.addToListToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.addToListToolStripMenuItem1.Text = "Add to List";
            this.addToListToolStripMenuItem1.Click += new System.EventHandler(this.addToListToolStripMenuItem1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(369, 532);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(261, 18);
            this.progressBar1.TabIndex = 2;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Location = new System.Drawing.Point(372, 552);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(47, 13);
            this.lblProgressStatus.TabIndex = 3;
            this.lblProgressStatus.Text = "Ready...";
            // 
            // HiringProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 593);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "HiringProcess";
            this.Text = "Hiring Process";
            this.Load += new System.EventHandler(this.HiringProcess_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.panelPersonalInfo.ResumeLayout(false);
            this.panelPersonalInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHiringList)).EndInit();
            this.cmsList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Panel panelPersonalInfo;
        private System.Windows.Forms.Button btnPersonalInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSuffix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMiddlename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFirstname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbPermanentAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPresentAdd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbGender;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNationality;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCivilStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEmailAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbApplicationType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbApplicationStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbApplicationDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cmbApplicantStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvHiringList;
        private System.Windows.Forms.ContextMenuStrip cmsList;
        private System.Windows.Forms.ToolStripMenuItem addToListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToListToolStripMenuItem1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressStatus;
    }
}