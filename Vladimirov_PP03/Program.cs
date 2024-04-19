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
        Destination = destination; // направление поездки место назначения  string
        Duration = duration; // продолжительность int
        Price = price; // цена double
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
                return y.Duration.CompareTo(x.Duration); // Сортировка по длительности в порядке убывания
            else
                return y.Price.CompareTo(x.Price); // Если продолжительность одинакова, сортируется по убыванию цены 
        });
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Tour tour in tours)
            {
                writer.WriteLine($"Направление поездки: {tour.Destination}, Продолжительность: {tour.Duration}, Цена: {tour.Price}");
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

        try
        {  
            Console.Write("Введите кол-во туров: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    Console.Write("Введите направление поездки: ");
                    string destination = Console.ReadLine();
                    Console.Write("Введите продолжительность: ");
                    int duration = int.Parse(Console.ReadLine());
                    Console.Write("Введите цену: ");
                    double price = double.Parse(Console.ReadLine());

                    Tour tour = new Tour(destination, duration, price);
                    agency.AddTour(tour);



                    // сорт массива
                    agency.SortTours();

                    // сохр уже отсорт массива в файл
                    agency.SaveToFile("tours.txt");

                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный формат данных. Введите корректные данные текущего направления.");
                    i--; // уменьшаем счетчик
                }
                
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Некорректный формат данных для количества туров.");
        }
        Console.WriteLine("Туры были отсоротированы и сохранены в tours.txt");
    }
}