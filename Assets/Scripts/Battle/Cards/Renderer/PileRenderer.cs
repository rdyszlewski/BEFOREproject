using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileRenderer : MonoBehaviour
{
   private CardsPile pile; // TODO: możliwe, że to nie będzie potrzebne
   private List<CardItem> items;
   
   private Vector3 cardSize;

   public void Initialize(Vector3 cardSize){
     this.cardSize = cardSize;
     items = new List<CardItem>();
   }

   public void AddCardItem(CardItem item){
     // TODO: zrobić wyświetlanie w zależnośći od odkrycia karty
     // TODO: przesunąć trochę, aby zawsze była widoczna aktualna karta
     Debug.Log(item);
     item.transform.SetParent(transform);
     RectTransform rectTransform = item.GetComponent<RectTransform>();
     rectTransform.localPosition = new Vector3(0,0,0);
     items.Add(item);
   }

}
