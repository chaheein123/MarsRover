using System;
using MarsRover.Data;

namespace MarsRover.Models
{
  public class Plateau
  {
    private readonly int _x;
    private readonly int _y;

    // Dependency Injection of Rovers into this Mars plateau to enable interaction between them with less code
    private IRover _rover;

    // Constructor - the user must provide the value for the plateau's x and y value upon its instantiation
    public Plateau()
    {
      Console.Write("Enter max x-value for the plateau: ");
      int x = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter max y-value for the plateau: ");
      int y = Convert.ToInt32(Console.ReadLine());
      _x = x;
      _y = y;
      Console.WriteLine("This plateau has x-axis of {0}, and y-axis of {1}. ", _x, _y);
      Console.WriteLine("Now lets enter the location of our first rover");

      Console.Write("What is the x-value of this rover?  ");
      int roverX = Convert.ToInt32(Console.ReadLine());
      Console.Write("What is the y-value of this rover?  ");
      int roverY = Convert.ToInt32(Console.ReadLine());
      Console.Write("What is the direction (N, E, S or W) of this rover?  ");
      char direction = Convert.ToChar(Console.ReadLine());
      // Automatically creates the first plateau as the plateau is instantiated
      _rover = new Rover(roverX, roverY, direction);
    }


  }
}
