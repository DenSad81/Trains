using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dispetcher dispetcher = new Dispetcher();
        dispetcher.Work();
    }
}

static class Utils
{
    public static string ReadString(string text = "")
    {
        Console.Write(text + " ");
        string stringFromConsole = Console.ReadLine();
        return stringFromConsole;
    }

    public static int ReadInt(string text = "")
    {
        int digitToOut;
        Console.Write(text + " ");

        while (int.TryParse(Console.ReadLine(), out digitToOut) == false)
            Console.Write(text + " ");

        return digitToOut;
    }
}

class Dispetcher
{
    private List<Train> _trains;

    public Dispetcher()
    {
        _trains = new List<Train>();
    }

    public void Work()
    {
        const string Yes = "yes";

        int minQuantityOfPassengers = 120;
        int maxQuantityOfPassengers = 180;       
        Random random = new Random();
        bool isRun = true;

        while (isRun)
        {
            ShowAll();
            int quantityOfPassengers = random.Next(minQuantityOfPassengers, maxQuantityOfPassengers);
            if (Utils.ReadString("Creete the new train? (yes/no): ") == Yes)
                AddTrain(GetNewTrain(quantityOfPassengers));

            if (Utils.ReadString("Exit? (yes/no): ") == Yes)
                isRun = false;
        }
    }

    private void AddTrain(Train train)
    {
        _trains.Add(train);
    }

    private Train GetNewTrain(int quantityPassengers)
    {
        int quantityPlasesPerOneWagon = 20;

        string pointOfDeparture = Utils.ReadString("Inpout point of department:");
        string pointOfArrival = Utils.ReadString("Inpout point of arrival:");
        int numberOfTrain = Utils.ReadInt("Inpout number of train:");
        int quantityOfWagon = quantityPassengers / quantityPlasesPerOneWagon;

        return new Train(pointOfDeparture, pointOfArrival, numberOfTrain, quantityOfWagon, quantityPlasesPerOneWagon);
    }

    private void ShowAll()
    {
        Console.Clear();
        Console.SetCursorPosition(0, 0);

        Console.WriteLine("### number ### Departur ### Arrival ### Carriage ### Date ##### Time ###");

        for (int i = 0; i < _trains.Count; i++)
            _trains[i].ShowData(0, i + 1);

        Console.WriteLine("########################################################################");
    }
}

class Train
{
    private string _pointOfDeparture;
    private string _pointOfArrival;
    private int _number;
    private int _quantityOfWagons;
    private DateTime _dateTime;
    private List<Wagon> _wagons;

    public Train(string pointOfDeparture, string pointOfArrival, int number, int quantityOfWagons, int quantityPlasesPerOneWagon)
    {
        _number = number;
        _quantityOfWagons = quantityOfWagons;
        _pointOfDeparture = pointOfDeparture;
        _pointOfArrival = pointOfArrival;
        _dateTime = DateTime.Now;

        for (int i = 0; i < quantityOfWagons; i++)
            _wagons.Add(new Wagon(quantityPlasesPerOneWagon));
    }

    public void ShowData(int positionForShowX, int positionForShowY)
    {
        Console.SetCursorPosition(positionForShowX + 4, positionForShowY);
        Console.Write(_number);
        Console.SetCursorPosition(positionForShowX + 15, positionForShowY);
        Console.Write(_pointOfDeparture);
        Console.SetCursorPosition(positionForShowX + 28, positionForShowY);
        Console.Write(_pointOfArrival);
        Console.SetCursorPosition(positionForShowX + 40, positionForShowY);
        Console.Write(_quantityOfWagons);
        Console.SetCursorPosition(positionForShowX + 53, positionForShowY);
        Console.Write(_dateTime);
        Console.WriteLine();
    }

    class Wagon
    {
        private List<string> _passangers;
        private int _quantityPlace;

        public Wagon(int quantityPlace)
        {
            _quantityPlace = quantityPlace;
            _passangers = new List<string>(_quantityPlace);
        }
    }
}