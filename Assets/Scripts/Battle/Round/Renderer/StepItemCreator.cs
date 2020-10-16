using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepItemCreator : MonoBehaviour {

  [System.Serializable]
  private class StepElement {
    public StepType type;
    public Texture2D texture;
  }

  [SerializeField]
  private List<StepElement> elements;

  [SerializeField]
  private GameObject stepItemObject;

  public StepItem CreateStepItem (StepType type, Vector2 itemSize, Transform parent) {
    Debug.Assert(stepItemObject != null);
    GameObject createdStep = Instantiate(stepItemObject, parent);
    createdStep.AddComponent(typeof(LayoutElement));

    StepElement element = elements.Find(x=>x.type == type);
    if(element == null){
      return null;
    }
    
    // TODO: przejrzeć to. Naprawi
    StepItem item = createdStep.GetComponent<StepItem>();
    item.Initialize();
    item.SetLayer(10);
    item.SetTexture(element.texture);
    item.Resize(itemSize);
    // TODO: można zrobić nazywanie 
    return item;
  }
}