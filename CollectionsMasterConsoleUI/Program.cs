using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DONE: Follow the steps provided in the comments under each region.
            //DONE - Make the console formatted to display each section well
            //DONE - Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //DONE: Create an integer Array of size 50

            var numArray = new int[50];


            //DONE: Create a method to populate the number array with 50 random numbers that are between 0 and 50
                        
            Populater(numArray);


            //DONE: Print the first number of the array

            Console.Write("The first number of the array: ");
            Console.WriteLine(numArray[0]);
            Console.WriteLine("-------------------");


            //DONE: Print the last number of the array

            Console.Write("The last number of the array: ");
            Console.WriteLine(numArray[numArray.Length -1]);
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers Original");
            //DONE: UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numArray);
            Console.WriteLine("-------------------");

            //DONE: Reverse the contents of the array and then print the array out to the console.
                //Try for 2 different ways
                /*  1) First way, using a custom method => Hint: Array._____(); 
                    2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
                */

            Console.WriteLine("All Numbers Reversed:");
            Array.Reverse(numArray);
            NumberPrinter(numArray);


            Console.WriteLine("---------REVERSE CUSTOM------------");

            numArray = ReverseArray(numArray);
            NumberPrinter(numArray);



            Console.WriteLine("-------------------");

            //DONE: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");

            numArray = ThreeKiller(numArray);
            NumberPrinter(numArray);
            

            Console.WriteLine("-------------------");

            //DONE: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");

            Array.Sort(numArray);
            NumberPrinter(numArray);
            

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //DONE: Create an integer List

            var intList = new List<int>();

            //DONE: Print the capacity of the list to the console

            Console.WriteLine(intList.Capacity);


            //DONE: Populate the List with 50 random numbers between 0 and 50 you will need a method for this

            Populater(intList);
            //NumberPrinter(intList);


            //DONE: Print the new capacity

            Console.WriteLine(intList.Capacity);
            

            Console.WriteLine("---------------------");

            //DONE: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!

            bool parseBool = false;
            int parseNumber = 0;
            
            do
            {
                Console.Write("What number will you search for in the number list? ");
                string userInput = Console.ReadLine();
                                
                parseBool = Int32.TryParse(userInput, out parseNumber);

                if (parseBool == false)
                {
                    Console.WriteLine($"{userInput} is not a valid whole number entry.");
                }                                  
                
            } while (parseBool == false);
            
            
           
            NumberChecker(intList, parseNumber);
            
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");

            //DONE - UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(intList);
            Console.WriteLine("-------------------");


            //DONE: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");

            intList = OddKiller(intList);
            NumberPrinter(intList);
            
            Console.WriteLine("------------------");

            //DONE: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");

            intList.Sort();
            NumberPrinter(intList);
            
            Console.WriteLine("------------------");

            //DONE: Convert the list to an array and store that into a variable
            Console.WriteLine("------------here is the newArray------------");
            int[] newArray = intList.ToArray();
            NumberPrinter(newArray);

            //DONE: Clear the list
            Console.WriteLine("------------here is the cleared list------------");
            intList.Clear(); 
            NumberPrinter(intList);
            
            #endregion
        }
        private static int[] ThreeKiller(int[] numbers)
        {            
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0) numbers[i] = 0;
            }
            return numbers;
        }

        private static List<int> OddKiller(List<int> numberList)
        {
            var evenList = new List<int>();
            foreach (int num in numberList)
            {
                if (num % 2 == 0)
                {
                    evenList.Add(num);
                }
            }
            return evenList;
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine($"{searchNumber} IS on the list.");
            }
            else
            {
                Console.WriteLine($"{searchNumber} is NOT on the list.");
            }            
        }            
    

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(0, 50));
            }

        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(0, 50);
            }

        }        

        private static int[] ReverseArray(int[] array)
        {
            int[] reverseArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reverseArray[i] = array[array.Length -1 - i];
            }
            return reverseArray;
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
