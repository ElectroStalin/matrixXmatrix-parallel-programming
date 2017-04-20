using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace matrixXmatrix
{
    class Program
    {
        private static object threadLock = new object();
        static int mSize = 5000;
        static int threadsNum = 4;
        static double[,] matr1 = new double[mSize,mSize] ;
        static double[,] matr2 = new double[mSize, mSize];
        static double[,] matrRes = new double[mSize, mSize];
        static void count(object x)
        {
            double sum;
            int s = (int)x;
            for (int i = s * mSize / threadsNum; i < (s + 1) * mSize / threadsNum; i++)
            {
                for (int j = 0; j < mSize; j++)
                {
                    sum = 0;
                    for (int k = 0; k < mSize; k++)
                    {
                        sum += matr1[i,k] * matr2[k,j];
                    }
                    matrRes[i, j] = sum;
                }
            }
            Thread.Sleep(0);
        }


        static void Main(string[] args)
        {
            Random rnd = new Random();

           for (int i = 0; i < mSize; i++)
            {
                for (int j = 0; j < mSize; j++)
                {
                    matr1[i,j] = rnd.Next(0, 10);
                    matr2[i,j] = rnd.Next(0, 10);
                }
            }
           //DateTime start = DateTime.Now;

            List<Thread> threads = new List<Thread>();
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            

            
            
                for (int i = 0; i < threadsNum; i++)
                {
                    threads.Add(new Thread(new ParameterizedThreadStart(count)));
                    threads[i].Start(i);

                }
                
            
            Thread.Sleep(2000);
            time.Stop();
            Console.WriteLine(time.Elapsed);
            

/*
            Console.WriteLine("\n\n" + "matr1");
            for (int i = 0; i < mSize; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mSize; j++)
                {
                    Console.Write(matr1[i, j] + " ");
                }
            }
            Console.WriteLine("\n\n" + "matr2");
            for (int i = 0; i < mSize; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mSize; j++)
                {
                    Console.Write(matr2[i, j] + " ");
                }
            }
            Console.WriteLine("\n\n" + "matrRes");
            for (int i = 0; i < mSize; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < mSize; j++)
                {
                    Console.Write(matrRes[i, j] + " ");
                }
            }
 */
            Console.Read();

        }
    }

}
