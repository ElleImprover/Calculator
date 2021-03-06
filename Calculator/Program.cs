using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalculator();
        }

        public static void RunCalculator()
        {
            bool done = false;
            bool success = false;
            decimal input1;
            decimal input2;
            decimal result = 0;
            List<string> operators = new List<string> { "+", "-", "/", "*" };
            List<CalcHistory> history = new List<CalcHistory>();
            while (!done)
            {
                Console.Out.WriteLine("Please enter what you would like to add, subtract, multiply or divide with spaces between each entry, type 'history' to view previous operations or type 'exit' to exit.\n");
                string input = Console.ReadLine();

  
                if (!input.Trim().Equals("exit", StringComparison.CurrentCultureIgnoreCase)&& !input.Trim().Contains("history", StringComparison.CurrentCultureIgnoreCase))
                {
                    var numArray = input.Trim().Split(" ");

                    if (numArray.Length == 3)
                    {
                        if (operators.Contains(numArray[1]))
                        {
                            success = Decimal.TryParse(numArray[0], out input1);
                            if (success)
                            {
                                success = Decimal.TryParse(numArray[2], out input2);
                                if (success)
                                {
                                    switch (numArray[1])
                                    {
                                        case "+":
                                            result = input1 + input2;
                                            break;
                                        case "-":
                                            result = input1 - input2;
                                            break;
                                        case "*":
                                            result = input1 * input2;
                                            break;
                                        case "/":
                                            result = input1 / input2;
                                            break;
                                    }

                                    Console.WriteLine("The result is {0, -20}.", result);
                                    history.Add(new CalcHistory { Entry = input,Operator=numArray[1],Result= result});
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please re-enter.\nThe second entry is in an invalid format.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please re-enter.\nThe first entry is in an invalid format.");
                        }
                    }
                    else if (numArray.Length == 2 && operators.Contains(numArray[0]))
                    {
                        success = Decimal.TryParse(numArray[1], out input1);

                        if (success)
                        {
                            var prevEntry = result;
                            switch (numArray[0])
                            {
                                case "+":
                                    result += input1;
                                    break;
                                case "-":
                                    result -= input1;
                                    break;
                                case "*":
                                    result *= input1;
                                    break;
                                case "/":
                                    result /= input1;
                                    break;
                            }
                            Console.WriteLine("The result is {0,-20}.", result);
                            history.Add(new CalcHistory { Entry = input, Operator=numArray[0], Result = result, PreviousEntry=prevEntry });
                        }
                        else
                        {
                            Console.WriteLine("Please re-submit your entry as it is invalid.\n An operation must be in the form '8 + 4', or, '+ 4' for a cumulative result.");
                        }
                    }
                    else if (numArray.Length < 2)
                    {
                        Console.Out.WriteLine("Please re-submit your entry as it is invalid.\n You must enter at least two terms separated by spaces.");
                    }
                }
                else if (input.Trim().Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    done = true;
                }
                else if (input.Trim().Contains("history", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (history.Count > 0)
                    {
                        Console.WriteLine("Previous Operations:");

                    var  histArray= input.Trim().Split(" ");

                        if ((histArray.Length == 1)|| (histArray.Length == 2))
                        {
                            List<CalcHistory> nHistory = history;

                            if (histArray.Length == 2)
                            {
                                nHistory = history.FindAll(x => x.Operator == histArray[1]);
                            }

                            foreach (var entry in nHistory)
                            {
                                if (entry.PreviousEntry.HasValue)
                                {
                                    Console.WriteLine("_{0}_ {1,-20} ", entry.PreviousEntry,entry.Entry);
                                }
                                else
                                {
                                    Console.WriteLine("{0,-20}",entry.Entry);
                                }
                                Console.WriteLine("The result: {0,-20}\n", entry.Result);
                            }
                        } 
                        else
                        {
                            Console.Out.WriteLine("Please re-submit your entry as it is invalid.\n You must enter at least two terms separated by spaces.");

                        }
                    } else
                    {
                        Console.WriteLine("There's no history."); 
                    }
                }

            }
        }
    }
}
