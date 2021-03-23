using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            List<int> numbersOutput = new List<int>(); //List to hold numbers.
            List<int> allValues = new List<int>(); //List to hold every possible number from 1 to 10000.

            //Do-while loop to create a list with all numbers from 1 - 10000.
            do
            {
                allValues.Add((allValues.Count + 1));
            }
            while (allValues.Count < 10000);

            Console.WriteLine("Generating list of 10000 numbers in random order without any duplicates...");

            //Do-while loop to procedurally add unique values to the 'numbersOutput' list.
            do
            {
                int index = rand.Next(allValues.Count());
                int newNumber = allValues.ElementAt(index);

                numbersOutput.Add(newNumber);
                allValues.RemoveAt(index);
            }
            while (allValues.Count != 0);

            Console.WriteLine("List generated.");
            Console.WriteLine($"Count of distinct elements: {numbersOutput.Distinct().Count()}");
            
            //Display the first and last elements so that it's easy to see that a unique sequence is generated on each program execution.
            Console.WriteLine($"First element: {numbersOutput.First()}");
            Console.WriteLine($"Last element: {numbersOutput.Last()}");

            Console.ReadKey();
        }
    }
}
