
namespace FormsCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_nextBirthday = new System.Windows.Forms.Label();
            this.lbl_Today = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbox_Birthdays = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Birthday = new System.Windows.Forms.Label();
            this.lbl_Age = new System.Windows.Forms.Label();
            this.cal_monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Remove);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Controls.Add(this.cal_monthCalendar);
            this.panel1.Controls.Add(this.lbl_Age);
            this.panel1.Controls.Add(this.lbl_Birthday);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbox_Birthdays);
            this.panel1.Controls.Add(this.lbl_nextBirthday);
            this.panel1.Controls.Add(this.lbl_Today);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 450);
            this.panel1.TabIndex = 0;
            // 
            // lbl_nextBirthday
            // 
            this.lbl_nextBirthday.Location = new System.Drawing.Point(228, 63);
            this.lbl_nextBirthday.Name = "lbl_nextBirthday";
            this.lbl_nextBirthday.Size = new System.Drawing.Size(197, 23);
            this.lbl_nextBirthday.TabIndex = 3;
            this.lbl_nextBirthday.Text = "lbl_Birthday";
            // 
            // lbl_Today
            // 
            this.lbl_Today.Location = new System.Drawing.Point(228, 29);
            this.lbl_Today.Name = "lbl_Today";
            this.lbl_Today.Size = new System.Drawing.Size(197, 23);
            this.lbl_Today.TabIndex = 2;
            this.lbl_Today.Text = "lbl_Today";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nejbližší narozeniny:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dnes je";
            // 
            // lbox_Birthdays
            // 
            this.lbox_Birthdays.FormattingEnabled = true;
            this.lbox_Birthdays.Location = new System.Drawing.Point(45, 132);
            this.lbox_Birthdays.Name = "lbox_Birthdays";
            this.lbox_Birthdays.Size = new System.Drawing.Size(144, 225);
            this.lbox_Birthdays.TabIndex = 4;
            this.lbox_Birthdays.SelectedIndexChanged += new System.EventHandler(this.lbox_Birthdays_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(228, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Narozeniny";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(228, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Věk";
            // 
            // lbl_Birthday
            // 
            this.lbl_Birthday.Location = new System.Drawing.Point(322, 132);
            this.lbl_Birthday.Name = "lbl_Birthday";
            this.lbl_Birthday.Size = new System.Drawing.Size(100, 23);
            this.lbl_Birthday.TabIndex = 7;
            this.lbl_Birthday.Text = "bday";
            // 
            // lbl_Age
            // 
            this.lbl_Age.Location = new System.Drawing.Point(322, 155);
            this.lbl_Age.Name = "lbl_Age";
            this.lbl_Age.Size = new System.Drawing.Size(100, 23);
            this.lbl_Age.TabIndex = 8;
            this.lbl_Age.Text = "age";
            // 
            // cal_monthCalendar
            // 
            this.cal_monthCalendar.Location = new System.Drawing.Point(231, 195);
            this.cal_monthCalendar.Name = "cal_monthCalendar";
            this.cal_monthCalendar.TabIndex = 9;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(45, 397);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(144, 41);
            this.btn_Add.TabIndex = 10;
            this.btn_Add.Text = "Přidat";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(231, 397);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(152, 41);
            this.btn_Remove.TabIndex = 11;
            this.btn_Remove.Text = "Odebrat";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_nextBirthday;
        private System.Windows.Forms.Label lbl_Today;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar cal_monthCalendar;
        private System.Windows.Forms.Label lbl_Age;
        private System.Windows.Forms.Label lbl_Birthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbox_Birthdays;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
    }
}

