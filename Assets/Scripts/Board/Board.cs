using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateBoard ();

public class Board : MonoBehaviour {
  [SerializeField]
  private Vector2Int _size;

  private UpdateBoard _updateEvent;

  private BoardRenderer2D _boardRenderer;

  private BoardField[, ] _fields;

  public Vector2Int size {
    get { return _size; }
  }

  public BoardField[, ] fields {
    get { return _fields; }
  }

  // Start is called before the first frame update
  void Start () {
    // InitBoardFields();
    // UpdateBoard();
  }

  private void InitBoardFields () {
    _fields = new BoardField[_size.y, _size.x];
    for (int row = 0; row < _size.y; row++) {
      for (int column = 0; column < size.x; column++) {
        BoardField field = new BoardField ();
        field.row = row;
        field.column = column;
        _fields[row, column] = field;
      }
    }

  }

  public void SetUpdateEvent (UpdateBoard callback) {
    _updateEvent = callback;
  }

  private void UpdateBoard () {
    if (_updateEvent != null) {
      _updateEvent ();
    }
  }

  // Update is called once per frame
  void Update () {

  }

  // TODO: zaprojektować to jakoś lepiej
  public void LoadBoard () {
    InitBoardFields (); // TODO: o to chodziło?
    _updateEvent ();
  }
}