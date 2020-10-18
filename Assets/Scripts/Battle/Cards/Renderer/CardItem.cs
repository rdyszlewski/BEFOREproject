using UnityEngine;

public class CardItem : MonoBehaviour
{
    private Card card;
    public Card Card{get{return card;} set{card = value;}}

    private SpriteRenderer cardRenderer;
    private BoxCollider cardCollider;

    private Texture2D holeTexture;
    public Texture2D HoleTexture{set{holeTexture = value;}}
    private Texture2D cardTexture;


    // TODO: zmianę rozmiaru można by oddelegować do jakieś strategii
    private RectTransform rectTransform;
    public void Initialize(){
      cardRenderer = GetComponent<SpriteRenderer>();
      cardRenderer.drawMode = SpriteDrawMode.Sliced;
      cardCollider = GetComponent<BoxCollider>();
      rectTransform = GetComponent<RectTransform>();
    }

    public void Resize(Vector2 size){
      Debug.Assert(cardRenderer != null);
      Debug.Assert(cardCollider != null);
      Debug.Assert(rectTransform != null);
      cardRenderer.size = size;
      cardCollider.size = size;

      rectTransform.sizeDelta = size;
    }

    public void ChangeColor(Color color){
      Debug.Assert(cardRenderer != null);
      cardRenderer.color = color;
    } 

    // TODO: przemyśleć, jak powinna wyglądać zmiana tekstur
    public void SetTexture(Texture2D texture){
      Debug.Assert(cardRenderer != null);
      ChangeTexture(texture);
      cardTexture = texture;
    }
    
    private void ChangeTexture(Texture2D texture){
      Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
      cardRenderer.sprite = sprite;
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
