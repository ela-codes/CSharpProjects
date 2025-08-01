// Create a CLI calculator

// Main program asks user for the input and deals with calling the Calculator methods to perform necessary calculations.
string userOperator = "";

bool isValidOperator = false;

string[] validOperators = { "add", "subtract", "divide", "multiply" };

while (!isValidOperator)
{
    Console.Write("Choose an operation (add / subtract / divide / multiply): ");
    userOperator = Console.ReadLine();
    isValidOperator = validOperators.Contains(userOperator);
}

if (isValidOperator)
{
    Console.Write("Enter the first integer: ");
    int firstNum = int.Parse(Console.ReadLine());

    Console.Write("Enter the second integer: ");
    int secondNum = int.Parse(Console.ReadLine());

    int result = 0;

    switch (userOperator)
    {
        case "add":
            result = Calculator.Add(firstNum, secondNum);
            break;

        case "subtract":
            result = Calculator.Subtract(firstNum, secondNum);
            break;

        case "divide":
            result = Calculator.Divide(firstNum, secondNum);
            break;

        case "multiply":
            result = Calculator.Multiply(firstNum, secondNum);
            break;
    }

    Console.WriteLine($"The result is: {result}");
}

// Apply encapsulation. Separate Calculator logic and behaviour.
class Calculator
{
    public static int Add(int firstNum, int secondNum)
    {
        return firstNum + secondNum;
    }

    public static int Subtract(int firstNum, int secondNum)
    {
        return firstNum - secondNum;
    }

    public static int Multiply(int firstNum, int secondNum)
    {
        return firstNum * secondNum;
    }

    public static int Divide(int firstNum, int secondNum)
    {
        return firstNum / secondNum;
    }
}