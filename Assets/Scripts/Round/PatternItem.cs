using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternItem : MonoBehaviour
{

  private SpriteRenderer spriteRenderer;
  private Sprite sprite;

  private int _turn;
  private int _step;

  public int turn{
    get{return _turn;}
    set{_turn = value;}
  }

  public int step{
    get{return _step;}
    set{_step = value;}
  }
    // Start is called before the first frame update
    void Start()
    {
     Init(); 
    }

    private void Init(){
      spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupTexture(Texture texture){
      if(spriteRenderer == null){
        Init();
      }
      if(texture){
        sprite = Sprite.Create((Texture2D)texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 64);
        spriteRenderer.sprite = sprite;
      }
    }

    public void Select(){
      spriteRenderer.color = Color.blue;
    }

    public void Deselect(){
      spriteRenderer.color = Color.white;
    }
}
