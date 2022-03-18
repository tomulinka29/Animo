using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator;


namespace CalculatorForms
{
    public partial class Form1 : Form
    {
        Tree tree;
        Operand currentOperand;
        string operandString;

        public Form1()
        {
            InitializeComponent();
            tree = new Tree();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ProcessButtonClick(object sender, EventArgs e)
        {
            if (sender == btn_result)
            {
                if (tree.root == null)
                    return;
            }
            else if (sender == btn_plus)
            {
                if (tree.root == null)
                    tree.root = new BinaryOperator(currentOperand, null);
            }
        }

        private void ResultLabelUpdate(object sender, EventArgs e)
        {
            lbl_result.Text = operandString;
        }

        private void ResultLabelReset(object sender, EventArgs e)
        {
            operandString = "0";
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            ResultLabelUpdate(sender, e);   
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            ResultLabelUpdate(sender, e);
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            ResultLabelUpdate(sender, e);
        }











        private void btn_0_Click(object sender, EventArgs e)
        {
            operandString += '0';
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            operandString += '1';
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            operandString += '2';
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            operandString += '3';
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            operandString += '4';
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            operandString += '5';
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            operandString += '6';
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            operandString += '7';
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            operandString += '8';
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            operandString += '9';
        }

     
    }
}
