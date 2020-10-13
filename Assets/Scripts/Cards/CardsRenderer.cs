using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsRenderer : MonoBehaviour {

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
  void Start () {

  }

  public void Init () {
    items = new List<CardItem> ();
    hand = GetComponent<Hand> ();
    InitCardsFactory ();
    hand.SetUpdateEvent (DrawCards);
    // DrawCards(true);
  }

  private void InitCardsFactory () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("CardsFactory");
    cardsFactory = gameObject.GetComponent<CardFactory> ();
  }

  public void SetHand (Hand hand) {
    this.hand = hand;
    hand.SetUpdateEvent (DrawCards);
    DrawCards (true);
    // TODO: sprawdzić, czy to będzie ok
  }

  // TODO: trzeba to poprzeglądać i poprawić
  public void UpdateHand () {
    DrawCards (true); // TODO: to chyba powinno być trochę inaczej
  }

  public void DrawCards (bool createNew) {
    // TODO: tutaj chyba nie za każdym razem będzie tworzenie nowych kart. Czsami po prostu będzie aktualizacja
    List<Card> cards = hand.cards;
    if (createNew) {
      DestroyAllCards ();
      CreateCardsItems (cards);
    }
  }

  public void DestroyAllCards () {
    for (int i = 0; i < this.transform.childCount; i++) {
      Destroy (transform.GetChild (i).gameObject);
    }
  }

  private void CreateCardsItems (List<Card> cards) {
    // TODO: obliczyć rozmiary wszystkich elementów
    if (cards == null) {
      return;
    }
    Vector3 currentPosition = new Vector3 (positionCenter.x - cards.Count / 2 * itemSize.x + itemSize.x / 2, positionCenter.y, 1);
    foreach (Card card in cards) {
      GameObject itemObject = Instantiate (cardItemObject, currentPosition, Quaternion.identity, transform);
      Debug.unityLogger.Log (itemSize);
      // itemObject.transform.localScale = itemSize;
      CardItem item = itemObject.GetComponent<CardItem> ();
      item.size = itemSize;
      item.card = card;
      item.SetupTexture (cardsFactory.GetCardItemTexture (card.type));
      currentPosition.x = currentPosition.x + itemSize.x + breakSize;
      items.Add (item);
    }
  }

  void OnDrawGizmos () {
    Gizmos.color = Color.green;
    Gizmos.DrawWireCube (positionCenter, size);

    Gizmos.color = Color.blue;
    Gizmos.DrawWireCube (positionCenter, itemSize);

    Gizmos.color = Color.black;
    Vector3 lineBegin = new Vector3 (positionCenter.x + itemSize.x / 2, positionCenter.y, 1);
    Vector3 lineEnd = new Vector3 (lineBegin.x + breakSize, lineBegin.y, lineBegin.z);
    Gizmos.DrawLine (lineBegin, lineEnd);
  }
}