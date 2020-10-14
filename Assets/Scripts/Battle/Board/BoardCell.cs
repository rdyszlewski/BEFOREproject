using Assets.Scripts.Battle.Board;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider;

    private IElementInfo element;
    public IElementInfo Element { get => element; set => element = value; }

    public void Initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void Resize(Vector3 newSize)
    {
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = newSize;
        transform.localScale = new Vector3(1, 1, 1);        
    }

    // TODO: później można to trochę przerobić
    public void SetLayer(int layerNumber)
    {
        spriteRenderer.sortingOrder = layerNumber;
    }
    
    // TODO: może konieczne będzie, aby Cell zawierało informacje o pozycji elementu na planszy
}
