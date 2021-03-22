
using System;
using System.Diagnostics.CodeAnalysis;

namespace ReverseIT
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // declaring an array with 9 element

            Shuffle(array);

            int cnt = 0; //Count how many moves it would take to sort the array
            int m;

            while (IsSorted(array) != true)
            {
                PrintArray(array);
                Console.WriteLine("Enter how many numbers you want to reverse: ");
                m = int.Parse(Console.ReadLine()); //Re-enter how many numbers you want to reverse inside the array

                if (m > 9 || m <= 0)
                {
                    Console.WriteLine("Please only enter numbers from 1 to 9");
                    continue;
                }

                cnt++; //Count moves


                Reverse(array, array.Length, m); //Reverse array again
            }


            Console.WriteLine("It took " + cnt +
                              " moves to sort the array"); 

            PrintArray(array); //print the number of moves it took to sort it
        }

        static bool IsSorted(int[] arr) //method to check whether the array is sorted or not
        {
            for (int i = 0; i < arr.Length - 1; i++) //length - 1 in order to avoid errors in the last iteration
            {
                if (arr[i] > arr[i + 1])
                    return false; //array not sorted in ascending order
            }

            return true; // array sorted in ascending order
        }

        static void swap(int[] arr, int a, int b)
        {
            int temp = arr[a]; //swap = arr[0];
            arr[a] = arr[b]; //Ex i = 0, revNum = 4 -> arr[0] = arr[4 - 0 - 1] -> arr[0] = arr[3] 
            arr[b] = temp; //Ex arr[3] = swap -> arr[0] swapped positions with arr[3]
        }

        static void Reverse(int[] arr, int length, int reverseNum) //Reversing array method
        {
            for (int i = 0; i < reverseNum / 2; i++)
            {
                //The first iteration i = 0
                swap(arr, i, reverseNum - i - 1);
            }
        }
          private static void Shuffle(int[] array) //shuffle array
          {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int a = rnd.Next(1, 9);
                int b = rnd.Next(1, 9);
                swap(array, a, b);
            }
          }

        static void PrintArray(int[] array)
        {
            string output = "{";
            for (int i = 0; i < array.Length; ++i)
            {
                output += array[i];
                if (i != array.Length - 1)
                {
                    output += ", ";
                }
            }

            output += "}";

            Console.Out.WriteLine(output);
        }
    }
}