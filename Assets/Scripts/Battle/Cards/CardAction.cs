
public class CardAction{

  private CardType type;
  public CardType Type{get{return type;}}

  private Direction direction;
  public Direction Direction{get{return direction;}}

  private IActionCommand command;
  public IActionCommand Command{get{return command;} set{command = value;}}

  public CardAction(CardType type, Direction direction){
    this.type = type;
    this.direction = direction;
  }
}