using System;

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

            CalcInputs inputs = new CalcInputs();


            while (!done)
            {
                Console.Out.WriteLine("Please enter what you would like to add or enter x to exit.");
                string input = Console.ReadLine();

                if (!input.Trim().Equals("x", StringComparison.CurrentCultureIgnoreCase))
                {
                    var numArray = input.Trim().Split(" ");
                    if (numArray[1].Equals("+", StringComparison.CurrentCultureIgnoreCase) && numArray.Length == 3)
                    {
                        success = Decimal.TryParse(numArray[0], out input1);

                        if (success)
                        {
                            success = Decimal.TryParse(numArray[2], out input2);
                            if (success)
                            {
                                Console.WriteLine("The sum is {0}.", input1 + input2);
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
