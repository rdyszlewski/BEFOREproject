using System.Collections.Generic;

public class PhaseInitData{

  private List<BattlePlayer> _players;
  private Hand _hand;
  private Board _board;
  private SelectedCards _selectedCards;
  private Pattern _roundPattern;
  private CardsRenderer _cardsRenderer;
  private CardFactory _cardFactory;
  private ActionRenderer _actionRenderer;

  public List<BattlePlayer> players{
    get{return _players;}
    set{_players = value;}
  }

  public Hand hand{
    get{return _hand;}
    set{_hand = value;}
  }

  public Board board{
    get{return _board;}
    set{_board = board;}
  }

  public SelectedCards selectedCards{
    get{return _selectedCards;}
    set{_selectedCards = value;}
  }

  public Pattern roundPattern{
    get{return _roundPattern;}
    set{_roundPattern = value;}
  }

  public CardsRenderer cardsRenderer{
    get{return _cardsRenderer;}
    set{_cardsRenderer = value;}
  }

  public CardFactory cardsFactory{
    get{return _cardFactory;}
    set{_cardFactory = value;}
  }

  public ActionRenderer actionRenderer {
    get{return _actionRenderer;}
    set{_actionRenderer = value;}
  }

}