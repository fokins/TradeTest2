using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

class Trade
{
    double Price;
    int DateTime;

    public Trade(double price)
    {
        Price = price;
    }

    public double price { get; set; }

    public override string ToString()
    {
        return $"Price: {Price}";
    }
}

class Processing
{
    static Queue<Trade> Prices = new Queue<Trade>();
    static object locker = new object();

    static void Main()
    {
        Task generator = new Task(() => GenerateTrade());

        generator.Start();


        while (true)
        {
            if(Prices.Count > 0)
            {
                lock (locker)
                {
                    Console.WriteLine(Prices.Dequeue());
                }
            }
            else
            {
                Thread.Sleep(1);
            }
        }
    }

    static void GenerateTrade()
    {

        Random rnd;

        for (int i = 0; i < 100; i++)
        {
            rnd = new Random(i);
            Trade t = new Trade(rnd.Next(1, 100));

            lock (locker)
            {
                Prices.Enqueue(t);
            }

            Thread.Sleep(1000);
        }
    }
}

