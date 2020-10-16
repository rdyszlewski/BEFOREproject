using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepItem : MonoBehaviour
{
  // TODO: klasa jest dość podobna od wyświetlania planszy. Może da się wyodrębnić cześć wspólną
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;
    private RectTransform rectTransfrom;
    
    // TODO: powinien być tutaj jakiś obiekt info, żeby można było czytać podpowiedzi i informacje

    public void Initialize(){
      rectTransfrom = GetComponent<RectTransform>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      collider = GetComponent<BoxCollider2D>();
    }

    public void SetLayer(int layerNumber){
      Debug.Assert(spriteRenderer != null);
      spriteRenderer.sortingOrder = layerNumber;
    }

    public void SetTexture(Texture2D texture){
      Debug.Assert(texture != null);
      Debug.Assert(spriteRenderer != null);
      Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
      spriteRenderer.sprite = sprite;
    }

    public void ChangeColor(Color color){
      Debug.Assert(spriteRenderer != null);
      spriteRenderer.color = color;
    }
}
