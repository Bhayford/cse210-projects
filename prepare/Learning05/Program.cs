using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of shapes
        Square square = new Square("Red", 4);
        Rectangle rectangle = new Rectangle("Blue", 5, 3);
        Circle circle = new Circle("Green", 2.5);

        // Store shapes in a list
        List<Shape> shapes = new List<Shape> { square, rectangle, circle };

        // Iterate through the list and display the color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}
