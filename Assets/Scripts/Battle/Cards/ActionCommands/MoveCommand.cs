
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
    // throw new System.NotImplementedException();
    // TODO: tylko tymczasowe rozwiązanie
    if(direction == Direction.LEFT){
      Vector2Int position1 = new Vector2Int(1, 2);
      Vector2Int position2 = new Vector2Int(2,2);
      return new List<Vector2Int>{position1, position2};
    } 
    if(direction == Direction.RIGHT){
      return new List<Vector2Int>{new Vector2Int(4,1)};
    }
    return new List<Vector2Int>();
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