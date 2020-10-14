using Assets.Scripts.Battle.Board;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class BoardGenerator : MonoBehaviour
{
    
    public Board GenerateBoard(Vector2Int size)
    {
        Board board = new Board();
        Floor[,] floors = GenerateFloors(size);
        // TODO: zrobić generowanie obiektów
          
        BoardField[,] fields = new BoardField[size.y, size.x];
        for (int row = 0; row < size.y; row++)
        {
            for (int column = 0; column < size.x; column++)
            {
                BoardField field = new BoardField();
                field.Row = row;
                field.Column = column;
                field.Floor = floors[row, column];
                fields[row, column] = field;
            }
        }

        board.Initialize(size, fields);

        Debug.unityLogger.Log("Zakończono generowanie planszy");
        return board;
    }

    private Floor[,] GenerateFloors(Vector2Int size)
    {
        Floor[,] floors = new Floor[size.y, size.x];
        for(int row = 0; row < size.y; row++)
        {
            for(int column = 0; column < size.x; column++)
            {
                Floor floor = new Floor(FloorType.DEFAULT); // TODO: zrobić tutaj jakieś losowanie podłogi
                floors[row, column] = floor;
            }
        }
        return floors;
    }
}
