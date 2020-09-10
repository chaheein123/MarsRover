using System;
using MarsRover.Data;

namespace MarsRover
{
  public class Rover : IRover
  {
    // Constructor - Initiate Rover instance with int x, int y, and char direction
    public Rover(int x, int y, char direction)
    {
      Console.WriteLine("{0} {1} {2}", x, y, direction);

    }

    

  }
}
