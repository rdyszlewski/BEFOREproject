using UnityEngine;

public class ActionSelectionController{
  
  private ActionRenderer actionRenderer;
  private CardActionItem _selectedCard;
   public CardActionItem selectedCard{
    get{return _selectedCard;}
  }

  public ActionSelectionController(ActionRenderer actionRenderer){
    this.actionRenderer = actionRenderer;
  }

  public void Update(){
    OnMouseMovement();
  }

  // TODO: identyczna metoda, jak w CardSelectionController. Zrobić coś z tym
  private  void OnMouseMovement(){
    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, LayerMask.GetMask("Card"));
      if(hit){
        GameObject gameObject = hit.collider.gameObject;
        // TODO
        CardActionItem item = gameObject.GetComponent<CardActionItem>();
        if(selectedCard == null || item != selectedCard){
          ResetHoverCard();
          SelectCard(item); // TODO: zaznaczanie karty powinno odbywać się w rendererze
          _selectedCard = item;
        }
      } else {
        ResetHoverCard();
      }
  }

  private void ResetHoverCard(){
      if(_selectedCard != null){
        DeselectCard(selectedCard);
        _selectedCard = null;
      }
    }

    private void SelectCard(CardActionItem item){
      item.ChangeColor(Color.blue);
    }

    private void DeselectCard(CardActionItem item){
      item.ChangeColor(Color.white);
    }


}