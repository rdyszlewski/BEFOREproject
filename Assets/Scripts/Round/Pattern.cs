using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateState();

public class Pattern : MonoBehaviour {
// TODO: zmienić nazwę tego na GameState czy coś takiego
  private int _currentRound = 0;
  private int _currentTurn = 0;
  private int _currentStep = 0;

  private UpdateState updateStateEvent;
  private List<Turn> _turns = new List<Turn> ();

  private PatternGenerator patternGenerator;

  public int currentRound{
    get{return _currentRound;}
  }

  public int currentTurn{
    get{return _currentTurn;}
  }

  public int currentStep{
    get{return _currentStep;}
  }

  public List<Turn> turns {
    get { return _turns; }
  }

  public void SetUpdateStateEvent(UpdateState callback){
    updateStateEvent = callback;
  }

  // Start is called before the first frame update
  void Start () {
    Init ();
  }

  private void Init () {
    patternGenerator = GetComponent<PatternGenerator>();
  }

  // Update is called once per frame
  void Update () {
    TempClick();
  }


  private void TempClick(){
    if(Input.GetMouseButtonDown(0)){
      NextStep();
    }
  }
  public void LoadPattern () {
    // TODO: pomyśleć, gdzie to powinno być wykorzystywane
    if (patternGenerator == null){
      Init();
    }
    _turns = patternGenerator.GeneratePattern();
  }

  private void NextTurn(){
    _currentTurn++;
    _currentStep = 0;
    if(_currentTurn == _turns.Count){
      _currentTurn = 0;
      // TODO: nowe losowanie, kolejna runda
    }
    RunUpdateStateEvent();
  }

  private void NextStep(){
    _currentStep++;
    if(_currentStep == _turns[_currentTurn].GetNumberSteps()){
      // NextTurn();
      NextRound();
      // TODO: tutaj może jakieś odpalenie kolejnej rundy, żeby było wiadomo co ma robić gra
    } else {
      RunUpdateStateEvent();
    }
  }

  public Step GetCurrentStep(){
    return _turns[_currentTurn].GetStep(_currentStep);
  }

  private void RunUpdateStateEvent(){
    if(updateStateEvent != null){
      updateStateEvent();
    }
  }

  private void NextRound(){
    _currentStep = 0;
    _currentRound = 0;
    _turns = patternGenerator.GeneratePattern();
    updateStateEvent();
  }
}