// Create a CLI calculator

// Ask user what math operator to use
// Accepts 2 integers
// Outputs the result

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
            result = firstNum + secondNum;
            break;

        case "subtract":
            result = firstNum - secondNum;
            break;

        case "divide":
            result = firstNum / secondNum;
            break;

        case "multiply":
            result = firstNum * secondNum;
            break;
    }

    Console.WriteLine($"The result is: {result}");
}
