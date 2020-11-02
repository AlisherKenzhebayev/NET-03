using System;

namespace U10_GenericsCollections.T_08
{
    using System.Collections.Generic;

    public class PolishCalculator
    {
        public PolishCalculator(string expression)
        {
            this.Expression = expression.Trim();
            ExpressionStack = new Stack<int>();
        }

        public int Evaluate()
        {
            var retVal = default(int);
            var splitArray = Expression.Split(' ');
            foreach (var i in splitArray)
            {
                int f;
                int s;
                switch (i)
                {
                    case "+":
                        (f, s) = GetPop();
                        ExpressionStack.Push(f + s);
                        break;
                    case "-":
                        (f, s) = GetPop();
                        ExpressionStack.Push(f - s);
                        break;
                    case "/":
                        (f, s) = GetPop();
                        ExpressionStack.Push(f / s);
                        break;
                    case "*":
                        (f, s) = GetPop();
                        ExpressionStack.Push(f * s);
                        break;
                    default:
                        ExpressionStack.Push(int.Parse(i));
                        break;
                }
            }

            if (ExpressionStack.Count > 1)
            {
                throw new Exception("Invalid Reverse Polish Expression");
            }

            if (ExpressionStack.Count == 1)
            {
                retVal = ExpressionStack.Pop();
            }

            return retVal;
        }

        private (int F, int S) GetPop()
        {
            var s = ExpressionStack.Pop();
            var f = ExpressionStack.Pop();
            return (f, s);
        }

        private string Expression { get; set; }

        private Stack<int> ExpressionStack { get; set; }
    }
}