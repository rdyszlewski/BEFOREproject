using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour {
  [System.Serializable]
  public class CardElement {
    public CardType type;
    // TODO: pomyśleć dokładnie, czy na pewno to ma przebiegać w tę stronę
    public Card card;
    public Texture texture;
  }

  [SerializeField]
  private List<CardElement> cards;

  [SerializeField]
  private GameObject cardItemObject;

  private Dictionary<CardType, CardElement> cardsMap;

  void Awake () {
    cardsMap = new Dictionary<CardType, CardElement> ();
    foreach (CardElement element in cards) {
      element.card = new Card();
      element.card.type = element.type;
      cardsMap.Add (element.type, element);
    }
  }

  public Card GetCard (CardType type) {
    if (cardsMap.ContainsKey (type)) {
      CardElement element = cardsMap[type];
      return element.card;
      // Card card =  cardsMap.card;
      // card.type = type;

    }
    return null;
  }

  public Texture GetCardItemTexture(CardType type){
    if(cardsMap.ContainsKey(type)){
      return cardsMap[type].texture;
    }
    return null;
  }

  public CardItem CreateCardItem(CardType type, Transform parent, Vector3 size){
    GameObject gameObject = Instantiate(cardItemObject, transform.position, Quaternion.identity, parent);
    CardItem item = gameObject.GetComponent<CardItem>();
    Card card = GetCard(type);
    item.card = card;
    item.size = size;
    Texture texture = GetCardItemTexture(type);
    item.SetupTexture(texture);
    return item;
  }
}