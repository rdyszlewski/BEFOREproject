using System.Collections.Generic;
using UnityEngine;

public abstract class BattlePhase: MonoBehaviour {

  private bool _active = false;

    private List<BattlePlayer> _players;

    protected List<BattlePlayer> players{
      get{return _players;}
    }
    public abstract void DoAction();

    public bool IsActive(){
      return _active;
    }

    public void Run(){
      OnStart();
      _active = true;
    }
    protected abstract void OnStart();

    protected void FinishPhase(){
      this._active = false;
    }

    public void SetPlayers(List<BattlePlayer> players){
      _players = players;
    }
}