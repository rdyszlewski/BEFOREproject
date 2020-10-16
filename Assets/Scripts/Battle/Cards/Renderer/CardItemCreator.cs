using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItemCreator : MonoBehaviour
{
    [SerializeField]
    private Texture2D tempTexture;

    [SerializeField]
    private GameObject cardObject;

    public CardItem CreateItem(Card card, Transform parent, Vector2 cardSize){
      // TODO: tworzenie elementu
      Debug.Assert(cardObject != null);
      GameObject createdCard = Instantiate(cardObject, parent);
      CardItem item = createdCard.GetComponent<CardItem>();
      item.Initialize();
      item.Card = card;
      item.SetTexture(tempTexture); // TODO: później zastapić to odpowiedniem wyborem tekstury
      item.Resize(cardSize);
      return item;
    }
}
