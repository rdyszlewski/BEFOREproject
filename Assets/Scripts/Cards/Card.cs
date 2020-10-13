using System.Collections.Generic;
using UnityEngine;

public class Card{

  private CardType _type;
  private StepType _stepType;
  private BattlePlayer _owner;
  private bool _reveal = true;

  private List<CardAction> _actions = new List<CardAction>();  

  public CardType type{
    get{return _type;}
    set{_type = value;}
  }

  public StepType stepType{
    get{return _stepType;}
    set{_stepType = value;}
  }

  public BattlePlayer owner{
    get{return _owner;}
    set{_owner = value;}
  }

  public bool reveal{
    get{return _reveal;}
    set{_reveal = value;}
  }

  public List<CardAction> actions{
    get{
      return _actions;
      }
    set{_actions = value;}
  }
}