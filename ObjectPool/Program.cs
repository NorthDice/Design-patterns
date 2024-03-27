using Patterns.Reactor;
using System;
using Templates.Bridge;
using Templates.NullObject;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("---- OBJECT POOL -----");
        var stringPool = new ObjectPool<string>(() => "Default");

        
        Console.WriteLine("Obtained objects from the string pool:");
        for (int i = 0; i < 5; i++)
        {
            var str = stringPool.GetObject();
            Console.WriteLine(str);
        }

       
        Console.WriteLine("\nReturned objects to the string pool:");
        for (int i = 0; i < 5; i++)
        {
            var str = "String " + i;
            stringPool.ReturnObject(str);
            Console.WriteLine($"Returned: {str}");
        }

        
        Console.WriteLine("\nObtained objects again from the string pool:");
        for (int i = 0; i < 5; i++)
        {
            var str = stringPool.GetObject();
            Console.WriteLine(str);
        }

        Console.WriteLine("---- BRIDGE -----");

        Client client = new Client();

        Abstraction abstraction;
        
        abstraction = new Abstraction(new ConcreteImplementationA());
        client.ClientCode(abstraction);

        Console.WriteLine();

        abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
        client.ClientCode(abstraction);

        Console.WriteLine("---- NULL OBJECT -----");

        var animals = new[] { "duck", "cat", "unknown" };
        foreach (var name in animals)
        {
            var animal = AnimalFactory.GetAnimal(name);
            Console.WriteLine($"{animal.GetName()} says: {animal.MakeSound()}");
        }

        Console.WriteLine("---- REACTOR -----");

        var reactor = new Reactor();

        
        reactor.RegisterHandler(e => Console.WriteLine($"Handler 1: {e.Message}"));
        reactor.RegisterHandler(e => Console.WriteLine($"Handler 2: {e.Message}"));


        var someEvent = new Event("Sample Event");
        await reactor.HandleEvent(someEvent);

    }
}
