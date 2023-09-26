using System;

namespace BasicCalculator
{
    class Program
    {
        const string operator_Symbol = "OPERATORSYMBOL";
        const string operand_1 = "OPERAND1";
        const string operand_2 = "OPERAND2";

        static void Main(string[] args)
        {
            int operand1, operand2;
            int result = 0;
            char operatorSymbol;

            Console.WriteLine("Basic Calculator");
            Console.WriteLine("----------------");
            Console.WriteLine();
            
            try
            {
                Console.WriteLine("Main method - Beginning");
                Console.WriteLine();

                Console.WriteLine("Please enter a whole number value for the first operand: ");
                operand1 = ValidateOperandInput();

                Console.WriteLine("Please enter a whole number value for the second operand: ");
                operand2 = ValidateOperandInput();

                Console.WriteLine("Please enter a symbol for the operator('+', '-', '*', '/'): ");
                operatorSymbol = ValidateOperatorInput();

                Console.WriteLine();

                result = Calculate(operand1, operand2, operatorSymbol);

                Console.WriteLine($"{operand1} {operatorSymbol} {operand2} = {result}");

                Console.ReadKey();
            }
            catch (CalculationResultOverflowException ex)
            {
                Logger.Log(ex, LogType.Verbose);
                
                Console.WriteLine();
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
              
                WriteExceptionMethodToScreen($"Result out of range for Int32 variable (Must be {Int32.MinValue} > x > {Int32.MaxValue}");
            }
            catch (OverflowException ex)
            {
                Logger.Log(ex, LogType.Verbose);

                WriteExceptionMethodToScreen("You entered a value for one of the operands that is too great or too small for an integer");
            }
            catch (ArithmeticException ex)
            {
                Logger.Log(ex, LogType.Verbose);

                WriteExceptionMethodToScreen(ex.Message);
            }
            catch (BlankUserInputException ex)
            {
                Logger.Log(ex, LogType.Verbose);

                WriteExceptionMethodToScreen("Blank field.");
            }
            catch (FormatException ex)
            {
                Logger.Log(ex, LogType.Verbose);

                WriteExceptionMethodToScreen("Input is invalid");
            }
            catch(ArgumentException ex)
            {
                Logger.Log(ex, LogType.Verbose);

                WriteArgumentExceptionToScreen(ex);
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Main Method - End");
            }


            Console.ReadKey();
 
        }

        private static char ValidateOperatorInput()
        {
            int counter = 1;
            int maxTries = 5;
            string userInput = null;

            try
            {
                do
                {
                    userInput = Console.ReadLine();

                    if (char.TryParse(userInput, out char c) && (c == '+' || c == '-' || c == '*' || c == '/'))
                    {

                        return c;
                    }
                    else
                    {
                        WriteAmountOfAttemptsToScreen(counter);
                    }
                    counter++;
                }
                while (counter < maxTries);

                userInput = Console.ReadLine();
                
                CheckBlankUserInput(userInput);

                char r = Char.Parse(userInput);
                
                return r;

            }
            catch(BlankUserInputException ex)
            {
                Logger.Log(ex, LogType.Basic);
                throw;
            }
            catch(FormatException ex)
            {
                Logger.Log(ex, LogType.Basic);
                throw;

            }
        }

        private static int ValidateOperandInput()
        {
            int counter = 1;
            const int maxTries = 5;
            string userInput = string.Empty;

            try
            {
                do
                {
                    userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int i))
                    {
                        return i;
                    }
                    else
                    {
                        WriteAmountOfAttemptsToScreen(counter);
                    }
                    counter++;
                }
                while (counter < maxTries);

                userInput = Console.ReadLine();

                CheckBlankUserInput(userInput);

                int operand = int.Parse(userInput);

                return operand;

            }
            catch(BlankUserInputException ex)
            {
                Logger.Log(ex, LogType.Basic);
                throw;
            }
            catch (FormatException ex)
            {
                Logger.Log(ex, LogType.Verbose);
                throw;
            }
        }

        private static void CheckBlankUserInput(string userInput)
        {
            if (String.IsNullOrWhiteSpace(userInput))
            {
                throw new BlankUserInputException();
            }
        }

        private static void WriteAmountOfAttemptsToScreen(int count)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"You have made {count} attempt{(count == 1?"":"s")})");
            Console.ResetColor();

            Console.WriteLine("Please try again");
        }

        private static int Calculate(int operand1, int operand2, char operatorSymbol)
        {
            int result = 0;

            try
            {
                switch (operatorSymbol)
                {
                    case '+':
                        checked
                        {
                            result = operand1 + operand2;
                        }
                        break;
                    case '-':
                        checked
                        {
                            result = operand1 - operand2;
                        }
                        break;
                    case '*':
                        checked
                        {
                            result = operand1 * operand2;
                        }
                        break;
                    case '/':
                        checked
                        {
                            result = operand1 / operand2;
                        }
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            catch(OverflowException ex)
            {
                throw new CalculationResultOverflowException(ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("In Calculate() method (where InvalidOperation is caught)");
                Console.WriteLine($"{nameof(operatorSymbol)}");
                throw new ArgumentException($"{nameof(operatorSymbol)} is invalid.", operator_Symbol, ex);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("In Calculate() method (where DivideByZero is caught)");
                Console.WriteLine($"{nameof(operand2)}");
                throw new ArgumentException($"{nameof(operand2)} cannot be 0 when executing a divide operation.", operand_2, ex);
            }
            finally
            {

            }

            return result;
        }

        private static void WriteArgumentExceptionToScreen(ArgumentException ex)
        {
            string errorMessage = null;

            if (ex.ParamName.ToUpper() == operator_Symbol)
            {
                errorMessage = "An invalid operator symbol used. Must be ('+', '-', '*', '/')";
            }
            else if (ex?.ParamName.ToUpper() == operand_2)
            {
                errorMessage = "Value of 0 second operand. Don't divide by zero";
            }
            //WriteExceptionMethodToScreen(ex.Message);
            WriteExceptionMethodToScreen(errorMessage);
        }

        private static void WriteExceptionMethodToScreen(string message)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
