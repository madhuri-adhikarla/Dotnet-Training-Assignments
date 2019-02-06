using System;
using System.Collections.Generic;
using System.Linq;

namespace tokens
{
    class Program
    {
        public static Queue<int> q1 = new Queue<int>();
        public static Queue<int> q2 = new Queue<int>();
        public static Queue<int> q3 = new Queue<int>();
        public static Queue<int> tokens = new Queue<int>();
        public static int clearQueue;

        static void Main(string[] args)
        {
            
            Console.WriteLine("enter no of counters");
            int counters = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter no of tokens");

            int tokensNo = Int32.Parse(Console.ReadLine());
            for(int i=1;i<=tokensNo;i++)
            {
                tokens.Enqueue(i);
            }

            assignTokens();
            
            while(tokens.Count!=0)
            {
                Console.WriteLine("select a queue to clear : 1,2 or 3");
                clearQueue = Int32.Parse(Console.ReadLine());
                if (0 < clearQueue && clearQueue <= 3)
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

        public static void assignTokens()
        {
            if(q1.Count==0)
            {
                q1.Enqueue(tokens.First());
                tokens.Dequeue();
            }
            if (q2.Count == 0)
            {
                q2.Enqueue(tokens.First());
                tokens.Dequeue();
            }
            if (q3.Count == 0)
            {
                q3.Enqueue(tokens.First());
                tokens.Dequeue();
            }

            Console.WriteLine("assigning tokens : \n");

            display();

            Console.WriteLine("tokens remaining : " + tokens.Count + "\n");

        }

        public static void clear(int val)
        {
            if(val==1)
            {
                q1.Clear();
                assignTokens();
            }
            else if(val==2)
            {
                q2.Clear();
                assignTokens();

            } else if(val==3)
            {
                q3.Clear(); 
                assignTokens();

            }
            Console.WriteLine(" Current counter status :");
            display();
        }

        public static void display()
        {
            Console.WriteLine("counter 1    " + q1.Peek() + "\n");
            Console.WriteLine("counter 2    " + q2.Peek() + "\n");
            Console.WriteLine("counter 3    " + q3.Peek());
        }

    }
}
