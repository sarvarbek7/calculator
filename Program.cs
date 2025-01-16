using calculator.Classes;


internal class Program
{
    private static void Main(string[] args)
    {
        string infixExpression;

        do
        {
            Console.WriteLine("Enter your expression");

            infixExpression = Console.ReadLine()!;

            CalculatorConverter converter = new CalculatorConverter(infixExpression);

            try
            {
                converter.InfixToPostfix();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Given expression is invalid.");

                return;
            }
            string[] postfixArr = converter.PostfixExpressionAsArray();

            CalculatorLogic logic = new CalculatorLogic(postfixArr);
            double result = logic.Result();

            Console.WriteLine($"{infixExpression} = {result}");

            Console.WriteLine("Press Q to exit.");
        }
        while (Console.ReadKey().KeyChar != 'q');
    }
}