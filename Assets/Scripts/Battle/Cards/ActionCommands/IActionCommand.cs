
using System.Collections.Generic;
using UnityEngine;

public interface IActionCommand{
  bool IsPossible(EntityPlayer player, Board board, Vector2Int position);

  // TODO: tutaj będzie trzeba chyba zwrócić jakiś informacyjny obiekt
  void Preview(EntityPlayer player, Board board, Vector2Int position);

  void Execute(EntityPlayer player, Board board, Vector2Int position);

  List<Vector2Int> GetPositions(EntityPlayer player, Board board, Direction direction);

}