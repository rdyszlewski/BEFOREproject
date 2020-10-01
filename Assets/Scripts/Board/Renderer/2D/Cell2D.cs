using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2D : Cell
{
    [SerializeField]
    private Texture2D texture;
    private Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnDrawGizmos(){
        Gizmos.color = Color.red;
        // TODO: to prawdopodobnie nie będzie o to chodziło
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    public override void SetupTexture(Texture texture)
    {
        if(texture){
            sprite = Sprite.Create((Texture2D)texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
            spriteRenderer.sprite = sprite;
            if(boxCollider){
                boxCollider.size = new Vector2(1, 1);
            }
        }
    }

    public override void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
