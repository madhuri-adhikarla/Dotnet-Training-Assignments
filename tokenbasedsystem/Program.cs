using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tokenbasedsystem
{
    class Program
    {
        public static Queue<int> tokens = new Queue<int>();
        public static int[] arr = new int[100];
        public static int counters = 0;
        public static int clearQueue = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("enter no of counters");
            counters = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter no of tokens");
            int tokensNo = Int32.Parse(Console.ReadLine());

            for(int j=0;j<arr.Length;j++)
            {
                arr[j] = 9999;
            }

            for (int i = 1; i <= tokensNo; i++)
            {
                tokens.Enqueue(i);
            }

            for(int j=1;j<=counters;j++)
            {
                arr[j] = 0;
            }
            assignTokens();

            while (tokens.Count != 0)
            {
                Console.WriteLine("select a queue to clear : ");
                clearQueue = Int32.Parse(Console.ReadLine());
                if (0 < clearQueue && clearQueue <= counters)
                {
                    clear(clearQueue);
                }
                else
                {
                    Console.WriteLine("enter a valid counter number");
                }

            }

            Console.ReadKey();
        }

        private static void assignTokens()
        {
            for(int i=1;i<=counters;i++)
            {
                if(arr[i]==0)
                {
                    arr[i] = 1;
                    Console.WriteLine("assigning token " + tokens.Peek() + " to counter --> " + i);
                    tokens.Dequeue();

                }
            }
            Console.WriteLine("remianing token = " +tokens.Count);
           // display();
        }

        //private static void display()
        //{
        //    Console.WriteLine("remianing tokens" + tokens.Count);
        //}

        private static void clear(int index)
        {
            arr[index] = 0;
            assignTokens();

        } 

        
    }
}
