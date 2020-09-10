using System;
using MarsRover.Data;

namespace MarsRover.Models
{
  public class Plateau
  {
    private readonly int _plateauX;
    private readonly int _plateauY;

    // Dependency Injection of Rover into Plateau
    private IRover _rover;

    // Constructor
    public Plateau()
    {
      // User needs to input the max x-axis value and y-axis value of the plateau before sending any rover
      Console.Write("Enter max x-axis value (positive integer) for the plateau: ");
      _plateauX = Convert.ToInt32(Console.ReadLine());
      Console.Write("Enter max y-axis value (positive integer) for the plateau: ");
      _plateauY = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("This plateau has x-axis of {0}, and y-axis of {1}. ", _plateauX, _plateauY);

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

        // Create a new rover
        _rover = new Rover(_plateauX, _plateauY);
      }
    }
  }
}
