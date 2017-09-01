using System;

namespace collectionspractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[10];
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = i;               
            }
            string[] nameArray = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] booleanArray = new bool[10];
            for (int i = 0; i < booleanArray.Length; i++)
            {
                if (i % 2 == 0){
                    booleanArray[i] = true;
                }
                else{
                    booleanArray[i] = false;
                }
            }
            int[,,] multiTableArray = new int[10,1,10];
            int x = 0;
            foreach (int[] row in multiTableArray)
            {
                x = x + 1;
                for (int i = 1; i <= row.Length; i++)
                {
                    row[i] = x * i;
                }
            }
            System.Console.WriteLine(multiTableArray);
        }  
    }
}
