using System;
using MarsRover.Data;

namespace MarsRover.Models
{
  public class Plateau
  {
    private readonly int _x;
    private readonly int _y;

    // Put dependency injection of 'Rovers' into this class to enable interaction between them with less code
    private IRover _rover;

    // Constructor
    public Plateau()
    {
      Console.Write("Enter max x-value for the plateau: ");
      _x = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter max y-value for the plateau: ");
      _y = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("This plateau has x-axis of {0}, and y-axis of {1}. ", _x, _y);

      // While loop is required so that we can keep sending another rover when it comes back.
      while (true)
      {
        // Asks the user whether a rover should be sent on this plateau
        Console.Write("Do you want to send a rover or no. Press 'q' to quit, or any other key to continue: ");
        char isContinue = Convert.ToChar(Console.ReadLine());

        // If the input is q, we break out of the loop and the program ends. Otherwise, keep going, and create another new rover
        if (Char.ToLower(isContinue) == 'q')
        {
          Console.WriteLine("bye!");
          break;
        }

        // Use these user inputs to instantiate another rover
        Console.Write("What is the x-value of this rover?  ");
        int roverX = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is the y-value of this rover?  ");
        int roverY = Convert.ToInt32(Console.ReadLine());
        Console.Write("What is the direction (N, E, S or W) of this rover?  ");
        char direction = Convert.ToChar(Console.ReadLine());

        // roverX => current x-value of the rover
        // roverY => current y-value of the rover
        // direction => direction of the rover (N, E, S, or W)
        // _x => max x value for the plateau
        // _y => max y value for the plateau
        _rover = new Rover(roverX, roverY, direction, _x, _y);
      }
    }
  }
}
