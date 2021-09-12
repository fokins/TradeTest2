using System;
using System.Threading;
using System.Collections.Generic;

class Trade
{
    int Price;
    Random rnd;

    public void RandomPrice(int rand)
    {
        rnd = new Random(rand);
        Price = rnd.Next(0, 100);
    }

    public int GetPrice()
    {
        return Price;
    }
}

class Processing
{
    static Queue<int> Prices = new Queue<int>();

    static void Main()
    {
        Thread Generator = new Thread(GenerateTrade);
        Generator.Start();

        while (true)
        {
            if(Prices.Count > 0)
            {
                Console.WriteLine(Prices.Dequeue());
            }
        }
    }

    static void GenerateTrade()
    {
        for (int i = 0; i < 100; i++)
        {
            Trade t = new Trade();
            t.RandomPrice(i);
            Prices.Enqueue(t.GetPrice());
            Thread.Sleep(1);
        }
    }
}

