
using System.Collections.Generic;
using UnityEngine;

public class UseCommand : IActionCommand
{
  public void Execute(BattlePlayer player, Board board, Vector2Int position)
  {
    throw new System.NotImplementedException();
  }

  public List<Vector2Int> GetPositions(BattlePlayer player, Board board, Direction direction)
  {
    throw new System.NotImplementedException();
  }

  public bool IsPossible(BattlePlayer player, Board board, Vector2Int position)
  {
    throw new System.NotImplementedException();
  }

  public void Preview(BattlePlayer player, Board board, Vector2Int position)
  {
    throw new System.NotImplementedException();
  }
}