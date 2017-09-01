using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program

    {
        private static Random random = new Random();
        private static int[] generateArray(int number, int minValue, int maxValue){
            
            int[] randomArray = new int[number];
            for (int i = 0; i < number; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue+1);
            }
            return randomArray;
        }

        private static void printMinMax(int[] array){
            int minimim = int.MaxValue;
            int maximum = int.MinValue;

            foreach (int item in array)
            {
                if(item <= minimim){
                    minimim = item;
                }
                if(item >= maximum){
                    maximum = item;
                }
            }

            System.Console.WriteLine("Min: {0} Max: {1}", minimim, maximum);

        }

        private static void printSum(int[] array){
            int sum = 0;
            foreach (int item in array)
            {
                sum += item;
            }
            System.Console.WriteLine(sum);
        }

        private static string TossCoin(){
            System.Console.WriteLine("Tossing a Coin!");
            int flip = random.Next(0,2);
            string result;
            if(flip == 0){
                result = "Head";
            } else {
                result = "Tail";
            }
            return result;
        }
        private static double TossMultipleCoins(int num){
            int head = 0;
            int tail = 0;
            for(int i = 0; i < num; i++){
                if(TossCoin() == "Head"){
                    System.Console.WriteLine("Head!");
                    head += 1;
                    System.Console.WriteLine("Total Head: " + head);
                } else {
                    System.Console.WriteLine("Tail!");
                    tail += 1;
                    System.Console.WriteLine("Total Tail: " + tail);
                }
            }
            double ratio = (double)head/(double)tail;
            return ratio;
        }

        private static List<string> Names(){
            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            for(int i = 0; i < names.Length; i++){
                string temp = names[i];
                int idx = random.Next(i, names.Length);
                names[i] = names[idx];
                names[idx] = temp;
            }
            string print = "Shuffled: [";
            foreach (string item in names)
            {
                print += item + ", ";
            }
            print += "]";
            System.Console.WriteLine(print);
            List<string> newList = new List<string>();
            foreach (var item in names)
            {
                if(item.Length > 5){
                    newList.Add(item);
                }
            }
            return newList;
        }
        static void Main(string[] args)
        {
            int[] randomArray = generateArray(100, 0, 100);
            printMinMax(randomArray);
            printSum(randomArray);
            System.Console.WriteLine(TossCoin());
            System.Console.WriteLine("Ratio: " + TossMultipleCoins(20));
            Names();
        }
    }
}
