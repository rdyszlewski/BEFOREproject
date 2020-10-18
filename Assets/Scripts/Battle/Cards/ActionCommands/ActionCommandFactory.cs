using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ActionCommandFactory{
  // TODO: to nie jest fabryka. Nazwać to odpowiednio

  private static Dictionary<CardType, IActionCommand> commandsMap;

  public static void Initialize(){
    commandsMap = new Dictionary<CardType, IActionCommand>();
    MoveCommand moveCommand = new MoveCommand();
    commandsMap.Add(CardType.MOVE_HORIZONTAL, moveCommand);
    commandsMap.Add(CardType.MOVE_VERTICAL, moveCommand);
    commandsMap.Add(CardType.TAKE, new TakeCommand());
    commandsMap.Add(CardType.USE, new UseCommand());
    commandsMap.Add(CardType.ATTACK, new AttackCommand());

    Debug.Assert(Enum.GetValues(typeof(CardType)).Length == commandsMap.Count);
  }

  public static IActionCommand GetCommand(CardType type){
    Debug.Assert(commandsMap.ContainsKey(type));
    return commandsMap[type];
  }
}