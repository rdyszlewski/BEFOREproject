using UnityEngine;

public class CardAction{
  
  private ActionType _type;
  public ActionType type{
    get{return _type;}
    set{_type = value;}
  }

  public void PerformAction(){
    Debug.unityLogger.Log("Wykonywanie akcji");
    // TODO: będzie trzeba dokończyć wykonywanie kolejnych klas Akcji, lub przez tworzenie Samych akcji w oddzielnych klasach
    // TODO: na razie sprawdzimy tylko, czy to działą odpowiednio
  }
}