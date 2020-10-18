using System.Collections.Generic;
using UnityEngine;

public class CardsRenderer : MonoBehaviour
{
  // TODO; prawdopdobnie to wszystko będzie wyglądało nieco inaczej. Być może będzie jeden renderer zarządzający wszystkimi kartami (Deck, Hand, ChosenCards). Wtedy będzie można robić fajne przejśćia karty pomiędzy odpowiednimi kupkami

  // TODO: może zrobić jakiś globalny rozmiar karty, tak, żeby w każdym miejscu wyglądały tak samo
  [SerializeField]
  private Vector3 cardSize;


  private HandRenderer handRenderer;
  private PileRenderer pileRenderer;
  private DeckRenderer deckRenderer;


  private SelectionController selectionController;
  private CardItemCreator itemCreator;
  

  public void Initialize(){
    // TODO: można to też zrobić tak, ze pobiera się to z dzieci. Prawdopodobnie łatwiej będzie tym zarządzac
    itemCreator = GetComponent<CardItemCreator>();
    handRenderer = GetComponentInChildren<HandRenderer>();
    handRenderer.Initialize(cardSize, itemCreator);
    pileRenderer = GetComponentInChildren<PileRenderer>();
    pileRenderer.Initialize(cardSize);
    deckRenderer = GetComponentInChildren<DeckRenderer>();
    deckRenderer.Initialize(cardSize, itemCreator);
  }

  public void DrawHand(Hand hand){
    handRenderer.Draw(hand);
  }

  public void AddCardToHand(Card card){
    handRenderer.AddCard(card);
  }

  public void ClearHand(){
    handRenderer.RemoveAll();
  }
  
  public void DrawDeck(Deck deck){
    deckRenderer.Draw(deck);
  }

  public void MoveCardFromHandToPile(Card card){
     CardItem item = handRenderer.UseCard(card);
     pileRenderer.AddCardItem(item);
  }

  public void MoveCardFromDeckToHand(Card card){

  }

  

  // TODO: przerzucenie kart z talii do ręki
  // TODO: przerzucenie kart z ręki do stosu
}
