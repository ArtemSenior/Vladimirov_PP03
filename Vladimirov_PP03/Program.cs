using System;
using System.IO;
using System.Collections.Generic;

class Tour
{
    public string Destination { get; set; }
    public int Duration { get; set; }
    public double Price { get; set; }

    public Tour(string destination, int duration, double price)
    {
        Destination = destination; // место назначения
        Duration = duration; // продолжительность
        Price = price; // цена
    }
}

class TouristicAgency
{
    private List<Tour> tours = new List<Tour>();

    public void AddTour(Tour tour)
    {
        tours.Add(tour);
    }

    public void SortTours()
    {
        tours.Sort((x, y) =>
        {
            if (x.Duration != y.Duration)
                return y.Duration.CompareTo(x.Duration); // сортировка по длительности в порядке убывания
            else
                return y.Price.CompareTo(x.Price); // ессли продолжительность одинакова, сортируется по убыванию цены 
        });
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Tour tour in tours)
            {
                writer.WriteLine($"{tour.Destination},{tour.Duration},{tour.Price}");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TouristicAgency agency = new TouristicAgency();


        // запраш колво туров у юзера
        Console.Write("Введите колво туров: ");
        int n = int.Parse(Console.ReadLine());

        // заполн массива
        for (int i = 0; i < n; i++)
        {
            Console.Write("Введите место назначения: ");
            string destination = Console.ReadLine();
            Console.Write("Введите продолжительность: ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Введите цену: ");
            double price = double.Parse(Console.ReadLine());

            Tour tour = new Tour(destination, duration, price);
            agency.AddTour(tour);
        }

        // сорт массива
        agency.SortTours();

        // сохр уже отсорт массива в файл
        agency.SaveToFile("tours.txt");

        Console.WriteLine("Туры были отсоротированы и сохранены в tours.txt");
    }
}