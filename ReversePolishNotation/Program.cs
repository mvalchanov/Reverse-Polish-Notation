using System;
using System.Collections.Generic;
using System.Linq;

namespace ReversePolishNotation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insert postfix to calculate: ");

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int resultPostfix = CalculatePostfix(input);
            string resultInfix = RepresentInfix(input);

            Console.WriteLine($"Result is: {resultPostfix}");
            Console.WriteLine($"Infix: {resultInfix}");

        }


        private static string RepresentInfix(string[] infixInput)
        {
            Stack<string> operands = new Stack<string>();
            Stack<string> operators = new Stack<string>();

            int counter = 0;

            foreach (var item in infixInput)
            {
                counter++;

                if (int.TryParse(item, out int operand))
                {
                    operands.Push(item);
                }
                else
                {
                    operators.Push(item);
                    if (counter > 1)
                    {

                        string firstOperand = operands.Pop();
                        string secondOperand = operands.Pop();
                        string operat = operators.Pop();

                        // TODO: There is a chance current item to be equal to last one

                        if (infixInput[infixInput.Count() - 1].ToString().Equals(item))
                        {
                            operands.Push(secondOperand + " " + operat + " " + firstOperand);
                        }
                        else
                        {
                            operands.Push("(" + secondOperand + " " + operat + " " + firstOperand + ")");

                        }


                        counter -= 2;
                    }
                }
            }


            return operands.Pop();
        }

        private static int CalculatePostfix(string[] postfixInput)
        {
            Stack<int> numbers = new Stack<int>();

            foreach (var token in postfixInput)
            {
                if (int.TryParse(token, out int number))
                {
                    numbers.Push(number);
                }
                else
                {
                    switch (token)
                    {
                        case "+":

                            number = numbers.Pop();
                            numbers.Push(number += numbers.Pop());

                            break;

                        case "-":

                            number = numbers.Pop();
                            int previousNumber = numbers.Pop();
                            numbers.Push(previousNumber -= number);

                            break;

                        case "*":

                            number = numbers.Pop();
                            numbers.Push(number *= numbers.Pop());

                            break;

                        case "/":

                            number = numbers.Pop();
                            previousNumber = numbers.Pop();
                            numbers.Push(previousNumber /= number);

                            break;
                    }
                }
            }

            return numbers.Pop();
        }
    }
}
