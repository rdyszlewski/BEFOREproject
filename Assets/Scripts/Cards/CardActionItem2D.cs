using UnityEngine;

public class CardActionItem2D: CardActionItem{
  // TODO: przenieść całą zawartość do oddzielnej klasy
  private SpriteRenderer renderer;
  private Sprite sprite;
  private BoxCollider2D collider;

  void Start(){
    Init();
  }

  private void Init(){
    renderer = GetComponent<SpriteRenderer>();
    collider = GetComponent<BoxCollider2D>();
  }

  public override void ChangeColor(Color color)
  {
    renderer.color = color;
  }

  public override void SetupTexture(Texture texture)
  {
    if(renderer == null){
      Init();
      // TODO: dowiedzieć się, jak uruchamiać komponenty w odpowiedniej kolejności
    }
    if(texture){
      sprite = Sprite.Create((Texture2D)texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
      renderer.sprite = sprite;
      this.transform.localScale = new Vector3(size.x/ renderer.sprite.texture.width * renderer.sprite.pixelsPerUnit,
      size.y / renderer.sprite.texture.height * renderer.sprite.pixelsPerUnit, 1);
      if(collider){
        collider.size = new Vector2(size.x/ transform.localScale.x, size.y / transform.localScale.y);
      }
    }
  }
}