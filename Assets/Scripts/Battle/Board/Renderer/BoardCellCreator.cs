using Assets.Scripts.Battle.Board;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCellCreator : MonoBehaviour
{
    public enum CellType
    {
        FLOOR,
        PAWN,
        OBJECT,
        EFFECT
    }

    private FloorCellCreator floorCreator;
    private PawnCellCreator pawnCreator;
    private EffectCellCreator effectCreator;
    private ObjectCellCreator objectCreator;
    private CellLayers cellLayers;
    // Start is called before the first frame update
       
    public void Initialize()
    {
        cellLayers = GetComponent<CellLayers>();
        floorCreator = GetComponent<FloorCellCreator>();
        floorCreator.Initialize(cellLayers.GetRenderOrder(CellType.FLOOR));
        pawnCreator = GetComponent<PawnCellCreator>();
        effectCreator = GetComponent<EffectCellCreator>();
        objectCreator = GetComponent<ObjectCellCreator>();
        // TODO: zainicjalizować resztę
    }

    public BoardCell CreateFloorCell(FloorType type, Vector2 cellSize, Transform parent)
    {
        return floorCreator.CreateCell(type, cellSize, parent);
    }

    // TODO: zrobić tworzenie pozostałych informacji
}
