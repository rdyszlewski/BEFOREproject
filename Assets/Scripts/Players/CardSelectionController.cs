using UnityEngine;

public class CardSelectionController{

  private CardsRenderer cardRenderer;
  private CardItem _selectedCard;
  public CardItem selectedCard{
    get{return _selectedCard;}
  }

  public CardSelectionController(CardsRenderer rednerer){
    this.cardRenderer = rednerer;
  }

  public void Update(){
    OnMouseMovement();
  }

  private  void OnMouseMovement(){
    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, LayerMask.GetMask("Card"));
      if(hit){
        GameObject gameObject = hit.collider.gameObject;
        CardItem item = gameObject.GetComponent<CardItem>();
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

    private void SelectCard(CardItem item){
      item.ChangeColor(Color.blue);
    }

    private void DeselectCard(CardItem item){
      item.ChangeColor(Color.white);
    }
}