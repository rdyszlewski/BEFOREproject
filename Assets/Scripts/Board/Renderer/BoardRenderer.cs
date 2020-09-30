﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardRenderer : MonoBehaviour
{
    public enum GraphicsMode{
        MODE2D,
        MODE3D
    }

    private const float CELL_Z = 1;
    private const float BOARD_Z = 1;

    [SerializeField]
    private Vector3 _size;

    [SerializeField]
    private Vector2 _positionCenter;

    private Vector2 _cellSize;
    private Vector2 _startPosition;

    private Vector2Int _boardSize;

    private Cell[,] _cells;

    private GraphicsMode _currentGraphicsMode;
    private CellFactory _cellFactory;

    private Board _board;
    

    [SerializeField]
    private Texture2D _tempFloorTexture;



    // Start is called before the first frame update
    void Start()
    {
        InitBoard();
        _cellFactory = GetComponent<CellFactory>();
       _currentGraphicsMode = GraphicsMode.MODE2D;
    }

    void Update()
    {
        OnMouseMovement();
    }

    private void InitBoard(){
        Board board = GetComponent<Board>();
        board.SetUpdateEvent(UpdateBoard);
        _boardSize = board.size;
        _board = board;
    }

    private void InitCells(){
        _cells = InstantiateCells(_board.fields);
    }

    private void UpdateBoard(){
        if(_cells==null){
            InitBoard();
            InitRenderer(_board.fields);
            InitCells();
        }
    }

    private Cell[,] InstantiateCells(BoardField[,] fields){
        if(fields == null){
            return null;
        }
        Cell[,] instantiatedCells = new Cell[fields.GetLength(0), fields.GetLength(1)];
        for(int y =0; y<fields.GetLength(0); y++){
            for(int x=0; x < fields.GetLength(1); x++){
                // TODO: to prawdopodobnie będzie trzbea pozmieniać
                Cell cell = _cellFactory.CreateCell(this.gameObject, _currentGraphicsMode);
                cell.transform.localScale = _cellSize;
                cell.transform.position = CalculateCellPosition(y, x);
                cell.name = GetCellName(y ,x);
                cell.SetupTexture(_tempFloorTexture);
                cell.boardField = fields[y, x];
                instantiatedCells[y,x] = cell;
            }
        }
        return instantiatedCells;
    }

    private string GetCellName(int y, int x){
        return "cell_" + y + "_" + x;
    }

    private Vector3 CalculateCellPosition(int row, int column){
        float xPosition = _startPosition.x + _cellSize.x * column;
        float yPosition = _startPosition.y + _cellSize.y * row;
        Vector3 cellPosition = new Vector3(xPosition, yPosition, 1); // TODO: dorobić trzecią wartość
        return cellPosition; 
    }

    private void InitRenderer(BoardField[,] fields){
         Vector2Int boardSize = new Vector2Int(fields.GetLength(0), fields.GetLength(1));
        _cellSize = CalculateCellSize(boardSize);
        _startPosition = CalculateStartPosition(_cellSize);
    }

    private Vector3 CalculateCellSize(Vector2Int boardSize){
        float xSize = _size.x / boardSize.x;
        float ySize = _size.y / boardSize.y;
        // TODO: to chyba tak powinno być
        Vector2 cellSize = new Vector3(xSize, ySize, CELL_Z);
        return cellSize;
    }

    private Vector3 CalculateStartPosition(Vector2 cellSize){
        float x = _positionCenter.x - _size.x/2 + cellSize.x/2;
        float y = _positionCenter.y - _size.y/2 + cellSize.y/2; 
        Vector3 startPosition = new Vector3(x, y, BOARD_Z);
        return startPosition;
    }

    // Update is called once per frame
    
    public void OnMouseMovement(){
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0f, LayerMask.GetMask("Cell"));
        if(hit){
            GameObject gameObject = hit.collider.gameObject;
            Cell cell = gameObject.GetComponent<Cell>();
            cell.ChangeColor(Color.blue);
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_positionCenter, _size);
    }
}
