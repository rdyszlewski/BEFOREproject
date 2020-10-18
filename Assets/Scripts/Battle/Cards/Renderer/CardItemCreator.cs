using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItemCreator : MonoBehaviour {
  [SerializeField]
  private Texture2D holeTexture;

  [SerializeField]
  private GameObject cardObject;

  [System.Serializable]
  private class CardItemElement : IElement<CardType> {
    [SerializeField]
    private CardType type;
    public CardType Type { get { return type; } }

    public Texture2D texture;
  }

  [SerializeField]
  private List<CardItemElement> items;

  private ElementsMap<CardType, CardItemElement> itemsMap;

  void Awake () {
    itemsMap = new ElementsMap<CardType, CardItemElement> ();
    itemsMap.Initialize (items);
    Debug.Assert(itemsMap.GetSize()==Enum.GetValues(typeof(CardType)).Length);
  }

  public CardItem CreateItem (Card card, Transform parent, Vector2 cardSize) {
    Debug.Assert (cardObject != null);
    GameObject createdCard = Instantiate (cardObject, parent);
    CardItem item = createdCard.GetComponent<CardItem> ();
    item.Initialize ();
    item.Card = card;
    Texture2D texture = itemsMap.GetElement(card.Type).texture;
    item.HoleTexture = holeTexture;
    item.SetTexture (texture);
    item.Resize (cardSize);
    return item;
  }

  
}