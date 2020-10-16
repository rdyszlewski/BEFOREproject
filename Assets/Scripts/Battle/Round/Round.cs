
using System.Collections.Generic;
using UnityEngine;

public class Round{

  private List<Turn> turns;

  public Round(List<Turn> turns){
    Debug.Assert(turns != null && turns.Count != 0);
    this.turns = turns;
  }

  public int CountTurns(){
    return turns.Count;
  }

  public Turn GetTurn(int turnNumber){
    if(IsCorrectTurn(turnNumber)){
      return turns[turnNumber];
    }
    return null;
  }

  private bool IsCorrectTurn(int index){
    return index >= 0 && index < turns.Count;
  }
}