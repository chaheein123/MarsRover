using System;
using System.Collections.Generic;
using MarsRover.Data;

namespace MarsRover
{
  public class Rover : IRover
  {
    private int _x;
    private int _y;
    private char _direction;
    private readonly int _plateauX;
    private readonly int _plateauY;
    
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
      _direction = Convert.ToChar(Console.ReadLine());

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


    public void TakeOrder(string instruction)
    {
      Console.WriteLine("🚀🚀🚀 The Rover is executing your order... Please be patient");




      foreach (var character in instruction)
      {

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
