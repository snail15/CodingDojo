using System;
using System.Collections.Generic;

namespace boxingunboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> randomList = new List<object>();
            randomList.Add(7);
            randomList.Add(28);
            randomList.Add(-1);
            randomList.Add(true);
            randomList.Add("chair");
            System.Console.WriteLine(randomList);
            int sum = 0;
            foreach (object item in randomList)
            {
                if(item is int){
                    sum += (int)item;
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
