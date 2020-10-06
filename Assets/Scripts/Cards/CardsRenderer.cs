using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsRenderer : MonoBehaviour
{

  [SerializeField]
  private Vector3 size;

  [SerializeField]
  private Vector2 positionCenter;

  [SerializeField]
  private Vector3 itemSize;
  
  [SerializeField]
  private float breakSize;

  [SerializeField]
  private GameObject cardItemObject;

  private Hand hand;
  private CardFactory cardsFactory;

  private List<CardItem> items;

  private CardItem hoverCard;
    void Start()
    {
      items = new List<CardItem>();        
      hand = GetComponent<Hand>();
      InitCardsFactory();
      hand.SetUpdateEvent(DrawCards);
      DrawCards(true);
    }

    private void InitCardsFactory(){
      GameObject gameObject = GameObject.FindGameObjectWithTag("CardsFactory");
      cardsFactory = gameObject.GetComponent<CardFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseMovement();
        OnMouseClick();
    }

    private void OnMouseMovement(){
      RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, LayerMask.GetMask("Card"));
      if(hit){
        GameObject gameObject = hit.collider.gameObject;
        CardItem item = gameObject.GetComponent<CardItem>();
        if(hoverCard == null || item != hoverCard){
          ResetHoverCard();
          SelectCard(item);
          hoverCard = item;
        }
      } else {
        ResetHoverCard();
      }
    }

    private void OnMouseClick(){
      if(Input.GetMouseButtonDown(0) && hoverCard != null){
        // TODO: tutaj powinno być jeszcze jakieś usuwanie tego 
        hand.ChooseCard(hoverCard.card);
        // TODO: to usuwanie powinno być w innym miejscu
        hand.RemoveCard(hoverCard.card);

        items.Remove(hoverCard);
        hoverCard = null;
      }
    }

    private void ResetHoverCard(){
      if(hoverCard != null){
        DeselectCard(hoverCard);
        hoverCard = null;
      }
    }

    private void SelectCard(CardItem item){
      item.ChangeColor(Color.blue);
    }

    private void DeselectCard(CardItem item){
      item.ChangeColor(Color.white);
    }

    public void DrawCards(bool createNew){
      // TODO: tutaj chyba nie za każdym razem będzie tworzenie nowych kart. Czsami po prostu będzie aktualizacja
      List<Card> cards = hand.cards;
      Debug.unityLogger.Log("DrawCards");
      Debug.unityLogger.Log(cards);
      if(createNew){
        DestroyAllCards();
        CreateCardsItems(cards);
      }
    }

    private void DestroyAllCards(){
      for(int i =0; i< this.transform.childCount; i++){
        Destroy(transform.GetChild(i).gameObject);
      }
    }

    private void CreateCardsItems(List<Card> cards){
      // TODO: obliczyć rozmiary wszystkich elementów
      if(cards == null){
        return;
      }
      Vector3 currentPosition = new Vector3(positionCenter.x - cards.Count/2 * itemSize.x + itemSize.x/2, positionCenter.y, 1);
      foreach(Card card in cards){
        GameObject itemObject = Instantiate(cardItemObject, currentPosition, Quaternion.identity, transform);
        Debug.unityLogger.Log(itemSize);
        // itemObject.transform.localScale = itemSize;
        CardItem item = itemObject.GetComponent<CardItem>();
        item.size = itemSize;
        item.card = card;
        item.SetupTexture(cardsFactory.GetCardItemTexture(card.type));
        currentPosition.x = currentPosition.x + itemSize.x + breakSize;
        items.Add(item);
      }
    }

    void OnDrawGizmos(){
      Gizmos.color = Color.green;
      Gizmos.DrawWireCube(positionCenter, size);

      Gizmos.color = Color.blue;
      Gizmos.DrawWireCube(positionCenter, itemSize);

      Gizmos.color = Color.black;
      Vector3 lineBegin = new Vector3(positionCenter.x + itemSize.x/2, positionCenter.y, 1);
      Vector3 lineEnd = new Vector3(lineBegin.x + breakSize, lineBegin.y, lineBegin.z);
      Gizmos.DrawLine(lineBegin, lineEnd);
    }
}
