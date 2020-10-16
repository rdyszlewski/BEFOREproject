
using System.Collections.Generic;
using UnityEngine;

public class PatternItem{

  private List<TurnItem> turns;

  public PatternItem(List<TurnItem> turns){
    Debug.Assert(turns != null);
    this.turns = turns;
  }

  public TurnItem GetTurnItem(int index){
    Debug.Assert(index >=0 && index < turns.Count);
    return turns[index];
  }
}