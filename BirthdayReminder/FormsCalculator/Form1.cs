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

            people.Add(new Person() { Birthday=DateTime.Parse("18.3.2005"), Name="Evžen" });
            people.Add(new Person() { Birthday = DateTime.Parse("5.2.2012"), Name = "Viktor" });
            people.Add(new Person() { Birthday = DateTime.Parse("6.2.2001"), Name = "Karel" });
            
            lbox_Birthdays.DataSource = people;
            lbl_Birthday.Text = ((Person)lbox_Birthdays.SelectedItem).Birthday.ToString();
            lbl_Today.Text = DateTime.Now.ToString("D");

       
        }

        private void lbox_Birthdays_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbl_Birthday.Text = ((Person)lbox_Birthdays.SelectedItem).Birthday.ToString();
            //lbl_Today.Text = DateTime.Now.ToString("D");
            UpdatePersonInfo();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePersonInfo()
        {
            Person selected = people[lbox_Birthdays.SelectedIndex];
            lbl_Birthday.Text = selected.Birthday.ToString("d");
            int years = DateTime.Today.Year - selected.Birthday.Year;

            if ((selected.Birthday.Month > DateTime.Now.Month) || (selected.Birthday.Month == DateTime.Now.Month && selected.Birthday.Day > DateTime.Now.Day))
                years--;


            lbl_Age.Text = ((int)years).ToString();

            int min = int.MaxValue;
            int index = 0;
            foreach (var person in people)
            {
                if (DateTime.Now.DayOfYear - person.Birthday.DayOfYear < min)
                    min = DateTime.Now.DayOfYear - person.Birthday.DayOfYear;                
                index++;
            }

            lbl_nextBirthday.Text = people[index-1].Name;
        }

     
    }
}
