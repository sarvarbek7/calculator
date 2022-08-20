namespace calculator.Classes
{
    class CalculatorLogic
    {
        string[] postfixArr;

        public CalculatorLogic(string[] postfixArr) {
            this.postfixArr = postfixArr;
        }
        bool isOperator(string element)
        {
            return element switch
            {
                "+" => true,
                "-" => true,
                "*" => true,
                "/" => true,
                "%" => true,
                "^" => true,
                 _  => false,
            };
        }

        public double Result() {
            Stack<double> stack= new Stack<double>();
            for (int index=0; index < postfixArr.Length; index++) 
            {   
                string element = postfixArr[index]; 
                element = element.Replace( ',' , '.' );

                if ( !isOperator(element) )
                {
                    double operand = Convert.ToDouble(element);
                    stack.Push(operand);
                } 
                else 
                {
                    double secondOperand = stack.Pop();
                    double firstOperand = stack.Pop();

                    double result = element switch {
                        "+" => firstOperand + secondOperand,
                        "-" => firstOperand - secondOperand,
                        "*" => firstOperand * secondOperand,
                        "/" => firstOperand / secondOperand,
                        "%" => firstOperand % secondOperand,
                        "^" => Math.Pow(firstOperand, secondOperand),
                         _ => -0.0,
                    };

                    stack.Push(result);

                }
            }
            return stack.Pop();
        }


        //infixExpression = Console.ReadLine();
    }
}