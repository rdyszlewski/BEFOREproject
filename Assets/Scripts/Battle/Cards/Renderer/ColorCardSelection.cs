using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCardSelection : MonoBehaviour, ICardSelection
{

  [SerializeField]
  private Color selectionColor;

  private readonly Color defaultColor = Color.white;
  

  public void Select(CardItem item)
  {
    item.ChangeColor(selectionColor);
  }
  public void Deselect(CardItem item)
  {
    item.ChangeColor(defaultColor);
  }
}
