using System;
using MarsRover.Data;

namespace MarsRover.Models
{
  public class Plateau
  {
    private readonly int _x;
    private readonly int _y;

    // Dependency Injection of Rovers into this class to enable interaction between them with less code
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


      // Asks the user whether a rover should be sent on this plateau
      Console.Write("Do you want to create a rover (press any other key) or quit (press q)?");
      char isContinue = Convert.ToChar(Console.ReadLine());

      // While loop is required, in case the user wants to send another rover when the one before comes back
      while (Char.ToLower(isContinue) != 'q')
      {
        Console.Write("What is the x-value of this rover?  ");
        int roverX = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is the y-value of this rover?  ");
        int roverY = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is the direction (N, E, S or W) of this rover?  ");
        char direction = Convert.ToChar(Console.ReadLine());
        // Automatically creates the first plateau as the plateau is instantiated
        _rover = new Rover(roverX, roverY, direction, _x, _y);
      }
      Console.WriteLine("bye!");
      Environment.Exit(0);
    }
  }
}
