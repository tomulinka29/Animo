using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForms
{
    class SubstractOperator : BinaryOperator
    {
        private Operand a;
        private Operand b;

        public SubstractOperator(Operand a, Operand b) : base(a, b)
        {
            this.a = a;
            this.b = b;
        }

        public override double Calculate()
        {
            return a.Value - b.Value;
        }
    }
}
