using Assets.Scripts.Battle.Board;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    //private BoxCollider2D collider;
    private BoxCollider collider;

    private IElementInfo element;
    public IElementInfo Element { get => element; set => element = value; }

    public void Initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //collider = GetComponent<BoxCollider2D>();
        collider = GetComponent<BoxCollider>();
    }

    public void Resize(Vector3 newSize)
    {
        Debug.Assert(spriteRenderer != null);
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = newSize;
        transform.localScale = new Vector3(1, 1, 1);

        // TODO: może jakoś z tym są problemy
        collider.size = newSize;
    }

    // TODO: później można to trochę przerobić
    public void SetLayer(int layerNumber)
    {
        Debug.Assert(spriteRenderer != null);
        spriteRenderer.sortingOrder = layerNumber;
    }

    public void SetTexture(Texture2D texture)
    {
        Debug.Assert(texture != null);
        Sprite sprite = Sprite.Create((Texture2D)texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
        SetSprite(sprite);
    }

    public void SetSprite(Sprite sprite)
    {
        Debug.Assert(spriteRenderer != null);
        spriteRenderer.sprite = sprite;
    }

    public void ChangeColor(Color color)
    {
        Debug.Assert(spriteRenderer != null);
        spriteRenderer.color = color;
    }

    // TODO: może konieczne będzie, aby Cell zawierało informacje o pozycji elementu na planszy
}
