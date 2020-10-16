using UnityEngine;
using UnityEngine.UI;
using static RoundRenderer;

public class RoundSizeCorrector {

  private readonly string PATTERN_CONTAINER = "Pattern";
  private readonly string STEPS_CONTAINER = "Steps";
  private readonly string EFFECTS_CONTAINER = "Effects";

  public void Resize (GameObject patternContainer, PatternSizes sizes) {
    Transform patternTransform = patternContainer.transform;
    for (int i = 0; i < patternTransform.childCount; i++) {
      ResizeTurn (patternTransform.GetChild (i), sizes);
    }
    SetHorizontalSpacing (patternTransform, sizes.turnSpacing);
  }

  private void ResizeTurn (Transform turnTransform, PatternSizes sizes) {
    Transform stepsTransform = turnTransform.Find (STEPS_CONTAINER);
    ResizeStepItemsInTurn (sizes.itemSize, stepsTransform);
    ResizeTurnItem (sizes, turnTransform, stepsTransform);
  }

  private void SetHorizontalSpacing (Transform transform, float spacing) {
    HorizontalLayoutGroup layout = transform.GetComponent<HorizontalLayoutGroup> ();
    layout.spacing = spacing;
  }

  private void ResizeStepItemsInTurn (Vector2 itemSize, Transform stepsTransform) {
    for (int i = 0; i < stepsTransform.childCount; i++) {
      Transform stepItemTransform = stepsTransform.GetChild (i);
      SetStepItemSize (itemSize, stepItemTransform);
    }
  }

  private void SetStepItemSize (Vector2 itemSize, Transform stepTransform) {

    SetRectTransformSize(stepTransform, itemSize);
    SetSpriteSize(stepTransform, itemSize);
    SetColliderSize(stepTransform, itemSize);

    stepTransform.localScale = new Vector3 (1, 1, 1);
  }

  private void SetRectTransformSize(Transform transform, Vector2 size){
     RectTransform rectTransform = transform.GetComponent<RectTransform> ();
    rectTransform.sizeDelta = size;
  }

  private void SetSpriteSize(Transform transform, Vector2 size){
    SpriteRenderer spriteRenderer = transform.GetComponent<SpriteRenderer> ();
    spriteRenderer.drawMode = SpriteDrawMode.Sliced;
    spriteRenderer.size = size;
  }

  private void SetColliderSize(Transform transform, Vector2 size){
     BoxCollider2D collider = transform.GetComponent<BoxCollider2D> ();
    collider.size = size;
  }

  private void ResizeTurnItem (PatternSizes sizes, Transform turnTransform, Transform stepsTransform) {
    Vector2 size = CalculateTurnItemSize(stepsTransform, sizes);
    SetRectTransformSize(turnTransform, size);
    SetRectTransformSize(stepsTransform, size);
    SetHorizontalSpacing(stepsTransform, sizes.stepsSpacing);
  }

  private Vector2 CalculateTurnItemSize(Transform stepsTransform, PatternSizes sizes){
     int childCount = stepsTransform.childCount;
    float width = childCount * sizes.itemSize.x + (childCount - 1) * sizes.stepsSpacing;
    // TODO: tutaj powinno być obliczenie wysokości, zostawić to na później
    Vector2 size = new Vector2 (width, sizes.itemSize.y);
    return size;
  }
}