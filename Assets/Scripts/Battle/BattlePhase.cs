using System.Collections.Generic;
using UnityEngine;

public abstract class BattlePhase : MonoBehaviour {

  private bool _active = false;

  // TODO: czy pomysł z takim przekazywaniem daty będzie odpowiedni?
  private PhaseInitData _data;

  protected PhaseInitData data {
    get { return _data; }
  }

  public abstract void DoAction ();

  public bool IsActive () {
    return _active;
  }

  public void Run () {
    _active = true;
    OnStart ();
  }
  protected abstract void OnStart ();

  protected void FinishPhase () {
    OnFinishPhase();
    this._active = false;
  }

  protected abstract void OnFinishPhase(); // TODO: dobrze się nad tym zastanowić

  public void InitPhase (PhaseInitData data) {
    _data = data;
    // TODO: to prawdopodobnie będzie wyglądało inaczej
  }
}