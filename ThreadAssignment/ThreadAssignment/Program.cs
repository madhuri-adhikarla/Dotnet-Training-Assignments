using System;
using System.Threading;


public class ThreadAssignment
{
    public object obj = new object();

    // variable to print the sequence
    public int counter = 0;
    int semaphore = 0;

    //print zero after every even or odd number of the sequence
    public void zero()
    {
        try
        {
            // to print the sequence from 0-9
            while (counter < 9)
            {
                if (semaphore == 0)
                {
                    lock (obj)
                    {
                        Console.Write("0");
                        if (counter == 0)
                            counter++;
                    }
                    if (counter % 2 == 0)
                    {
                        semaphore = 2;
                    }
                    else
                    {
                        semaphore = 1;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }


    }

    // to print even number of the sequence
    public void even()
    {
        try
        {
            while (counter < 9)
            {
                if (semaphore == 2)
                {
                    lock (obj)
                    {
                        if (counter % 2 == 0)
                        {
                            Console.Write(counter);
                            counter++;
                        }
                        semaphore = 0;
                    }
                }
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }


    // to odd even number of the sequence
    public void odd()
    {
        try
        {
            while (counter < 9)
            {
                if (semaphore == 1)
                {
                    lock (obj)
                    {
                        if (counter % 2 != 0)
                        {
                            Console.Write(counter);
                            counter++;
                        }
                        semaphore = 0;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }

    public static void Main(string[] args)
    {
        ThreadAssignment ta = new ThreadAssignment();
        Thread t1 = new Thread(ta.zero);
        Thread t2 = new Thread(ta.even);
        Thread t3 = new Thread(ta.odd);
        t1.Start();
        t2.Start();
        t3.Start();
        t1.Join();
        t2.Join();
        t3.Join();

    }
}
