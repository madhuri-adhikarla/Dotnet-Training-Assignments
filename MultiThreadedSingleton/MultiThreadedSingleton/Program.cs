using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreadedSingleton
{
   
    public class SingleInstanceClass
    {
        public static bool available = true;

        private static readonly object mutex = new object();
        private static SingleInstanceClass instance = null;

        private SingleInstanceClass()
        {
        }

        public static SingleInstanceClass GetInstance()
        {
            if (instance == null)
            {
                lock (mutex)
                {
                    if (instance == null)
                    {

                        instance = new SingleInstanceClass();
                    }

                    
                }
            }

            return instance;
        }

        private static void getAvailability()
        {
            GetInstance();
            if (available == true)
            {
                Console.WriteLine("thread -->" + Thread.CurrentThread.Name);
                available = false;
            }

        }


        static void Main(string[] args)
        {
            Thread t1 = new Thread(getAvailability);
            t1.Name = "Thread1";
            t1.Start();
            Thread t2 = new Thread(getAvailability);
            t2.Name = "Thread2";
            t2.Start();
            Console.ReadKey();
        }
        //public static void m1()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Thread.Sleep(3000);
        //        Console.WriteLine("Hello Madhuri");
        //    }
        //}

        
    }
   
}


