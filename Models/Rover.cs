using System;
using System.Collections.Generic;
using MarsRover.Data;

namespace MarsRover
{
  public class Rover : IRover
  {
    // _x and _y is the x and y values that the user input. These values should never change. Need these variables in case user gives bad instruction and needs to reset the rover's original x and y values
    private readonly int _x;
    private int _projectedX;
    private readonly int _y;
    private int _projectedY;
    private char _direction;
    private char _projectedDirection;

    private readonly int _plateauX;
    private readonly int _plateauY;

    private Dictionary<char, char> LeftDirectionIndex = new Dictionary<char, char>()
    {
      { 'N', 'W' },
      { 'S', 'E' },
      { 'W', 'S' },
      { 'E', 'N' },
    };

    private Dictionary<char, char> RightDirectionIndex = new Dictionary<char, char>()
    {
      { 'N', 'E' },
      { 'S', 'W' },
      { 'W', 'N' },
      { 'E', 'S' },
    };

    // Constructor - Initiate the Rover instance with plateauX and plateauY values. The user has to input the current x, y, and the direction of the rover everytime it gets created.
    public Rover(int plateauX, int plateauY)
    {
      _plateauX = plateauX;
      _plateauY = plateauY;

      Console.Write("What is the x-value of this rover?  ");
      _x = Convert.ToInt32(Console.ReadLine());
      Console.Write("What is the y-value of this rover?  ");
      _y = Convert.ToInt32(Console.ReadLine());
      Console.Write("What is the direction (N, E, S or W) of this rover?  ");
      _direction = Char.ToUpper(Convert.ToChar(Console.ReadLine()));


      // Once all of the variables needed are declared, we ask for instruction from the user to execute
      AskForInstruction();
    }

    public void AskForInstruction()
    {
      Console.Write("Your current rover is at x: {0}, y: {1}, and it is facing {2}. What is your instruction? ", _x, _y, _direction);
      string instruction = Console.ReadLine();
      if (!ValidateInstruction(instruction)) {
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
      _projectedX = _x;
      _projectedY = _y;
      _projectedDirection = _direction;

      foreach (var character in instruction)
      {
        if (Char.ToUpper(character) == 'M')
        {
          Move();
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
      return;
    }

    public void TurnLeft()
    {
      _projectedDirection = LeftDirectionIndex[_projectedDirection];
    }

    public void TurnRight()
    {
      _projectedDirection = RightDirectionIndex[_projectedDirection];
    }

    public void Move()
    {
      if (_projectedDirection == 'N')
      {
        if (++_projectedY > _plateauY)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the NORTH direction. Please give instruction that will keep the rovers within range. Re-enter. ");
          AskForInstruction();
        }

      }
      else if (_projectedDirection == 'S')
      {
        if (--_projectedY < 0)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the SOUTH direction. Please give instruction that will keep the rovers withinrange. Re-enter. ");
          AskForInstruction();
        }
      }
      else if (_projectedDirection == 'W')
      {
        if (--_projectedX < 0)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the WEST direction. Please give instruction that will keep the rovers within range. Re-enter. ");
          AskForInstruction();
        }
      }
      else if (_projectedDirection == 'E')
      {
        if (++_projectedX > _plateauX)
        {
          Console.WriteLine("WARNING: Your instruction will let the rover fly out of the plateau in the EAST direction. Please give instruction that will keep the rovers within range. Re-enter. ");
          AskForInstruction();
        }
      }
    }

    // Makes sure that the instruction passed in the takeOrder argument is valid, and does not contain any other characters, except L, M, and R.
    public bool ValidateInstruction(string instruction)
    {
      HashSet<char> orderSet = new HashSet<char> { 'L', 'M', 'R'};
      foreach (var character in instruction)
      {
        if (!orderSet.Contains(Char.ToUpper(character))) return false;
      }
      return true;
    }
  }
}
