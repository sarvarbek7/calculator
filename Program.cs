using calculator.Classes;


internal class Program
{
    private static void Main(string[] args)
    {
        string infixExpression;
        Console.WriteLine("Enter your expression");

        infixExpression = Console.ReadLine()!;  

        CalculatorConverter converter = new CalculatorConverter(infixExpression);
        converter.InfixToPostfix();
        string[] postfixArr = converter.PostfixExpressionAsArray();

        CalculatorLogic logic = new CalculatorLogic(postfixArr);
        double result = logic.Result();
        
        Console.WriteLine($"{infixExpression} = {result}");
    }
}