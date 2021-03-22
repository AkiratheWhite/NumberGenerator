using System;
using System.Collections.Generic; //For Lists and Enumerables.
using System.Linq; //LINQ in C# is used to run a query against the list.

namespace NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare random class to create random numbers.
            Random rand = new Random();

            //Declare list to hold numbers. This will be the list outputted.
            List<int> numbersOutput = new List<int>();

            List<int> allValues = new List<int>(); //List to hold every possible number from 1 to 10000.
            List<int> existingValues = new List<int>(); //List to store values that have been added to 'numbersOutput'.

            //Do-while loop to create a list with all numbers from 1 - 10000.
            do
            {
                //Add numbers to the list until we have all 10000 values.
                allValues.Add((allValues.Count + 1));
            }
            while (allValues.Count < 10000);

            //Show user that program is running.
            Console.WriteLine("Generating list of 10000 numbers in random order without any duplicates...");

            //Do-while loop to procedurally add unique values to the 'numbersOutput' list.
            do
            {
                /*Using Enumerable.Except to find values that have not been used yet. This creates a new enuermable
                 that has elements from 'allValues' as long as those values don't also exist in 'existingValues'
                 The enumerable 'notIncluded' has to be reinstantiated on every iteration of the loop.
                
                The logic should be like a LEFT JOIN with no intersection, and the corresponding SQL would probably be:
                 * SELECT *
                 * FROM allValues LEFT JOIN existingValues
                 * ON allValues.Value = existingValues.Value
                 * WHERE existingValues.Value IS NULL
                 */
                IEnumerable<int> notIncluded = allValues.Except(existingValues);

                /* Picks a random value from 'notIncluded' to 'numbersOutput' called 'newNumber'.
                Enumerables use a 0 index, so this code gets a random index that is greater than 0 
                and less than the number of elements in the Enumerable.*/
                int newNumber = notIncluded.ElementAt(rand.Next(notIncluded.Count()));

                //The value added is appended to existingValues, so that it is filtered out in subsequent iterations.
                existingValues.Add(newNumber);
                numbersOutput.Add(newNumber); //newNumber is added to numbersOutput.
            }
            while (numbersOutput.Count != allValues.Count); //Loop will only run until every single value in allValues has been used exactly once.

            Console.WriteLine("List generated."); //Message to show that list was generated.
            //Using IEnumerable.Distinct.Count to prove that we have 10000 unique values.
            Console.WriteLine($"Count of distinct elements: {numbersOutput.Distinct().Count()}");
            
            //Display the first and last elements so that it's easy to see that a unique sequence is generated on each program execution.
            Console.WriteLine($"First element: {numbersOutput.First()}");
            Console.WriteLine($"Last element: {numbersOutput.Last()}");

            Console.ReadKey(); //Awaits key so that console does not close until user chooses to close.
        }
    }
}
