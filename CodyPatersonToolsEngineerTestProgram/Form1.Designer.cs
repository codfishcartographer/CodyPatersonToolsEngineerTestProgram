namespace CodyPatersonToolsEngineerTestProgram
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.troopListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dmgBox = new System.Windows.Forms.TextBox();
            this.healthBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.derivedTroopListBox = new System.Windows.Forms.ListBox();
            this.addDTroopButton = new System.Windows.Forms.Button();
            this.delDTroopButton = new System.Windows.Forms.Button();
            this.dNameLabel = new System.Windows.Forms.Label();
            this.dTypeLabel = new System.Windows.Forms.Label();
            this.dNameBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.dDmgBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dHealthBox = new System.Windows.Forms.TextBox();
            this.dDmgLabel = new System.Windows.Forms.Label();
            this.dHealthLabel = new System.Windows.Forms.Label();
            this.dTargetLabel = new System.Windows.Forms.Label();
            this.addTroopButton = new System.Windows.Forms.Button();
            this.delTroopButton = new System.Windows.Forms.Button();
            this.targetGround = new System.Windows.Forms.CheckBox();
            this.targetAir = new System.Windows.Forms.CheckBox();
            this.dTargetAir = new System.Windows.Forms.CheckBox();
            this.dTargetGround = new System.Windows.Forms.CheckBox();
            this.dTroopGroupBox = new System.Windows.Forms.GroupBox();
            this.dTypeAir = new System.Windows.Forms.CheckBox();
            this.dTypeGround = new System.Windows.Forms.CheckBox();
            this.typeAir = new System.Windows.Forms.CheckBox();
            this.typeGround = new System.Windows.Forms.CheckBox();
            this.saveBinButton = new System.Windows.Forms.Button();
            this.dTroopGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load JSON File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(271, 27);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 23);
            this.nameBox.TabIndex = 1;
            this.nameBox.Text = "Name";
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // troopListBox
            // 
            this.troopListBox.FormattingEnabled = true;
            this.troopListBox.ItemHeight = 15;
            this.troopListBox.Location = new System.Drawing.Point(12, 27);
            this.troopListBox.Name = "troopListBox";
            this.troopListBox.Size = new System.Drawing.Size(158, 304);
            this.troopListBox.TabIndex = 4;
            this.troopListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Damage";
            // 
            // dmgBox
            // 
            this.dmgBox.Location = new System.Drawing.Point(271, 85);
            this.dmgBox.Name = "dmgBox";
            this.dmgBox.Size = new System.Drawing.Size(100, 23);
            this.dmgBox.TabIndex = 8;
            this.dmgBox.Text = "Damage";
            this.dmgBox.TextChanged += new System.EventHandler(this.dmgBox_TextChanged);
            // 
            // healthBox
            // 
            this.healthBox.Location = new System.Drawing.Point(271, 114);
            this.healthBox.Name = "healthBox";
            this.healthBox.Size = new System.Drawing.Size(100, 23);
            this.healthBox.TabIndex = 9;
            this.healthBox.Text = "Health";
            this.healthBox.TextChanged += new System.EventHandler(this.healthBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Health";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Target";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Derived Troops";
            // 
            // derivedTroopListBox
            // 
            this.derivedTroopListBox.FormattingEnabled = true;
            this.derivedTroopListBox.ItemHeight = 15;
            this.derivedTroopListBox.Location = new System.Drawing.Point(176, 192);
            this.derivedTroopListBox.Name = "derivedTroopListBox";
            this.derivedTroopListBox.Size = new System.Drawing.Size(205, 139);
            this.derivedTroopListBox.TabIndex = 14;
            this.derivedTroopListBox.SelectedIndexChanged += new System.EventHandler(this.derivedTroopListBox_SelectedIndexChanged);
            // 
            // addDTroopButton
            // 
            this.addDTroopButton.Location = new System.Drawing.Point(176, 348);
            this.addDTroopButton.Name = "addDTroopButton";
            this.addDTroopButton.Size = new System.Drawing.Size(100, 43);
            this.addDTroopButton.TabIndex = 15;
            this.addDTroopButton.Text = "Add Derived Troop";
            this.addDTroopButton.UseVisualStyleBackColor = true;
            this.addDTroopButton.Click += new System.EventHandler(this.addDTroopButton_Click);
            // 
            // delDTroopButton
            // 
            this.delDTroopButton.Location = new System.Drawing.Point(282, 348);
            this.delDTroopButton.Name = "delDTroopButton";
            this.delDTroopButton.Size = new System.Drawing.Size(100, 43);
            this.delDTroopButton.TabIndex = 16;
            this.delDTroopButton.Text = "Delete Derived Troop";
            this.delDTroopButton.UseVisualStyleBackColor = true;
            this.delDTroopButton.Click += new System.EventHandler(this.delDTroopButton_Click);
            // 
            // dNameLabel
            // 
            this.dNameLabel.AutoSize = true;
            this.dNameLabel.Location = new System.Drawing.Point(6, 21);
            this.dNameLabel.Name = "dNameLabel";
            this.dNameLabel.Size = new System.Drawing.Size(39, 15);
            this.dNameLabel.TabIndex = 17;
            this.dNameLabel.Text = "Name";
            // 
            // dTypeLabel
            // 
            this.dTypeLabel.AutoSize = true;
            this.dTypeLabel.Location = new System.Drawing.Point(6, 53);
            this.dTypeLabel.Name = "dTypeLabel";
            this.dTypeLabel.Size = new System.Drawing.Size(31, 15);
            this.dTypeLabel.TabIndex = 18;
            this.dTypeLabel.Text = "Type";
            // 
            // dNameBox
            // 
            this.dNameBox.Location = new System.Drawing.Point(81, 21);
            this.dNameBox.Name = "dNameBox";
            this.dNameBox.Size = new System.Drawing.Size(100, 23);
            this.dNameBox.TabIndex = 19;
            this.dNameBox.Text = "Name";
            this.dNameBox.TextChanged += new System.EventHandler(this.dNameBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(334, 399);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(158, 39);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Save JSON File";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dDmgBox
            // 
            this.dDmgBox.Location = new System.Drawing.Point(81, 79);
            this.dDmgBox.Name = "dDmgBox";
            this.dDmgBox.Size = new System.Drawing.Size(100, 23);
            this.dDmgBox.TabIndex = 22;
            this.dDmgBox.Text = "Damage";
            this.dDmgBox.TextChanged += new System.EventHandler(this.dDmgBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Troops";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Troop Stats";
            // 
            // dHealthBox
            // 
            this.dHealthBox.Location = new System.Drawing.Point(81, 108);
            this.dHealthBox.Name = "dHealthBox";
            this.dHealthBox.Size = new System.Drawing.Size(100, 23);
            this.dHealthBox.TabIndex = 26;
            this.dHealthBox.Text = "Health";
            this.dHealthBox.TextChanged += new System.EventHandler(this.dHealthBox_TextChanged);
            // 
            // dDmgLabel
            // 
            this.dDmgLabel.AutoSize = true;
            this.dDmgLabel.Location = new System.Drawing.Point(6, 82);
            this.dDmgLabel.Name = "dDmgLabel";
            this.dDmgLabel.Size = new System.Drawing.Size(51, 15);
            this.dDmgLabel.TabIndex = 28;
            this.dDmgLabel.Text = "Damage";
            // 
            // dHealthLabel
            // 
            this.dHealthLabel.AutoSize = true;
            this.dHealthLabel.Location = new System.Drawing.Point(6, 111);
            this.dHealthLabel.Name = "dHealthLabel";
            this.dHealthLabel.Size = new System.Drawing.Size(42, 15);
            this.dHealthLabel.TabIndex = 29;
            this.dHealthLabel.Text = "Health";
            // 
            // dTargetLabel
            // 
            this.dTargetLabel.AutoSize = true;
            this.dTargetLabel.Location = new System.Drawing.Point(6, 140);
            this.dTargetLabel.Name = "dTargetLabel";
            this.dTargetLabel.Size = new System.Drawing.Size(39, 15);
            this.dTargetLabel.TabIndex = 30;
            this.dTargetLabel.Text = "Target";
            // 
            // addTroopButton
            // 
            this.addTroopButton.Location = new System.Drawing.Point(12, 348);
            this.addTroopButton.Name = "addTroopButton";
            this.addTroopButton.Size = new System.Drawing.Size(73, 43);
            this.addTroopButton.TabIndex = 31;
            this.addTroopButton.Text = "Add Troop";
            this.addTroopButton.UseVisualStyleBackColor = true;
            this.addTroopButton.Click += new System.EventHandler(this.addTroopButton_Click);
            // 
            // delTroopButton
            // 
            this.delTroopButton.Location = new System.Drawing.Point(97, 348);
            this.delTroopButton.Name = "delTroopButton";
            this.delTroopButton.Size = new System.Drawing.Size(73, 43);
            this.delTroopButton.TabIndex = 32;
            this.delTroopButton.Text = "Delete Troop";
            this.delTroopButton.UseVisualStyleBackColor = true;
            this.delTroopButton.Click += new System.EventHandler(this.delTroopButton_Click);
            // 
            // targetGround
            // 
            this.targetGround.AutoSize = true;
            this.targetGround.Location = new System.Drawing.Point(270, 145);
            this.targetGround.Name = "targetGround";
            this.targetGround.Size = new System.Drawing.Size(66, 19);
            this.targetGround.TabIndex = 36;
            this.targetGround.Text = "Ground";
            this.targetGround.UseVisualStyleBackColor = true;
            this.targetGround.CheckedChanged += new System.EventHandler(this.targetGround_CheckedChanged);
            // 
            // targetAir
            // 
            this.targetAir.AutoSize = true;
            this.targetAir.Location = new System.Drawing.Point(340, 145);
            this.targetAir.Name = "targetAir";
            this.targetAir.Size = new System.Drawing.Size(41, 19);
            this.targetAir.TabIndex = 37;
            this.targetAir.Text = "Air";
            this.targetAir.UseVisualStyleBackColor = true;
            this.targetAir.CheckedChanged += new System.EventHandler(this.targetAir_CheckedChanged);
            // 
            // dTargetAir
            // 
            this.dTargetAir.AutoSize = true;
            this.dTargetAir.Location = new System.Drawing.Point(150, 140);
            this.dTargetAir.Name = "dTargetAir";
            this.dTargetAir.Size = new System.Drawing.Size(41, 19);
            this.dTargetAir.TabIndex = 41;
            this.dTargetAir.Text = "Air";
            this.dTargetAir.UseVisualStyleBackColor = true;
            this.dTargetAir.CheckedChanged += new System.EventHandler(this.dTargetAir_CheckedChanged);
            // 
            // dTargetGround
            // 
            this.dTargetGround.AutoSize = true;
            this.dTargetGround.Location = new System.Drawing.Point(80, 140);
            this.dTargetGround.Name = "dTargetGround";
            this.dTargetGround.Size = new System.Drawing.Size(66, 19);
            this.dTargetGround.TabIndex = 40;
            this.dTargetGround.Text = "Ground";
            this.dTargetGround.UseVisualStyleBackColor = true;
            this.dTargetGround.CheckedChanged += new System.EventHandler(this.dTargetGround_CheckedChanged);
            // 
            // dTroopGroupBox
            // 
            this.dTroopGroupBox.Controls.Add(this.dTypeAir);
            this.dTroopGroupBox.Controls.Add(this.dNameLabel);
            this.dTroopGroupBox.Controls.Add(this.dTypeGround);
            this.dTroopGroupBox.Controls.Add(this.dTargetAir);
            this.dTroopGroupBox.Controls.Add(this.dTypeLabel);
            this.dTroopGroupBox.Controls.Add(this.dTargetGround);
            this.dTroopGroupBox.Controls.Add(this.dNameBox);
            this.dTroopGroupBox.Controls.Add(this.dDmgBox);
            this.dTroopGroupBox.Controls.Add(this.dHealthBox);
            this.dTroopGroupBox.Controls.Add(this.dDmgLabel);
            this.dTroopGroupBox.Controls.Add(this.dHealthLabel);
            this.dTroopGroupBox.Controls.Add(this.dTargetLabel);
            this.dTroopGroupBox.Location = new System.Drawing.Point(389, 174);
            this.dTroopGroupBox.Name = "dTroopGroupBox";
            this.dTroopGroupBox.Size = new System.Drawing.Size(272, 165);
            this.dTroopGroupBox.TabIndex = 42;
            this.dTroopGroupBox.TabStop = false;
            this.dTroopGroupBox.Text = "Derived Troop Stats - leave blank to copy parent";
            // 
            // dTypeAir
            // 
            this.dTypeAir.AutoSize = true;
            this.dTypeAir.Location = new System.Drawing.Point(151, 52);
            this.dTypeAir.Name = "dTypeAir";
            this.dTypeAir.Size = new System.Drawing.Size(41, 19);
            this.dTypeAir.TabIndex = 46;
            this.dTypeAir.Text = "Air";
            this.dTypeAir.UseVisualStyleBackColor = true;
            this.dTypeAir.CheckedChanged += new System.EventHandler(this.dTypeAir_CheckedChanged);
            // 
            // dTypeGround
            // 
            this.dTypeGround.AutoSize = true;
            this.dTypeGround.Location = new System.Drawing.Point(81, 52);
            this.dTypeGround.Name = "dTypeGround";
            this.dTypeGround.Size = new System.Drawing.Size(66, 19);
            this.dTypeGround.TabIndex = 45;
            this.dTypeGround.Text = "Ground";
            this.dTypeGround.UseVisualStyleBackColor = true;
            this.dTypeGround.CheckedChanged += new System.EventHandler(this.dTypeGround_CheckedChanged);
            // 
            // typeAir
            // 
            this.typeAir.AutoSize = true;
            this.typeAir.Location = new System.Drawing.Point(340, 58);
            this.typeAir.Name = "typeAir";
            this.typeAir.Size = new System.Drawing.Size(41, 19);
            this.typeAir.TabIndex = 44;
            this.typeAir.Text = "Air";
            this.typeAir.UseVisualStyleBackColor = true;
            this.typeAir.CheckedChanged += new System.EventHandler(this.typeAir_CheckedChanged);
            // 
            // typeGround
            // 
            this.typeGround.AutoSize = true;
            this.typeGround.Location = new System.Drawing.Point(270, 58);
            this.typeGround.Name = "typeGround";
            this.typeGround.Size = new System.Drawing.Size(66, 19);
            this.typeGround.TabIndex = 43;
            this.typeGround.Text = "Ground";
            this.typeGround.UseVisualStyleBackColor = true;
            this.typeGround.CheckedChanged += new System.EventHandler(this.typeGround_CheckedChanged);
            // 
            // saveBinButton
            // 
            this.saveBinButton.Location = new System.Drawing.Point(498, 399);
            this.saveBinButton.Name = "saveBinButton";
            this.saveBinButton.Size = new System.Drawing.Size(158, 39);
            this.saveBinButton.TabIndex = 45;
            this.saveBinButton.Text = "Save Binary File";
            this.saveBinButton.UseVisualStyleBackColor = true;
            this.saveBinButton.Click += new System.EventHandler(this.saveBinButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 450);
            this.Controls.Add(this.saveBinButton);
            this.Controls.Add(this.typeAir);
            this.Controls.Add(this.typeGround);
            this.Controls.Add(this.dTroopGroupBox);
            this.Controls.Add(this.targetAir);
            this.Controls.Add(this.targetGround);
            this.Controls.Add(this.delTroopButton);
            this.Controls.Add(this.addTroopButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.delDTroopButton);
            this.Controls.Add(this.addDTroopButton);
            this.Controls.Add(this.derivedTroopListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.healthBox);
            this.Controls.Add(this.dmgBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.troopListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Cody Paterson Troop Editor";
            this.dTroopGroupBox.ResumeLayout(false);
            this.dTroopGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox nameBox;
        private Label label1;
        private ListBox troopListBox;
        private Label label2;
        private Label label3;
        private TextBox dmgBox;
        private TextBox healthBox;
        private Label label4;
        private Label label5;
        private Label label6;
        private ListBox derivedTroopListBox;
        private Button addDTroopButton;
        private Button delDTroopButton;
        private Label dNameLabel;
        private Label dTypeLabel;
        private TextBox dNameBox;
        private Button saveButton;
        private TextBox dDmgBox;
        private Label label7;
        private Label label8;
        private TextBox dHealthBox;
        private Label dDmgLabel;
        private Label dHealthLabel;
        private Label dTargetLabel;
        private Button addTroopButton;
        private Button delTroopButton;
        private CheckBox targetGround;
        private CheckBox targetAir;
        private CheckBox dTargetAir;
        private CheckBox dTargetGround;
        private GroupBox dTroopGroupBox;
        private CheckBox dTypeAir;
        private CheckBox dTypeGround;
        private CheckBox typeAir;
        private CheckBox typeGround;
        private Button saveBinButton;
    }
}