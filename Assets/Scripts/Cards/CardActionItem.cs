using UnityEngine;

public abstract class CardActionItem: MonoBehaviour{
  private CardAction _action;

  public CardAction action{
    get{return _action;}
    set{_action = value;}
  }

  private Vector3 _size;
  public Vector3 size{
    set{_size = value;}
    protected get{return _size;}
  }

  public abstract void SetupTexture(Texture texture);
  public abstract void ChangeColor(Color color);

}