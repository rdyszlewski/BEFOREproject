using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardField 
{
    private int _column;
    private int _row;

    public int column{
        get{return _column;}
        set{_column = value;}
    }

    public int row{
        get{return _row;}
        set{_row = value;}
    }
    // Start is called before the first frame update
}
