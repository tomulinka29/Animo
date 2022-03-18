using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {
        private double Memory;

        /// <summary>This method subtract second number from first number</summary>
        /// <param name="number1">The first number</param>
        /// <param name="number2">The second number</param>
        public double Subtract(double number1, double number2) 
        {
            return number1 - number2;
        }
        public double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        public double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }
        public double Divide(double number1, double number2)
        {
            return number1 / number2;
        }
        public double MemoryRecall() 
        {
            return Memory;
        }
        public void MemoryClear() 
        {
            Memory = 0;
        }
        public void MemoryAdd(double number) 
        {
            Memory += number;
        }
        public void MemorySubtract(double number)
        {
            Memory -= number;
        }
        public override string ToString()
        {
            return Memory.ToString();
        }
    }
}
