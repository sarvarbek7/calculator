using System.Collections.Generic;
namespace calculator.Classes
{
    public class CalculatorConverter
    {
        string[] postfixArr = { };
        string infixExpression;
        Stack<char> stack = new Stack<char>();

        public CalculatorConverter(string infixExpression) {
            this.infixExpression = infixExpression;
        }
        public string[] PostfixExpressionAsArray() {
            return postfixArr;
        }
        
        bool isOperand(char character)
        {
            return character switch
            {
                '1' => true,
                '2' => true,
                '3' => true,
                '4' => true,
                '5' => true,
                '6' => true,
                '7' => true,
                '9' => true,
                '0' => true,
                '.' => true,
                ',' => true,
                _ => false,
            };
        }
        bool isOperator(char character)
        {
            return character switch
            {
                '+' => true,
                '-' => true,
                '*' => true,
                '/' => true,
                '%' => true,
                '^' => true,
                _ => false,
            };
        }
        bool isBlank(char character)
        {
            return character == ' ' ? true : false;
        }
        byte precedence(char character)
        {
            return character switch
            {
                '^' => 3,
                '*' => 2,
                '/' => 2,
                '%' => 2,
                '+' => 1,
                '-' => 1,
                _ => 0,
            };
        }

        public void InfixToPostfix() 
        {
            string mystr = "";
            int lastIndex = infixExpression.Length - 1;

            for (int index = 0; index < infixExpression.Length; index++)
            {
                char character = infixExpression[index];

                if (isOperand(character))
                {
                    mystr += character.ToString();
                    

                    if (index != lastIndex)
                    {
                        char nextChar = infixExpression[index + 1];
                        if (isOperand( nextChar ))
                        {
                            continue;
                        }
                        else
                        {
                            postfixArr = postfixArr.Append(mystr).ToArray();
                            mystr = "";
                        }
                    }
                    else
                    {
                        postfixArr = postfixArr.Append(mystr).ToArray();
                        mystr = "";
                        
                    }
                }
                else
                if (character == '(')
                {
                    stack.Push(character);
                }
                else
                if (character == ')')
                {
                    char[] tempArr = new char[stack.Count];
                    stack.CopyTo(tempArr, 0);
                    foreach (char element in tempArr)
                    {
                        if (element != '(')
                        {
                            postfixArr = postfixArr.Append(stack.Pop().ToString()).ToArray();
                        }
                        else
                        {
                            stack.Pop();
                        }
                    }
                }
                else
                if (isOperator(character))
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(character);
                    }
                    else
                    {
                        char[] tempArr = new char[stack.Count];
                        stack.CopyTo(tempArr, 0);
                        foreach (char element in tempArr)
                        {
                            if (element == '(')
                            {
                                break;
                            }
                            if (precedence(element) >= precedence(character))
                            {

                                postfixArr = postfixArr.Append(stack.Pop().ToString()).ToArray();
                            }
                        }
                        stack.Push(character);
                    }

                }
                else
                if (isBlank(character))
                {
                    continue;
                }

                // Before finish add stack elements to postfixArr 
                if (index == infixExpression.Length - 1)
                {
                    char[] tempArr = new char[stack.Count];
                    stack.CopyTo(tempArr, 0);
                    foreach (char element in tempArr)
                    {
                        if (isOperator(element))
                        {
                            postfixArr = postfixArr.Append(stack.Pop().ToString()).ToArray();
                        }
                    }
                }
            }
    
        }

    }
}