using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField]
    private Vector2Int boardSize;

    private Board board;
    private BoardRenderer renderer;
    private BoardGenerator generator;
    
    void Start()
    {
        Initialize();
        GenerateBoard();
        

    }

    private void Initialize()
    {
        renderer = GetComponent<BoardRenderer>();
        renderer.Initialize();
        
        generator = GetComponent<BoardGenerator>();
    }
    
    void Update()
    {
        
    }

    public void GenerateBoard()
    {
        board = generator.GenerateBoard(boardSize);
        renderer.CreateBoard(board);
    }

    public void DestroyBoard() 
    {
        throw new NotImplementedException();
    }

    public Board GetBoard()
    {
        return board;
    }

    public Board CopyBoard()
    {
        throw new NotImplementedException();
    }

}
