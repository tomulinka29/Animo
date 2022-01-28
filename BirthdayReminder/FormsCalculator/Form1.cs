using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCalculator
{
    public partial class Form1 : Form
    {
        private List<Person> people;

        public Form1()
        {
            InitializeComponent();
            people = new List<Person>();

            lbl_Today.Text = DateTime.Now.ToString("D");

            people.Add(new Person() { Birthday=DateTime.Now, Name="asdf" });
            people.Add(new Person() { Birthday = DateTime.Now, Name = "asd" });
            people.Add(new Person() { Birthday = DateTime.Now, Name = "as" });
            
            lbox_Birthdays.DataSource = people;
            lbl_Birthday.Text = ((Person)lbox_Birthdays.SelectedItem).Birthday.ToString();
            lbl_Today.Text = DateTime.Now.ToString("D");

       
        }

        private void lbox_Birthdays_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_Birthday.Text = ((Person)lbox_Birthdays.SelectedItem).Birthday.ToString();
            lbl_Today.Text = DateTime.Now.ToString("D");
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {

        }

     
    }
}
