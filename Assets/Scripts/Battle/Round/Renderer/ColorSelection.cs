using UnityEngine;

public class ColorSelection : MonoBehaviour, IRoundSelection
{
  private PatternItem pattern;

  [SerializeField]
  private Color activeStepColor;

  public void Initialize(PatternItem pattern){
    this.pattern = pattern;
  }

  public void Deselect(int turn, int step)
  {
    ChangeColor(turn, step, Color.white);
  }

  public void Select(int turn, int step)
  {
    ChangeColor(turn, step, activeStepColor);
  }

  private void ChangeColor(int turn, int step, Color color){
    pattern.GetTurnItem(turn).GetStepItem(step).ChangeColor(color);
  }
}
