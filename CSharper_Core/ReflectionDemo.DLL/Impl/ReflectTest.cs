using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo.DLL.Impl
{
public class ReflectTest
{
    private void Show1()
    {
        Console.WriteLine($"Show 1");
    }

    public void Show2()
    {
        Console.WriteLine($"Show 2 name");
    }

    public void Show3(int id)
    {
        Console.WriteLine($"Show 3 id");
    }

    public void Show3(string name)
    {
        Console.WriteLine($"Show 3 name");
    }

    public static void Show4()
    {
        Console.WriteLine($"Show 4");
    }
}
}
