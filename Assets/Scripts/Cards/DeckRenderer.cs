using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRenderer : MonoBehaviour
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
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireCube (_positionCenter, _size);
  }
}
