using System;
using MarsRover.Data;

namespace MarsRover
{
  public class Rover : IRover
  {
    private int _x;
    private int _y;
    private readonly int _plateauX;
    private readonly int _plateauY;
    
    // Constructor - Initiate Rover instance with int x, int y, and char direction
    public Rover(int x, int y, char direction, int plateauX, int plateauY)
    {
      _x = x;
      _y = y;
      _plateauX = plateauX;
      _plateauY = plateauY;
      Console.Write("What is your order (e.g. LMLMLMLMM)? ");
      string instruction = Console.ReadLine();
      takeOrder(instruction);
    }

    public void takeOrder(string str)
    {
      Console.WriteLine(str);

    }



    

  }
}
