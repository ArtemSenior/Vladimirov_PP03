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
                return y.Duration.CompareTo(x.Duration); // Сортировка по длительности в порядке убывания
            else
                return y.Price.CompareTo(x.Price); //Если продолжительность одинакова, сортируется по убыванию цены 
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

