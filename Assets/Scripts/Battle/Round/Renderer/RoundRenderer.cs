using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundRenderer : MonoBehaviour {

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

  private IRoundSelection roundSelection;

  private PatternItem patternItem;


  void Start () {

  }

  public void Initialization () {
    itemCreator = GetComponent<ItemCreator> ();
    sizeCorrector = new RoundSizeCorrector();
    roundSelection = GetComponent<ColorSelection>();
    
  }

  public void DrawPattern (Round round) {
    Debug.Assert(itemCreator != null);
    List<TurnItem> turnItems = DrawTurns(round);
    sizeCorrector.Resize(patternContainer, sizes);
    patternItem = new PatternItem(turnItems);
    roundSelection.Initialize(patternItem);
  }

  private List<TurnItem> DrawTurns(Round round){
    List<TurnItem> turnItems = new List<TurnItem>();
    int turnsCount = round.CountTurns();
    for(int turnIndex=0; turnIndex < turnsCount; turnIndex++){
      Turn turn = round.GetTurn(turnIndex);
      TurnItem turnItem = itemCreator.CreateTurnItem(turn, patternContainer.transform);
      turnItems.Add(turnItem);
    }
    return turnItems;
  }

  public void Select (int turn, int step) {
    roundSelection.Select(turn, step);
  }

  public void Deselect (int turn, int step) {
    roundSelection.Deselect(turn ,step);
  }
}