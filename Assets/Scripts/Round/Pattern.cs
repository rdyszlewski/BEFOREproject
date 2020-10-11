using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateState (bool changedPattern);

public class Pattern : MonoBehaviour {
  // TODO: zmienić nazwę tego na GameState czy coś takiego
  private int _currentRound = 0;
  private int _currentTurn = 0;
  private int _currentStep = 0;

  private UpdateState updateStateEvent;
  private List<Turn> _turns = new List<Turn> ();

  private bool _reverse;

  private PatternGenerator patternGenerator;

  public int currentRound {
    get { return _currentRound; }
  }

  public int currentTurn {
    get { return _currentTurn; }
  }

  public int currentStep {
    get { return _currentStep; }
  }

  public List<Turn> turns {
    get { return _turns; }
  }

  public bool reverse{
    get{return _reverse;}
  }

  public void SetUpdateStateEvent (UpdateState callback) {
    updateStateEvent = callback;
  }

  void Start () {
    Init ();
  }

  private void Init () {
    patternGenerator = GetComponent<PatternGenerator> ();
  }

  void Update () { }

  public void LoadPattern () {
    // TODO: pomyśleć, gdzie to powinno być wykorzystywane
    if (patternGenerator == null) {
      Init ();
    }
    _turns = patternGenerator.GeneratePattern ();
  }

  public bool NextTurn () {
    _currentTurn++;
    _currentStep = 0;
    bool endOfRound = _currentTurn == _turns.Count;
    if(!endOfRound){
      RunUpdateStateEvent();
    }
    return endOfRound;
    // if (_currentTurn == _turns.Count) {
    //   // _currentTurn = 0;
    //   NextRound ();
    //   // TODO: nowe losowanie, kolejna runda
    // }
    // RunUpdateStateEvent ();
  }

  public bool NextStep () {
    /// return: is end of turn
    // TODO: po ruchu zmienia się coś.
    _currentStep++;
    bool endOfTurn = _currentStep == _turns[_currentTurn].GetNumberSteps();
    if(!endOfTurn){
      RunUpdateStateEvent();
    }
    return endOfTurn;
  }

  public void ResetStep(){
    _currentStep = 0;
    RunUpdateStateEvent();
  }

  public Step GetCurrentStep () {
    return _turns[_currentTurn].GetStep(_currentStep);
  }

  private void RunUpdateStateEvent () {
    if (updateStateEvent != null) {
      updateStateEvent (false);
    }
  }

  public void NextRound () {
    _currentStep = 0;
    _currentTurn = 0;
    _currentRound++;
    _turns = patternGenerator.GeneratePattern ();
    updateStateEvent (true);
  }
}