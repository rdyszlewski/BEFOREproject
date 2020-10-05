using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardItem : MonoBehaviour
{
  private Card _card;
  public Card card{
    get{return _card;}
    set{_card = value;}
  }

  private Vector3 _size;
  public Vector3 size{
    set{_size = value;}
    protected get{return _size;}
  }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void SetupTexture(Texture texture);

    public abstract void ChangeColor(Color color);
    // TODO: albo zamiast tego zrobić select, deselect

}
