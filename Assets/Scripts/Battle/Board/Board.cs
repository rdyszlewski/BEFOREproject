using Assets.Scripts.Battle.Board;
using System.Collections.Generic;
using UnityEngine;


public class Board
{
    private Vector2Int _size;
    public Vector2Int Size { get => _size; set => _size = value; }

    private BoardField[,] fields;

    public void Initialize(Vector2Int size, BoardField[,] fields)
    {
        Debug.unityLogger.Log(size);
        _size = size;
        this.fields = fields;
    }

    public BoardField GetField(int x, int y)
    {
        if(x >= 0 && x < _size.x && y >= 0 && y < _size.y)
        {
            return fields[y, x];
        }
        return null;
    }

    public BoardField GetField(Vector2Int position)
    {
        return GetField(position.x, position.y);
    }

}
