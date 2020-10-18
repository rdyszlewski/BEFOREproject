using System.Collections.Generic;
using UnityEngine;

public class ElementsMap<K, V> where V : IElement<K> {

  private Dictionary<K, V> elementsMap;

  public void Initialize (List<V> elements) {
    Debug.unityLogger.Log (elements.Count);
    elementsMap = CreateElementsMap (elements);
  }
  private Dictionary<K, V> CreateElementsMap (List<V> elements) {
    Dictionary<K, V> elementsMap = new Dictionary<K, V> ();
    foreach (IElement<K> element in elements) {
      Debug.Assert (!elementsMap.ContainsKey (element.Type));
      elementsMap.Add (element.Type, (V) element);
    }
    return elementsMap;
  }

  public V GetElement (K key) {
    if (elementsMap.ContainsKey (key)) {
      return elementsMap[key];
    }
    return default (V);
  }

  public void AddElement (V element) {
    elementsMap.Add (element.Type, element);
  }

  public int GetSize(){
    return elementsMap.Count;
  }

}