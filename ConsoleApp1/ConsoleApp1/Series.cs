using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Series
    {
        public void Show()
        {
            IFunction function = null;
            int number = Int32.MaxValue;

            while (number != 0)
            {

                SelectNumber(ref number);

                if (number == 0)
                {
                    break;
                }

                CreateFunction(ref function, number);

                double start = -1, end = -1;
                double step = -1;

                ReadIntervalAndStep(ref start, ref end, ref step);

                PrintFunction(start, end, step, function);

                Console.WriteLine("");
            }
        }
        private IFunction ReadAndCreate(char function)
        {
            if (function == 'P')
            {
                string str = Console.ReadLine();
                string[] words = str.Split(' ');
                double[] multipliers = new double[3];

                if (words.Length != 3)
                {
                    throw new ArgumentException("Uncorrect line");
                }

                for (int i = 0; i < 3; i++)
                {
                    multipliers[i] = Convert.ToDouble(words[i]);
                }

                return new Parabola(multipliers[0], multipliers[1], multipliers[2]);
            }      

            if (function == 'H')
            {
                double multiplier;

                multiplier = Convert.ToInt32(Console.ReadLine());

                return new Hyperbola(multiplier);
            }

            throw new ArgumentException("Uncorrect argument!");
        }
        private void SelectNumber(ref int number)
        {
            bool condition = true;

            while (condition)
            {
                try
                {
                    PrintMenu();
                    number = Convert.ToInt32(Console.ReadLine());

                    if (number == 0 || number == 1 || number == 2)
                    {
                        condition = false;
                    }

                    if (condition)
                    {
                        Console.WriteLine("Repeat please!");
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    Console.WriteLine("Repeat please!");
                }
            }
        }
        private void PrintMenu()
        {
            Console.WriteLine("1. Hyperbola");
            Console.WriteLine("2. Parabola");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Select function: ");
        }
        void CreateFunction(ref IFunction function, int number)
        {
            bool scanFlag = true;

            while (scanFlag)
            {
                try
                {
                    switch (number)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter a multiplier of Hyperbola (One number): ");
                                function = ReadAndCreate('H');
                                scanFlag = false;
                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("\nEnter a multipliers of Parabola(Three numbers separated by a space. Example: 1 2 3): ");
                                function = ReadAndCreate('P');
                                scanFlag = false;
                            }
                            break;
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    Console.WriteLine("Repeat please!");
                }
            }
        }
        void ReadIntervalAndStep(ref double start, ref double end, ref double step)
        {
            bool scanFlag = true;
            while (scanFlag)
            {
                try
                {
                    Console.WriteLine("Start: ");
                    start = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("End: ");
                    end = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Step: ");
                    step = Convert.ToDouble(Console.ReadLine());
                    scanFlag = false;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    Console.WriteLine("Repeat please!");
                }
            }
        }
        void PrintFunction(double start, double end, double step, IFunction function)
        {
            for (double x = start; x <= end; x += step)
            {
                try
                {
                    PrintResult(x, function.Calculate(x), function);
                }
                catch (Exception err)
                {
                    PrintErrorMessage(x, err.Message, function);
                }
            }
        }
        void PrintResult(double x, double result, IFunction function)
        {
            String type = function.GetType().Name;

            switch (type)
            {
                case "Hyperbola":
                    Console.WriteLine($"{type}( {function.At(0)}/x ) = {result}, where x = {x}");
                    break;
                case "Parabola":
                    Console.WriteLine($"{type}( {function.At(0)}*x^2 + {function.At(1)}*x + {function.At(2)} ) = {result}, where x = {x}");
                    break;
            }
        }
        void PrintErrorMessage(double x, String message, IFunction function)
        {
            String type = function.GetType().Name;

            switch (type)
            {
                case "Hyperbola":
                    Console.WriteLine($"{type}( {function.At(0)}/x ) = {message}, where x = {x}");
                    break;
                case "Logarithm":
                    Console.WriteLine($"{type}( Log{function.At(0)}(x) ) = {message}, where x = {x}");
                    break;

            }
        }
    }
}
