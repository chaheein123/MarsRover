using System;
namespace MarsRover.Data
{
  public interface IRover
  {
    public void TakeOrder(string str);
    public void AskForInstruction();
    public bool ValidateInstruction(string instruction);
  }
}
