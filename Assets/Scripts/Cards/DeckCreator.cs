using System;
using System.Collections.Generic;

public class DeckCreator{

// TODO: jeżeli klasa będzie wykorzystywana, to ją odpowiednio przerobić
  private static CardType[] types = {CardType.MOVE_VERTICAL, CardType.MOVE_HORIZONTAL};

  public static List<Card> CreateRandomCards(int numberCards, CardFactory factory){
    List<Card> result = new List<Card>();
    var random = new Random();
    while(result.Count != numberCards){
      int index = random.Next(types.Length);
      Card card = factory.GetCard(types[index]);
      result.Add(card);
    }
    return result;
  }
}