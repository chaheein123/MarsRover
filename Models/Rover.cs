using System;
using System.Collections.Generic;
using MarsRover.Data;

namespace MarsRover
{
  public class Rover : IRover
  {
    // The projected values refer to what the value will be after each instruction. It will be reset to the original values whenever the user inputs invalid instruction 
    private int _x;
    private int _projectedX;
    private int _y;
    private int _projectedY;
    private char _direction;
    private char _projectedDirection;

    private readonly int _plateauX;
    private readonly int _plateauY;

    // Dictionary to look up the direction to be changed when the Rover moves left
    private Dictionary<char, char> LeftDirectionIndex = new Dictionary<char, char>()
    {
      { 'N', 'W' },
      { 'S', 'E' },
      { 'W', 'S' },
      { 'E', 'N' },
    };

    // Dictionary to look up the direction to be changed when the Rover moves right
    private Dictionary<char, char> RightDirectionIndex = new Dictionary<char, char>()
    {
      { 'N', 'E' },
      { 'S', 'W' },
      { 'W', 'N' },
      { 'E', 'S' },
    };

    // Constructor
    public Rover(int plateauX, int plateauY)
    {
      _plateauX = plateauX;
      _plateauY = plateauY;

      LocateRover();

      // Once all of the variables needed are declared, we ask for instruction from the user to execute
      AskForInstruction();
    }

    // Intial location of the rover
    public void LocateRover()
    {
      Console.Write("What is the x-value of this rover?  ");
      _x = Convert.ToInt32(Console.ReadLine());
      // The while loop makes sure when the user inputs the values for Rover's location, it is within the plauteau's limit bounds
      while (_x > _plateauX)
      {
        Console.Write("Your x-value of the rover is out of the bound. Please re-enter x-axis value: ");
        _x = Convert.ToInt32(Console.ReadLine());
      }

      Console.Write("What is the y-value of this rover?  ");
      _y = Convert.ToInt32(Console.ReadLine());
      while (_y > _plateauY)
      {
        Console.Write("Your y-value of the rover is out of the bound. Please re-enter y-axis value: ");
        _y = Convert.ToInt32(Console.ReadLine());
      }

      Console.Write("What is the direction (N, E, S or W) of this rover?  ");
      _direction = Char.ToUpper(Convert.ToChar(Console.ReadLine()));
    }

    // Asks for rover instruction from the user
    public void AskForInstruction()
    {
      _projectedX = _x;
      _projectedY = _y;
      _projectedDirection = _direction;
      Console.Write("Your current rover is at x: {0}, y: {1}, and it is facing {2}. What is your instruction? ", _x, _y, _direction);
      string instruction = Console.ReadLine();
      if (!ValidateInstruction(instruction))
      {
        Console.WriteLine("WARNING: The order only takes L, R, or M characters. i.e: LRMRRMLRMLRM. Enter again");

        // Keeps asking for instruction until the instruction is valid, which means it only contains letters, L, R or M.
        AskForInstruction();
      }
      else TakeOrder(instruction);
    }

    // This method processes the order in string
    public void TakeOrder(string instruction)
    {
      Console.WriteLine("The Rover is executing your order... Please be patient...");

      foreach (var character in instruction)
      {
        if (Char.ToUpper(character) == 'M')
        {
          // if the rover is out of bounds, Move() will return false. In that case, ask for instruction again
          if (!Move())
          {
            AskForInstruction();
            return;
          }
        }
        else if (Char.ToUpper(character) == 'L')
        {
          TurnLeft();
        }
        else if (Char.ToUpper(character) == 'R')
        {
          TurnRight();
        }
      }
      Console.WriteLine("🚀🚀🚀 Congrats. Your rover landed on: {0} {1} {2}. Next rover is getting ready...", _projectedX, _projectedY, _projectedDirection);
    }

    public void TurnLeft()
    {
      _projectedDirection = LeftDirectionIndex[_projectedDirection];
    }

    public void TurnRight()
    {
      _projectedDirection = RightDirectionIndex[_projectedDirection];
    }

    public bool Move()
    {
      if (_projectedDirection == 'N')
      {
        if (++_projectedY > _plateauY)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the NORTH direction. Please give instruction that will keep the rovers within range. Re-enter. ");
          return false;
        }

      }
      else if (_projectedDirection == 'S')
      {
        if (--_projectedY < 0)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the SOUTH direction. Please give instruction that will keep the rovers withinrange. Re-enter. ");
          return false;
        }
      }
      else if (_projectedDirection == 'W')
      {
        if (--_projectedX < 0)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the WEST direction. Please give instruction that will keep the rovers within range. Re-enter. ");
          return false;
        }
      }
      else if (_projectedDirection == 'E')
      {
        if (++_projectedX > _plateauX)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the EAST direction. Please give instruction that will keep the rovers within range. Re-enter. ");
          return false;
        }
      }
      return true;
    }

    // Makes sure that the instruction passed in the takeOrder argument is valid, and does not contain any other characters, except L, M, and R.
    public bool ValidateInstruction(string instruction)
    {
      HashSet<char> orderSet = new HashSet<char> { 'L', 'M', 'R' };

      foreach (var character in instruction)
      {
        if (!orderSet.Contains(Char.ToUpper(character))) return false;
      }
      return true;
    }
  }
}
