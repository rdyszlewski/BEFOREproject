using UnityEngine;

public class CardItem : MonoBehaviour
{
    private Card card;
    public Card Card{get{return card;} set{card = value;}}

    private SpriteRenderer spriteRenderer;
    private BoxCollider boxCollider;

    private Texture2D holeTexture;
    public Texture2D HoleTexture{set{holeTexture = value;}}
    private Texture2D cardTexture;


    // TODO: zmianę rozmiaru można by oddelegować do jakieś strategii
    private RectTransform rectTransform;
    public void Initialize(){
      spriteRenderer = GetComponent<SpriteRenderer>();
      spriteRenderer.drawMode = SpriteDrawMode.Sliced;
      boxCollider = GetComponent<BoxCollider>();
      rectTransform = GetComponent<RectTransform>();
    }

    public void Resize(Vector2 size){
      Debug.Assert(spriteRenderer != null);
      Debug.Assert(boxCollider != null);
      Debug.Assert(rectTransform != null);
      spriteRenderer.size = size;
      boxCollider.size = size;

      rectTransform.sizeDelta = size;
    }

    public void ChangeColor(Color color){
      Debug.Assert(spriteRenderer != null);
      spriteRenderer.color = color;
    } 

    // TODO: przemyśleć, jak powinna wyglądać zmiana tekstur
    public void SetTexture(Texture2D texture){
      Debug.Assert(spriteRenderer != null);
      ChangeTexture(texture);
      cardTexture = texture;
    }
    
    private void ChangeTexture(Texture2D texture){
      Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
      spriteRenderer.sprite = sprite;
    }

    // TODO: może nazwa nie do końca adekwatna
    public void FlipCard(){
      // TODO: w parametrze mozna zrobić, żeby wyśietlało animację odwracania albo nie
      if(card.State == CardState.HOLE){
        ChangeTexture(holeTexture);
      } else {
        ChangeTexture(cardTexture);
      }

    }
}
