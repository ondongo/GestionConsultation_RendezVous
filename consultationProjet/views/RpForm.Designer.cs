namespace consultationProjet.views
{
    partial class RpForm
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
            this.dtgRdvPres = new System.Windows.Forms.DataGridView();
            this.Datepres = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboEtat = new System.Windows.Forms.ComboBox();
            this.Annuler = new System.Windows.Forms.Button();
            this.btnfairePres = new System.Windows.Forms.Button();
            this.Valider = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboTypePres = new System.Windows.Forms.ComboBox();
            this.dtgprestation = new System.Windows.Forms.DataGridView();
            this.boxResultats = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRdvPres)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgprestation)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgRdvPres
            // 
            this.dtgRdvPres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgRdvPres.Location = new System.Drawing.Point(34, 26);
            this.dtgRdvPres.Name = "dtgRdvPres";
            this.dtgRdvPres.RowHeadersWidth = 51;
            this.dtgRdvPres.RowTemplate.Height = 29;
            this.dtgRdvPres.Size = new System.Drawing.Size(810, 259);
            this.dtgRdvPres.TabIndex = 0;
            // 
            // Datepres
            // 
            this.Datepres.Location = new System.Drawing.Point(0, 55);
            this.Datepres.Name = "Datepres";
            this.Datepres.Size = new System.Drawing.Size(303, 27);
            this.Datepres.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgRdvPres);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(867, 325);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rdv Prestations";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboEtat);
            this.groupBox2.Controls.Add(this.Annuler);
            this.groupBox2.Controls.Add(this.btnfairePres);
            this.groupBox2.Controls.Add(this.Valider);
            this.groupBox2.Controls.Add(this.Datepres);
            this.groupBox2.Location = new System.Drawing.Point(942, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 729);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // comboEtat
            // 
            this.comboEtat.FormattingEnabled = true;
            this.comboEtat.Location = new System.Drawing.Point(0, 89);
            this.comboEtat.Name = "comboEtat";
            this.comboEtat.Size = new System.Drawing.Size(303, 28);
            this.comboEtat.TabIndex = 1;
            // 
            // Annuler
            // 
            this.Annuler.BackColor = System.Drawing.Color.SteelBlue;
            this.Annuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.Annuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Annuler.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Annuler.Location = new System.Drawing.Point(0, 294);
            this.Annuler.Name = "Annuler";
            this.Annuler.Size = new System.Drawing.Size(357, 64);
            this.Annuler.TabIndex = 5;
            this.Annuler.Text = "Annuler Rdv_Pres";
            this.Annuler.UseVisualStyleBackColor = false;
            // 
            // btnfairePres
            // 
            this.btnfairePres.BackColor = System.Drawing.Color.SteelBlue;
            this.btnfairePres.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.btnfairePres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfairePres.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnfairePres.Location = new System.Drawing.Point(-6, 495);
            this.btnfairePres.Name = "btnfairePres";
            this.btnfairePres.Size = new System.Drawing.Size(363, 52);
            this.btnfairePres.TabIndex = 4;
            this.btnfairePres.Text = "Faire Prestation";
            this.btnfairePres.UseVisualStyleBackColor = false;
            // 
            // Valider
            // 
            this.Valider.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Valider.BackColor = System.Drawing.Color.SteelBlue;
            this.Valider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.Valider.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Valider.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Valider.Location = new System.Drawing.Point(-6, 224);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(363, 63);
            this.Valider.TabIndex = 3;
            this.Valider.Text = "Valider Rdv_Pres";
            this.Valider.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExport);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboTypePres);
            this.groupBox3.Controls.Add(this.dtgprestation);
            this.groupBox3.Controls.Add(this.boxResultats);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(22, 357);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(867, 383);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Faire une prestion";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lavender;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExport.Location = new System.Drawing.Point(23, 34);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(215, 34);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Exporter Csv";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(601, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Type prestation";
            // 
            // comboTypePres
            // 
            this.comboTypePres.FormattingEnabled = true;
            this.comboTypePres.Location = new System.Drawing.Point(480, 77);
            this.comboTypePres.Name = "comboTypePres";
            this.comboTypePres.Size = new System.Drawing.Size(364, 28);
            this.comboTypePres.TabIndex = 27;
            // 
            // dtgprestation
            // 
            this.dtgprestation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgprestation.Location = new System.Drawing.Point(23, 77);
            this.dtgprestation.Name = "dtgprestation";
            this.dtgprestation.RowHeadersWidth = 51;
            this.dtgprestation.RowTemplate.Height = 29;
            this.dtgprestation.Size = new System.Drawing.Size(429, 269);
            this.dtgprestation.TabIndex = 1;
            this.dtgprestation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgprestation_CellContentClick);
            // 
            // boxResultats
            // 
            this.boxResultats.Location = new System.Drawing.Point(480, 149);
            this.boxResultats.Name = "boxResultats";
            this.boxResultats.Size = new System.Drawing.Size(364, 197);
            this.boxResultats.TabIndex = 26;
            this.boxResultats.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(616, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "résultats ";
            // 
            // RpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1358, 783);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RpForm";
            this.Text = "Exporter";
            this.Load += new System.EventHandler(this.RpForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRdvPres)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgprestation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dtgRdvPres;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnpres;
        private GroupBox groupBox3;
        private Button Valider;
        private RichTextBox boxResultats;
        private Label label9;
        private DataGridView dtgprestation;
        private Button btnfairePres;
        private Label label1;
        private ComboBox comboTypePres;
        private Button Annuler;
        private ComboBox comboEtat;
        private Button btnExport;
        private DateTimePicker Datepres;
    }
}