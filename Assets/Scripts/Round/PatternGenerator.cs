using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatternGenerator : MonoBehaviour
{

  public interface IProbabilities<T>{
    T key{get;}
    float probability{get;}
  }

  [System.Serializable]
  public class StepTypePropabilities : IProbabilities<StepType>{

    [SerializeField]
    private StepType _type;

    [SerializeField]
    private float _probability;

    public StepType key{
      get{return _type;}
      set{_type = value;}
    }

    public float probability{
      get{return _probability;}
      set{_probability = value;}
    }
  }  

  [System.Serializable]
  public class NumberProbability: IProbabilities<int>{
    [SerializeField]
    private int _number;
    [SerializeField]
    private float _probability;

    public int key{
      get{return _number;}
      set{_number =value;}
    }

    public float probability{
      get{return _probability;}
      set{_probability = value;}
    }
  }

  [SerializeField]
  private List<StepTypePropabilities> typePropabilities;

  [SerializeField]
  private List<NumberProbability> turnProbabilities;

  [SerializeField]
  private List<NumberProbability> stepsProbabilities;

  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
      
  }

  public List<Turn> GeneratePattern(){
    List<Turn> turnsResult = new List<Turn>();
    int turnsNumber = RandomWithProbabilities<int>(turnProbabilities.ToList<IProbabilities<int>>());
    for(int turn = 0; turn < turnsNumber; turn++){
      Turn roundTurn = new Turn();
      int stepsNumber = RandomWithProbabilities<int>(stepsProbabilities.ToList<IProbabilities<int>>());

      for(int step=0; step < stepsNumber; step++){
        StepType type = RandomWithProbabilities<StepType>(typePropabilities.ToList<IProbabilities<StepType>>());
        Step roundStep = new Step(type);
        roundTurn.AddStep(roundStep);
      }
      turnsResult.Add(roundTurn);
    }
    return turnsResult;
  }

  private T RandomWithProbabilities<T>(List<IProbabilities<T>> probabilities){
    float sumProbabilities = CalculateSumOfProbabilities(probabilities);
    float value = UnityEngine.Random.Range(0, sumProbabilities);
    int randomIndex = GetRandomIndexFromValue(value, probabilities);
    return probabilities[randomIndex].key;

  }

  private float CalculateSumOfProbabilities<T>(List<IProbabilities<T>> probabilities){
    return probabilities.Select(x=>x.probability).Sum();
  }

  private int GetRandomIndexFromValue<T>(float randomValue, List<IProbabilities<T>> probabilities){
    float sum = 0;
    for(int i=0; i<probabilities.Count; i++){
      sum += probabilities[i].probability;
      if(randomValue <= sum){
        return i ;
      }
    }
    return 0;
  }
}
