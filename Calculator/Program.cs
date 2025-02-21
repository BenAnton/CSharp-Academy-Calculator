Calculator calculator = new("Welcome To The Console Calculator");
Console.WriteLine();
calculator.Start();

public sealed class Calculator
{
    private string _greeting;

    public Calculator(string greeting)
    {
        _greeting = greeting;
    }

    public void Start()
    {
        Console.WriteLine(_greeting);

        Dictionary<string, string> supportedOperators = new()
    {
        {"+", "Add"},
        {"/", "Divide"},
        {"*", "Multiply"},
        {"-", "Subtracts"}
    };

        while (true)
        {
            Console.WriteLine("Choose an Operator:");
            foreach (var op in supportedOperators)
            {
                Console.WriteLine($"{op.Value}: {op.Key}");
            }

            Console.WriteLine("Enter an operator:");
            string operatorChoice = Console.ReadLine();

            if (!supportedOperators.TryGetValue(operatorChoice, out var selectedOperatorDescription))
            {
                Console.WriteLine("Invalid Choice");
                continue;
            }

            Console.WriteLine($"You selected {selectedOperatorDescription}");
            Console.WriteLine();

            Console.WriteLine($"Integer Range: " + $"{int.MinValue} to {int.MaxValue}!");
            Console.WriteLine();

            Console.WriteLine("Enter first integer:");
            string firstNumberInput = Console.ReadLine();
            if (!int.TryParse(firstNumberInput, out int firstNumber))
            {
                Console.WriteLine($"{firstNumberInput} could not be parsed as an integer");
                continue;
            }

            Console.WriteLine("Please enter the second integer:");
            string secondNumberInput = Console.ReadLine();
            if (!int.TryParse(secondNumberInput, out int secondNumber))
            {
                Console.WriteLine($"{secondNumberInput} could not be parsed as an integer");
                continue;
            }

            int result;
            try
            {
                result = operatorChoice switch
                {
                    "+" => firstNumber + secondNumber,
                    "-" => firstNumber - secondNumber,
                    "*" => firstNumber * secondNumber,
                    "/" => firstNumber / secondNumber,
                    _ => throw new NotSupportedException(
                        $"Arithmetic is not currently supported " + $"for operator {operatorChoice}.")
                };
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by zero");
                continue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                $"There was an unknown exception: {ex.Message}");
                continue;
            }
            Console.WriteLine("---------------------");
            Console.WriteLine($"The result is: {result}");
            Console.WriteLine("---------------------");
        }
    }
}