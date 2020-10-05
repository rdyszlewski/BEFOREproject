using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCardsRenderer : MonoBehaviour
{
  [SerializeField]
  private Vector3 _size;

  [SerializeField]
  private Vector2 _positionCenter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnDrawGizmos () {
    Gizmos.color = Color.white;
    Gizmos.DrawWireCube (_positionCenter, _size);
  }
}
