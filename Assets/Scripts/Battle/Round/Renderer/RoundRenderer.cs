using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundRenderer : MonoBehaviour {

  // TODO: z romiarów zrobić klasę, która później może być przekazywana innym elementom

  [SerializeField]
  private Vector2 itemSize;

  [SerializeField]
  private float turnSpacing;

  [SerializeField]
  private float stepsSpacing;

  [SerializeField]
  private GameObject patternContainer;
  private ItemCreator itemCreator;

  void Start () {

  }

  public void Initialization () {
    itemCreator = GetComponent<ItemCreator> ();
  }

  public void DrawPattern (Round round) {
    Debug.Assert(itemCreator != null);
    int turnsNumber = round.CountTurns();
    for(int turnIndex=0; turnIndex < turnsNumber; turnIndex++){
      Turn turn = round.GetTurn(turnIndex);
      itemCreator.CreateTurnItem(turn, itemSize, patternContainer.transform);
    }
   
  }

  private void SetParentSpacing(){
    // TODO: możliwe, żę będzie można utworzyć jedną klasę, która będzie odpowiednio ustawiała rozmiary elementów. To jest chyba dobry pomysł
    // TODO: być może to będzie można przenieść w jakieś inne miejsce
    Transform patternTransform = transform.Find("Pattern");
    HorizontalLayoutGroup layout = patternTransform.GetComponent<HorizontalLayoutGroup>();
    layout.spacing = turnSpacing;
  }

  public void Select (int turn, int step) {

  }

  private void Deselect () {

  }
}