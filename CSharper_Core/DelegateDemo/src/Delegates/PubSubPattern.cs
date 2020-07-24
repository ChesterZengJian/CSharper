using System;

namespace DelegateDemo.Delegates
{
public class Fishermen
{
    public void PullHook()
    {
        Console.WriteLine("Pull hook");
    }
}

public class Fish
{
    public Action Action { get; set; }
    public void Eat()
    {
        Action?.Invoke();
    }
}

public class FishFloat
{
    public void Move()
    {
        Console.WriteLine("Move Fish Float");
    }
}
}