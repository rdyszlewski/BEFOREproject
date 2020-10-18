
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : IActionCommand
{
  public void Execute(EntityPlayer player, Board board, Vector2Int position)
  {
    throw new System.NotImplementedException();
  }

  public List<Vector2Int> GetPositions(EntityPlayer player, Board board, Direction direction)
  {
    throw new System.NotImplementedException();
  }

  public bool IsPossible(EntityPlayer player, Board board, Vector2Int position)
  {
    throw new System.NotImplementedException();
  }

  public void Preview(EntityPlayer player, Board board, Vector2Int position)
  {
    throw new System.NotImplementedException();
  }
}