using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class CoffeeMachine
    {
        public void Use()
        {
            while (true)
            {
                Greeting();
                string input = Console.ReadLine();

                if (input.Length > 0)
                {
                    if (!string.Equals(input, "1") && !string.Equals(input, "0"))
                    {
                        WrongChoice();
                    }
                    else if (string.Equals(input, "0"))
                    {
                        Exit();
                        return;
                    }
                    else if (string.Equals(input, "1"))
                    {
                        MakeCoffee();
                    }
                    Console.WriteLine("");
                }
            }
        }

        private void Greeting()
        {
            Console.WriteLine("=====");
            Console.WriteLine("Hello, how can I help you?");
            Console.WriteLine("1. Make coffee");
            Console.WriteLine("0. Exit");
        }

        private void MakeCoffee()
        {
            Console.WriteLine("Good choice, enjoy your coffee!");
        }

        private void WrongChoice()
        {
            Console.WriteLine("Wrong choice :) Try again ;)");
        }

        private void Exit()
        {
            Console.WriteLine("Have a good day!");
        }

    }
}
