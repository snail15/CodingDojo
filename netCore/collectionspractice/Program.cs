using System;
using System.Collections.Generic;

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
            int[,] multiTableArray = new int[10,10];
            for (int i = 0; i < 10 ; i++) {
                for (int j = 0; j < 10; j++){
                    multiTableArray[i,j] = (i+1) * (j+1);
                }
            }
             for(int x = 0; x < 10; x++)
            {
                string display = "[ ";
                for(int y = 0; y < 10; y++)
                {
                    display += multiTableArray[x, y] + ", ";
                    //Add an extra space for single digit values
                    if(multiTableArray[x,y] < 10)
                    {
                        display += " ";
                    }
                }
                display += "]";
                Console.WriteLine(display);
            }


            //List of Ice Cream Flavors
            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Vanilla");
            flavors.Add("Rocky Road");
            flavors.Add("Cookie Dough");
            flavors.Add("Neopolotan");
            flavors.Add("Rainbow Sherbet");

            //Output the length of the List
            Console.WriteLine(flavors.Count);

            //Print the 3rd value then remove it
            Console.WriteLine("The third flavor in the list is: " + flavors[2]);
            flavors.RemoveAt(2);

            //Output the updated length of the List of flavors
            Console.WriteLine(flavors.Count);
            

            //User Dictionary Construction
            Dictionary<string, string> userInfo = new Dictionary<string,string>();
            Random rand = new Random();
            foreach(string name in nameArray)
            {
                userInfo[name] = flavors[rand.Next(flavors.Count)];
            }

            //Looping through info Dictionary
            Console.WriteLine("Users and their favor ice cream flavors:");
            foreach(KeyValuePair<string, string> info in userInfo)
            {
                Console.WriteLine(info.Key + " - " + info.Value);
            }

        }  
    }
}
