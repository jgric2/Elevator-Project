namespace Basic_Elevator
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.trackBarSimulationSpeed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelPeopleInLift = new System.Windows.Forms.Label();
            this.labelPeopleWaiting = new System.Windows.Forms.Label();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelLiftWeight = new System.Windows.Forms.Label();
            this.listViewPeopleInLift = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelLiftCurrentFloor = new System.Windows.Forms.Label();
            this.labelCurrentDirection = new System.Windows.Forms.Label();
            this.listViewWaiting = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numericUpDownPeopleToSimulate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSim = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelLiftShaft = new System.Windows.Forms.Panel();
            this.panelFloors = new System.Windows.Forms.Panel();
            this.panelElevatorCar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSimulationSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeopleToSimulate)).BeginInit();
            this.panelSim.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelLiftShaft.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(801, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start Simulation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBarSimulationSpeed
            // 
            this.trackBarSimulationSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSimulationSpeed.Location = new System.Drawing.Point(300, 490);
            this.trackBarSimulationSpeed.Maximum = 1000;
            this.trackBarSimulationSpeed.Minimum = 1;
            this.trackBarSimulationSpeed.Name = "trackBarSimulationSpeed";
            this.trackBarSimulationSpeed.Size = new System.Drawing.Size(494, 45);
            this.trackBarSimulationSpeed.TabIndex = 2;
            this.trackBarSimulationSpeed.Value = 100;
            this.trackBarSimulationSpeed.Scroll += new System.EventHandler(this.trackBarSimulationSpeed_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Simulation Speed";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listViewWaiting);
            this.groupBox1.Controls.Add(this.labelCurrentDirection);
            this.groupBox1.Controls.Add(this.labelLiftCurrentFloor);
            this.groupBox1.Controls.Add(this.listViewPeopleInLift);
            this.groupBox1.Controls.Add(this.labelLiftWeight);
            this.groupBox1.Controls.Add(this.labelPeopleWaiting);
            this.groupBox1.Controls.Add(this.labelPeopleInLift);
            this.groupBox1.Location = new System.Drawing.Point(801, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 443);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labelPeopleInLift
            // 
            this.labelPeopleInLift.AutoSize = true;
            this.labelPeopleInLift.Location = new System.Drawing.Point(9, 71);
            this.labelPeopleInLift.Name = "labelPeopleInLift";
            this.labelPeopleInLift.Size = new System.Drawing.Size(70, 13);
            this.labelPeopleInLift.TabIndex = 0;
            this.labelPeopleInLift.Text = "People in lift: ";
            // 
            // labelPeopleWaiting
            // 
            this.labelPeopleWaiting.AutoSize = true;
            this.labelPeopleWaiting.Location = new System.Drawing.Point(6, 239);
            this.labelPeopleWaiting.Name = "labelPeopleWaiting";
            this.labelPeopleWaiting.Size = new System.Drawing.Size(85, 13);
            this.labelPeopleWaiting.TabIndex = 1;
            this.labelPeopleWaiting.Text = "People Waiting: ";
            // 
            // listViewLog
            // 
            this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewLog.GridLines = true;
            this.listViewLog.HideSelection = false;
            this.listViewLog.Location = new System.Drawing.Point(298, 12);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(496, 457);
            this.listViewLog.TabIndex = 5;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Duration";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Person(s)";
            this.columnHeader2.Width = 154;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 274;
            // 
            // labelLiftWeight
            // 
            this.labelLiftWeight.AutoSize = true;
            this.labelLiftWeight.Location = new System.Drawing.Point(9, 16);
            this.labelLiftWeight.Name = "labelLiftWeight";
            this.labelLiftWeight.Size = new System.Drawing.Size(73, 13);
            this.labelLiftWeight.TabIndex = 2;
            this.labelLiftWeight.Text = "Lift weight kg:";
            // 
            // listViewPeopleInLift
            // 
            this.listViewPeopleInLift.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader10});
            this.listViewPeopleInLift.GridLines = true;
            this.listViewPeopleInLift.HideSelection = false;
            this.listViewPeopleInLift.Location = new System.Drawing.Point(6, 87);
            this.listViewPeopleInLift.Name = "listViewPeopleInLift";
            this.listViewPeopleInLift.Size = new System.Drawing.Size(322, 149);
            this.listViewPeopleInLift.TabIndex = 3;
            this.listViewPeopleInLift.UseCompatibleStateImageBehavior = false;
            this.listViewPeopleInLift.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Weight";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Destination";
            this.columnHeader6.Width = 79;
            // 
            // labelLiftCurrentFloor
            // 
            this.labelLiftCurrentFloor.AutoSize = true;
            this.labelLiftCurrentFloor.Location = new System.Drawing.Point(9, 34);
            this.labelLiftCurrentFloor.Name = "labelLiftCurrentFloor";
            this.labelLiftCurrentFloor.Size = new System.Drawing.Size(73, 13);
            this.labelLiftCurrentFloor.TabIndex = 4;
            this.labelLiftCurrentFloor.Text = "Lift weight kg:";
            // 
            // labelCurrentDirection
            // 
            this.labelCurrentDirection.AutoSize = true;
            this.labelCurrentDirection.Location = new System.Drawing.Point(9, 52);
            this.labelCurrentDirection.Name = "labelCurrentDirection";
            this.labelCurrentDirection.Size = new System.Drawing.Size(89, 13);
            this.labelCurrentDirection.TabIndex = 5;
            this.labelCurrentDirection.Text = "Current Direction:";
            // 
            // listViewWaiting
            // 
            this.listViewWaiting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewWaiting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewWaiting.GridLines = true;
            this.listViewWaiting.HideSelection = false;
            this.listViewWaiting.Location = new System.Drawing.Point(6, 255);
            this.listViewWaiting.Name = "listViewWaiting";
            this.listViewWaiting.Size = new System.Drawing.Size(322, 180);
            this.listViewWaiting.TabIndex = 6;
            this.listViewWaiting.UseCompatibleStateImageBehavior = false;
            this.listViewWaiting.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Floor";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Count";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Combined Weight";
            this.columnHeader9.Width = 117;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Direction";
            this.columnHeader10.Width = 77;
            // 
            // numericUpDownPeopleToSimulate
            // 
            this.numericUpDownPeopleToSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPeopleToSimulate.Location = new System.Drawing.Point(1050, 33);
            this.numericUpDownPeopleToSimulate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPeopleToSimulate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPeopleToSimulate.Name = "numericUpDownPeopleToSimulate";
            this.numericUpDownPeopleToSimulate.Size = new System.Drawing.Size(85, 20);
            this.numericUpDownPeopleToSimulate.TabIndex = 6;
            this.numericUpDownPeopleToSimulate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1039, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "People to simulate:";
            // 
            // panelSim
            // 
            this.panelSim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSim.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelSim.Controls.Add(this.tableLayoutPanel1);
            this.panelSim.Location = new System.Drawing.Point(7, 7);
            this.panelSim.Name = "panelSim";
            this.panelSim.Size = new System.Drawing.Size(285, 510);
            this.panelSim.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.75439F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.24561F));
            this.tableLayoutPanel1.Controls.Add(this.panelLiftShaft, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelFloors, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 510);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelLiftShaft
            // 
            this.panelLiftShaft.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLiftShaft.Controls.Add(this.panelElevatorCar);
            this.panelLiftShaft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLiftShaft.Location = new System.Drawing.Point(0, 0);
            this.panelLiftShaft.Margin = new System.Windows.Forms.Padding(0);
            this.panelLiftShaft.Name = "panelLiftShaft";
            this.panelLiftShaft.Size = new System.Drawing.Size(119, 510);
            this.panelLiftShaft.TabIndex = 0;
            // 
            // panelFloors
            // 
            this.panelFloors.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelFloors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFloors.Location = new System.Drawing.Point(119, 0);
            this.panelFloors.Margin = new System.Windows.Forms.Padding(0);
            this.panelFloors.Name = "panelFloors";
            this.panelFloors.Size = new System.Drawing.Size(166, 510);
            this.panelFloors.TabIndex = 1;
            this.panelFloors.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFloors_Paint);
            // 
            // panelElevatorCar
            // 
            this.panelElevatorCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelElevatorCar.BackgroundImage = global::Basic_Elevator.Properties.Resources.ElevatorClosed1;
            this.panelElevatorCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelElevatorCar.Location = new System.Drawing.Point(0, 437);
            this.panelElevatorCar.Name = "panelElevatorCar";
            this.panelElevatorCar.Size = new System.Drawing.Size(117, 73);
            this.panelElevatorCar.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 521);
            this.Controls.Add(this.panelSim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownPeopleToSimulate);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarSimulationSpeed);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "James Grice, Elevator Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSimulationSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPeopleToSimulate)).EndInit();
            this.panelSim.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelLiftShaft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBarSimulationSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPeopleWaiting;
        private System.Windows.Forms.Label labelPeopleInLift;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label labelLiftWeight;
        private System.Windows.Forms.Label labelLiftCurrentFloor;
        private System.Windows.Forms.ListView listViewPeopleInLift;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label labelCurrentDirection;
        private System.Windows.Forms.ListView listViewWaiting;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.NumericUpDown numericUpDownPeopleToSimulate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSim;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelLiftShaft;
        private System.Windows.Forms.Panel panelElevatorCar;
        private System.Windows.Forms.Panel panelFloors;
    }
}

