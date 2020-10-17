using UnityEngine;

public class SelectionController {

  private readonly float rayDistance = 20;
  private ICardSelection selection;

  private ChooseCardCommand cardCommand;

  private GameObject currentObject;
  private CardItem selectedCard;


  public SelectionController (ICardSelection selection, ChooseCardCommand command) {
    this.selection = selection;
    this.cardCommand = command;
  }

  public void Update () {
    // TODO: zaznaczanie karty  
    OnMouseMovement();
    if(Input.GetMouseButtonDown(0) && IsCardSelected()){
      cardCommand.Execute(selectedCard.Card);
    }
  }

  private void OnMouseMovement () {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if(Physics.Raycast(ray, out hit, rayDistance, LayerMask.GetMask("Card"))){
      GameObject gameObject = hit.collider.gameObject;
      if(currentObject ==null || !gameObject != currentObject){
        DeselectSelectedCard();;
        CardItem item = gameObject.GetComponent<CardItem>();
        SelectCard(item);
      }
    } else {
      DeselectSelectedCard();
    }
  }

  private void ResetHoverCard () {
    if (selectedCard != null) {
      DeselectSelectedCard ();
      selectedCard = null;
    }
  }

  private void SelectCard (CardItem item) {
    selectedCard = item;
    selection.Select(item);
    currentObject = item.gameObject;
  }

  private void DeselectSelectedCard () {
    if(selectedCard!= null){
      selection.Deselect(selectedCard);
    }
  }

  public bool IsCardSelected(){
    return selectedCard != null;
  }

  // TODO: zastosować tutaj stragegię wyboru: za pomocą myszy, za pomocą klawaitury, za pomocą pada

}