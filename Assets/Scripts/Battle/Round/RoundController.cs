using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
  private Round round;
  private RoundRenderer roundRenderer;

    void Start()
    {
      roundRenderer = GetComponent<RoundRenderer>();
      roundRenderer.Initialization();
        round = MockRound();
      roundRenderer.DrawPattern(round);

    }

    private Round MockRound(){
      Step step1 = new Step(StepType.HOLE);
      Step step2 = new Step(StepType.OPEN);
      Step step3 = new Step(StepType.OPEN);
      Step step4 = new Step(StepType.HOLE);

      Turn turn1 = new Turn(new List<Step>{step1, step2});
      Turn turn2 = new Turn(new List<Step>{step3});
      Turn turn3 = new Turn(new List<Step>{step4});
      
      Round round = new Round(new List<Turn>{turn1, turn2, turn3});
      return round;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
