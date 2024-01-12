using System;
using System.Diagnostics;
using System.IO;

namespace Lab0 // Student: Juan Nova, ID: 000923635
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task #1
            Console.WriteLine("Task 1: Creating Variables");
            int low = GetLow();
            int high = GetHigh(low);
            int difference = WriteDifference(low, high);
            List<double> result = GenerateList(difference, high, low);
            PrimeNumbers(result);

            static int GetLow()
            {
                Console.WriteLine("Please enter a low number");
                int newLow;
                while (true)
                {
                    Console.WriteLine("Executing Task #2 - Low Number");
                    string low = Console.ReadLine();
                    // Check if lowest num is a valid input and is greater than 0
                    if (int.TryParse(low, out newLow) && newLow > 0)
                    {
                        return newLow;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }

            }

            static int GetHigh(int lowNum)
            {
                Console.WriteLine("Please enter a high number");
                int newHigh;
                while (true)
                {
                    Console.WriteLine("Executing Task #2 - High Number");
                    string high = Console.ReadLine();
                    // Check if highest num is a valid input and is greater than 'lowNum'
                    if (int.TryParse(high, out newHigh) && newHigh > lowNum )
                    {
                        return newHigh;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input!");
                    }
                }
            }

            static int WriteDifference(int lowNum, int highNum)
            {   
                // Return the positive difference between both numbers
                int dif = highNum - lowNum;
                Console.WriteLine($"The difference is {dif}");
                return dif;
            }

            static List<double> GenerateList(int dif, int highNum, int lowNum)
            {
                Console.WriteLine("Task 3: Using Arrays and File I/O");
                List<double> listOfNums = new List<double>();

                // Define 'path' as the absolute path of 'numbers.txt'
                string path = "C:\\Users\\asus\\OneDrive\\Documents\\SAIT\\6. Object-Oriented Programming II\\C#\\Basics Of C# - Lab 0\\Basics Of C# - Lab 0\\numbers.txt";

                // Iterate through the numbers between the highest and lowest number in reverse
                for(double i = 1.0; i < dif; i++)
{
                    double num = Convert.ToDouble(highNum - i);
                    listOfNums.Add(num);
                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (double num in listOfNums)
                    {
                        sw.WriteLine(num);
                    }
                }
                using (StreamReader sr = new StreamReader(path))
                {
                    // Iterate through each line on the 'numbers.txt' file 
                    string line;
                    int total = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Convert value to a number and add it to the 'total' variable
                        int num = int.Parse(line);
                        total += num;
                    }
                    Console.WriteLine($"The sum of all the numbers between {lowNum} and {highNum} is: {total}");
                }
                return listOfNums;
            }

            static void PrimeNumbers(List<double> listOfNums)
            {
                Console.WriteLine("Aditional Task: Find prime numbers");
                // For each number between lowest and highest number: 
                foreach (int num in listOfNums)
                {
                    bool isPrime = true;
                    // Iterate from 2 to the square of 'num' 
                    for (int i = 2; i <= Math.Sqrt(num); i++)
                    {
                        // Find possible divisors other than 1 and 'num' itself
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime && num != 0)
                    {
                        Console.WriteLine(num);
                    }
                }
            }
        }
    }
}