using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForms
{
    public class BinaryOperator : Operator
    {
        protected Operand a;
        protected Operand b;

        public BinaryOperator(Operand a, Operand b)
        {
            this.a = a;
            this.b = b;
        }
        
        public virtual double Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
