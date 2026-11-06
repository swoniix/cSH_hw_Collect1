using System;
using System.Collections;

class Alphabet : IEnumerable<char>
{
    public IEnumerator<char> GetEnumerator()
    {
        for (char letter = 'A'; letter <= 'Z'; letter++)
            yield return letter;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Apartment : IEnumerable<string>
{
    private readonly List<string> residents = new();

    public void AddResident(string name) => residents.Add(name);

    public IEnumerator<string> GetEnumerator()
    {
        foreach (string resident in residents)
            yield return resident;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class House : IEnumerable<Apartment>
{
    private readonly List<Apartment> apartments = new();

    public void AddApartment(Apartment apartment) => apartments.Add(apartment);

    public IEnumerator<Apartment> GetEnumerator()
    {
        foreach (Apartment apartment in apartments)
            yield return apartment;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Car
{
    public string Brand { get; }
    public string Model { get; }

    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public override string ToString() => $"{Brand} {Model}";
}

class Garage : IEnumerable<Car>
{
    private readonly List<Car> cars = new();

    public void AddCar(Car car) => cars.Add(car);

    public IEnumerator<Car> GetEnumerator()
    {
        foreach (Car car in cars)
            yield return car;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Program
{
    static void Main()
    {
        // 1
        var alphabet = new Alphabet();
        foreach (char letter in alphabet)
            Console.Write($"{letter} ");
        Console.WriteLine();
        //2
        var apartment1 = new Apartment();
        apartment1.AddResident("Resident1");
        apartment1.AddResident("Resident2");
        var apartment2 = new Apartment();
        apartment2.AddResident("Resident3");
        var house = new House();
        house.AddApartment(apartment1);
        house.AddApartment(apartment2);
        int apartmentNumber = 1;
        foreach (Apartment apartment in house)
        {
            Console.WriteLine($"Apartment {apartmentNumber++}:");

            foreach (string resident in apartment)
                Console.WriteLine($"  {resident}");
        }

        //3
        var garage = new Garage();
        garage.AddCar(new Car("Toyota", "Corolla"));
        garage.AddCar(new Car("Honda", "Civic"));

        foreach (Car car in garage)
            Console.WriteLine(car);
    }
}