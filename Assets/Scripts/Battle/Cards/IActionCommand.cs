
public interface IActionCommand{
  bool IsPossible(BattlePlayer player, Board board);

  // TODO: tutaj będzie trzeba chyba zwrócić jakiś informacyjny obiekt
  void Preview(BattlePlayer player, Board board);

  void Perform(BattlePlayer player, Board board);

}