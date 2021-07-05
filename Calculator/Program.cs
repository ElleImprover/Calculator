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
                Console.Out.WriteLine("Please enter two numbers to add.");
                Console.Out.WriteLine("Please enter the first number. Enter x to exit.");
                string in1 = Console.ReadLine();

                if (!in1.Equals("x", StringComparison.CurrentCultureIgnoreCase))
                {
                    success = Decimal.TryParse(in1, out input1);
                    if (success)
                    {
                        Console.Out.WriteLine("Please enter the second number. Enter x to exit.");
                        string in2 = Console.ReadLine();

                        if (!in2.Equals("x", StringComparison.CurrentCultureIgnoreCase)) {

                            success = Decimal.TryParse(in2, out input2);
                            if (success)  {
                                Console.WriteLine("The sum is {0}.", input1 + input2);
                            }
                            else {
                                Console.WriteLine("Please enter a number.\nThe second entry is in an invalid format.");
                            }
                        }
                        else {
                            done = true;
                        }
                    }
                    else {
                        Console.WriteLine("Please enter a number.\nThe first entry is in an invalid format.");
                    }
          }
                else {
                    done = true;
                }
            }
        }
    }
}
