
using System.Collections.Generic;
using UnityEngine;

public interface IActionCommand{
  bool IsPossible(BattlePlayer player, Board board, Vector2Int position);

  // TODO: tutaj będzie trzeba chyba zwrócić jakiś informacyjny obiekt
  void Preview(BattlePlayer player, Board board, Vector2Int position);

  void Execute(BattlePlayer player, Board board, Vector2Int position);

  List<Vector2Int> GetPositions(BattlePlayer player, Board board, Direction direction);

}