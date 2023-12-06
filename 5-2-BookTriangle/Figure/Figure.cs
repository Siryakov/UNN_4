using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_2_BookTriangle.Figure
{
    public abstract class Figure
{
    private string name;

    
    protected Figure(string name)
    {
        this.name = name;
    }

    
    public string Name
    {
        get { return name; }
    }

    
    public abstract double Area2 { get; }

    
    public abstract double Area();

    
    public virtual void Print()
    {
        Console.WriteLine($"Figure: {Name}");
    }
}
}
