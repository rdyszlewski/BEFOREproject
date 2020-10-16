using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundRenderer : MonoBehaviour {

  // TODO: z romiarów zrobić klasę, która później może być przekazywana innym elementom

  [System.Serializable]
  public class PatternSizes{
    public Vector2 itemSize;
    public float turnSpacing;
    public float stepsSpacing;
  }

  [SerializeField]
  private PatternSizes sizes;

  [SerializeField]
  private GameObject patternContainer;
  private ItemCreator itemCreator;
  private RoundSizeCorrector sizeCorrector;

  void Start () {

  }

  public void Initialization () {
    itemCreator = GetComponent<ItemCreator> ();
    sizeCorrector = new RoundSizeCorrector();
  }

  public void DrawPattern (Round round) {
    Debug.Assert(itemCreator != null);
    int turnsNumber = round.CountTurns();
    for(int turnIndex=0; turnIndex < turnsNumber; turnIndex++){
      // TODO: wymyślić to w jakiś inny sposób
      Turn turn = round.GetTurn(turnIndex);
      itemCreator.CreateTurnItem(turn, patternContainer.transform);
    }
    sizeCorrector.Resize(patternContainer, sizes);
  }

  // private void SetParentSpacing(){
  //   // TODO: możliwe, żę będzie można utworzyć jedną klasę, która będzie odpowiednio ustawiała rozmiary elementów. To jest chyba dobry pomysł
  //   // TODO: być może to będzie można przenieść w jakieś inne miejsce
  //   Transform patternTransform = transform.Find("Pattern");
  //   HorizontalLayoutGroup layout = patternTransform.GetComponent<HorizontalLayoutGroup>();
  //   layout.spacing = turnSpacing;
  // }

  public void Select (int turn, int step) {

  }

  private void Deselect () {

  }
}