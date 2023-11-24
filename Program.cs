using System.Transactions;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Main loop: Continues executing the calculator program until the user chooses to exit.
            do
            {
                double num1, num2, result = 0;

                // Display header for the calculator program.
                Console.SetCursorPosition(11, 5);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("********************");
                Console.SetCursorPosition(11, 6);
                Console.WriteLine("*Calculator Program* ");
                Console.SetCursorPosition(11, 7);
                Console.WriteLine("********************");

                // Input for Number 1.
                Console.SetCursorPosition(11, 10);
                num1 = GetNumber("Enter Number 1: ");

                // Input for Number 2.
                Console.SetCursorPosition(11, 11);
                num2 = GetNumber("Enter Number 2: ");

                // Choose an operation for the calculation.
                char operation = GetOperation();

                // Perform the chosen operation and store the result.
                result = PerformOperation(num1, num2, operation);

                // Display the result of the calculation.
                Console.SetCursorPosition(11, 22);
                Console.WriteLine($"Your result: {num1} {operation} {num2} = {result}");

                // Ask the user if they want to continue with another calculation.
                Console.SetCursorPosition(11, 24);
                Console.WriteLine("Would you like to continue? (Y = yes, N = No): ");
            } while (Console.ReadLine().ToUpper() == "Y");

            // Display a farewell message when the user decides to exit the calculator.
            Console.WriteLine("Bye!");
            Console.ReadKey();
        }

        // This method handles the input of a number, prompting the user until a valid number is entered.
        static double GetNumber(string message)
        {
            double number;
            while (true)
            {
                Console.Write(message);
                // Attempt to parse the user input as a double.
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    return number; // Return the valid number.
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        // This method prompts the user to choose an operation and validates the input against a set of valid operations.
        static char GetOperation()
        {
            char[] validOperations = { '+', '-', '*', '/' };

            while (true)
            {
                Console.SetCursorPosition(11, 14);
                Console.WriteLine("Choose : ");
                foreach (char op in validOperations)
                {
                    Console.WriteLine($"\t{op} : {GetOperationName(op)}");
                }
                
                Console.SetCursorPosition (11, 20);
                Console.Write("Enter an option: ");
                char operation = Console.ReadLine().Trim()[0];

                if (Array.IndexOf(validOperations, operation) != -1)
                {
                    return operation;
                }
                else
                {
                    Console.WriteLine("Invalid operation. Please enter a valid option.");
                }
            }
        }

        // This method converts the selected operation into a human-readable string.
        static string GetOperationName(char operation)
        {
            switch (operation)
            {
                case '+':
                    return "Add";
                case '-':
                    return "Subtract";
                case '*':
                    return "Multiply";
                case '/':
                    return "Divide";
                default:
                    return "Unknown";
            }
        }

        // This method performs the selected operation on the given numbers and returns the result.
        static double PerformOperation(double num1, double num2, char operation)
        {
            switch (operation)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    // Check for division by zero
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero");
                        return double.NaN; // Indicate an undefined result
                    }
                default:
                    Console.WriteLine("Unknown operation");
                    return double.NaN;

            }

            Console.WriteLine("Bye!");
            Console.ReadLine();
        }
    }
}
