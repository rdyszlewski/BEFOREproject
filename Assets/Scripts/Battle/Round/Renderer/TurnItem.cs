using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnItem : MonoBehaviour {
  private Transform stepsContainer;
  private Transform effectsContainer;

  private List<StepItem> steps;
  public List<StepItem> Steps { set { steps = value; } }

  private IResizeStrategy resizeStrategy;

  public void Initialize () {
    stepsContainer = transform.Find ("Steps");
    effectsContainer = transform.Find ("Effects");

    resizeStrategy = new LayoutGroupResizeStrategy (stepsContainer.GetComponent<HorizontalLayoutGroup> ());
  }

  public void Resize () {
    resizeStrategy.Resize ();
  }

  // TODO: przeczytać, czy to na pewno jest strategią
  private interface IResizeStrategy {
    void Resize ();
  }

  private class LayoutGroupResizeStrategy : IResizeStrategy {
    private HorizontalLayoutGroup layoutGroup;
    private RectTransform parentRectTransform;
    private RectTransform stepsRectTransform;

    public LayoutGroupResizeStrategy (HorizontalLayoutGroup layoutGroup) {
      this.layoutGroup = layoutGroup;
      parentRectTransform = layoutGroup.gameObject.transform.parent.GetComponent<RectTransform> ();
      stepsRectTransform = layoutGroup.GetComponent<RectTransform> ();
    }
    public void Resize () {
      int childCount = layoutGroup.transform.childCount;
      // TODO: jeżeli założymy, że rozmiar poszczególnych elementów się nie zmienia, można rozmiar pobrać jednorazowo
      Vector2 itemSize = GetItemSize ();
      float width = childCount * itemSize.x + layoutGroup.spacing * (childCount - 1);
      ChangeSize(width);
    }

    private Vector2 GetItemSize () {
      // TODO: tutaj pobierany jest zły element
      Transform itemTransform = layoutGroup.transform.GetChild (0);
      RectTransform rectTransform = itemTransform.GetComponent<RectTransform> ();
      return new Vector2 (rectTransform.rect.width, rectTransform.rect.height);
    }

    private void ChangeSize (float width) {
      Vector2 size = new Vector2 (width, parentRectTransform.rect.height);
      parentRectTransform.sizeDelta = size;
      stepsRectTransform.sizeDelta = size;
    }
  }
}