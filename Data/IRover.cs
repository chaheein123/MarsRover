using System;
namespace MarsRover.Data
{
  public interface IRover
  {
    public void TakeOrder(string str);
    public void AskForInstruction();
    public bool ValidateInstruction(string instruction);
    public void TurnLeft();
    public void TurnRight();
    public void Move();
    public void LocateRover();
  }
}
