using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cell : MonoBehaviour
{
    private BoardField _boardField;

    public BoardField boardField{
        get{return _boardField;}
        set{_boardField = value;}
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void SetupTexture(Texture texture);

    public abstract void ChangeColor(Color color);
}
