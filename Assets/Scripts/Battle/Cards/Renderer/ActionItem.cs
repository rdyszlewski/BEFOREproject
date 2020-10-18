using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem : MonoBehaviour
{
    private CardAction action;
    public CardAction Action{get{return action;}}

    private Vector2Int position;
    public Vector2Int Position{get{return position;}}

    private SpriteRenderer actionRenderer;
    private BoxCollider actionCollider;

    private RectTransform rectTransform;

    public void Initialize(CardAction action, Vector2Int position){
      actionRenderer = GetComponent<SpriteRenderer>();
      actionRenderer.drawMode = SpriteDrawMode.Sliced;
      actionCollider = GetComponent<BoxCollider>();
      rectTransform = GetComponent<RectTransform>();
    }

    public void Resize(Vector2 size){
      Debug.Assert(actionRenderer != null);
      Debug.Assert(actionCollider != null);
      Debug.Assert(rectTransform != null);
      actionRenderer.size = size;
      actionCollider.size = size;
      rectTransform.sizeDelta = size;
    }

    public void ChangeColor(Color color){
      Debug.Assert(actionRenderer != null);
      actionRenderer.color = color;
    }

    public void SetTexture(Texture2D texture){
      Debug.Assert(actionRenderer != null);
      Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
      actionRenderer.sprite = sprite;
    }
}
