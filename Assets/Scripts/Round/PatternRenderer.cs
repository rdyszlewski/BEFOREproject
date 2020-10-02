using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRenderer : MonoBehaviour {
  // TODO: zrobić opcję zaznaczania 

  [SerializeField]
  private GameObject itemObject;
  
  [SerializeField]
  private Texture2D openAction;

  [SerializeField]
  private Texture2D hiddenAction;

  [SerializeField]
  private Vector3 size;

  [SerializeField]
  private Vector2 itemSize;

  [SerializeField]
  private float breakSpace;

  [SerializeField]
  private Vector2 positionCenter;

  private List<PatternItem> items;

  private Pattern pattern;
  private PatternItem currentItem;


  // Start is called before the first frame update
  void Start () {
    items = new List<PatternItem> ();
    pattern = GetComponent<Pattern>();
    pattern.SetUpdateStateEvent(UpdateState);
    pattern.LoadPattern();
    SetupPattern(pattern.turns);
    Debug.unityLogger.Log(pattern.turns);
  }

  private void UpdateState(){
    Debug.unityLogger.Log("UpdateState");
    if(currentItem != null){
      currentItem.Deselect();
   }
   int turn = pattern.currentTurn;
    int step = pattern.currentStep;
   if(turn == 0 && step == 0){
     SetupPattern(pattern.turns);
   }
    
    PatternItem item = items.Find(x=>x.turn == turn && x.step == step);
    Debug.unityLogger.Log(turn);
    Debug.unityLogger.Log(step);
    if(item != null){
      Debug.unityLogger.Log("Znaleziono item");
      item.Select();
      currentItem = item;
    }
  }

  // Update is called once per frame
  void Update () {
    
  }

  public void SetupPattern (List<Turn> turns) {
    items.Clear ();
    // TODO: zniszczenie wszystkich utworzonych wcześniej obiektóœ
    Debug.Assert (turns != null);
    float width = CalculatePatternsWidth (turns);
    Vector2 startPosition = new Vector2 (positionCenter.x - width/2, positionCenter.y);
    items = CreatePatternItems (turns, startPosition);
    UpdateState();
  }

  private float CalculatePatternsWidth (List<Turn> turns) {
    float sum = 0;
    foreach (Turn turn in turns) {
      sum += turn.GetNumberSteps () * itemSize.x;
      sum += breakSpace;
    }
    return sum;
  }

  private List<PatternItem> CreatePatternItems (List<Turn> turns, Vector2 startPosition) {
    Vector3 currentPosition = new Vector3(startPosition.x, startPosition.y, 1);
    List<PatternItem> itemsResult = new List<PatternItem> ();
    Vector2 scale = new Vector2(itemSize.x, itemSize.y/2);
    for(int turnIndex =0; turnIndex < turns.Count; turnIndex++) {
      Turn turn = turns[turnIndex];
      for (int stepIndex = 0; stepIndex < turn.GetNumberSteps (); stepIndex++) {
        Step step = turn.GetStep(stepIndex);
        PatternItem item = InstantiateItem (currentPosition);
        item.turn = turnIndex;
        item.step = stepIndex;
        item.transform.localScale = scale;
        item.SetupTexture(GetTexture(step.type));
        currentPosition.x += itemSize.x;
        itemsResult.Add(item);
      }
      currentPosition.x += breakSpace;
    }
    return itemsResult;
  }

  private Texture GetTexture(StepType type){
    switch(type){
      case StepType.OPEN:
        return openAction;
      case StepType.HIDDEN:
        return hiddenAction;
    }
    return null;
  }

  private PatternItem InstantiateItem (Vector3 position) {
    GameObject gameObject = Instantiate (itemObject, position, Quaternion.identity, this.transform);
    return gameObject.GetComponent<PatternItem> ();
  }

  void OnDrawGizmos () {
    Gizmos.color = Color.blue;
    Gizmos.DrawWireCube (positionCenter, size);

    Gizmos.color = Color.yellow;
    if(items != null){
      foreach(PatternItem item in items){
        Gizmos.DrawWireCube(item.transform.position, itemSize);
      }
    }
  }
}