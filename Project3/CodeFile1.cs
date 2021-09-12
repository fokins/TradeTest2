using System;
using System.Threading.Tasks;
using System.Collections.Generic;

class Trade
{
    int Price;
    int DateTime;

    public Trade(int price)
    {
        Price = price;
    }

    public int price
    {
        get {  return (int)Price; }
    }

    public override string ToString()
    {
        return "Price:" + Price.ToString();
    }
}

class Processing
{
    static Queue<Trade> Prices = new Queue<Trade>();

    static void Main()
    {
        Task generator = new Task(() => GenerateTrade());

        generator.Start();


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

        Random rnd;

        for (int i = 0; i < 100; i++)
        {
            rnd = new Random(i);
            Trade t = new Trade(rnd.Next(1, 100));

            Prices.Enqueue(t);
        }
    }
}

