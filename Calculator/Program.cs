using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            bool success = false;
            decimal input1;
            decimal input2;
            List<string> operators = new List<string> {"+","-","/","*"};
       
            while (!done)
            {
                Console.Out.WriteLine("Please enter what you would like to add or subtract with spaces between each entry, or enter x to exit.");
                string input = Console.ReadLine();

                if (!input.Trim().Equals("x", StringComparison.CurrentCultureIgnoreCase))
                {
                    var numArray = input.Trim().Split(" ");
                    if (operators.Contains(numArray[1])&& numArray.Length == 3)
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
                                    Console.WriteLine("The result is {0}.", input1 + input2);
                                        break;
                                    case "-":
                                        Console.WriteLine("The result is {0}.", input1 - input2);
                                        break;
                                    case "*":
                                        Console.WriteLine("The result is {0}.", input1 * input2);
                                        break;
                                    case "/":
                                        Console.WriteLine("The result is {0}.", input1/input2);
                                        break;
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
                    else
                    {
                        Console.WriteLine("Please re-submit your entry as it is invalid.");
                    }
                }

                else
                {
                    done = true;
                }
            }
        }
    }
}
