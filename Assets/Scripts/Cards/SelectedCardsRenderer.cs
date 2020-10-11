using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectedCards;

public class SelectedCardsRenderer : MonoBehaviour {
  [SerializeField]
  private Vector3 _size;

  [SerializeField]
  private Vector2 _positionCenter;

  [SerializeField]
  private Vector3 _itemSize;

  private SelectedCards cardsDeck;

  private List<CardItem> items;

  private CardFactory cardFactory;

  private Texture holeCardTexture;

  private Dictionary<Card, CardItem> cardsMap;

  [SerializeField]
  private float _zOffset = 0.001f;
  private float _currentZOffset = 1;

  // TODO: przerobić to, żeby działało na stosie

  // Start is called before the first frame update
  void Start () {
    cardsMap = new Dictionary<Card, CardItem> ();
    cardsDeck = GetComponent<SelectedCards> ();
    cardsDeck.SetChosenCardsCallback (UpdateChosenCards);
    InitCardsFactory ();

  }

  private void InitCardsFactory () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("CardsFactory");
    cardFactory = gameObject.GetComponent<CardFactory> ();

  }

  // Update is called once per frame
  void Update () {

  }

  private void UpdateChosenCards (Card card, DeckAction action) {
    switch (action) {
      case DeckAction.REVEAL:
        RevealCard (card);
        break;
      case DeckAction.PUT:
        PutCard (card);
        break;
      case DeckAction.REMOVE:
        RemoveCard (card);
        break;
    }
  }

  private void RevealCard (Card card) {
    // CardItem item = cardFactory.CreateCardItem(card.type, transform, _itemSize);
    if (cardsMap.ContainsKey (card)) {
      CardItem item = cardsMap[card];
      item.SetupTexture (cardFactory.GetCardItemTexture (card.type));
    }
  }

  private void PutCard (Card card) {
    CardItem item = null;
    if (card.stepType == StepType.OPEN) {
      item = cardFactory.CreateCardItem (card.type, transform, _itemSize);
    } else {
      item = cardFactory.CreateCardItem (CardType.HOLE, transform, _itemSize);
    }
    item.transform.position = new Vector3 (_positionCenter.x, _positionCenter.y, _currentZOffset);
    _currentZOffset -= _zOffset;
    item.gameObject.layer = 0;
    if (!cardsMap.ContainsKey (card)) {
      cardsMap.Add (card, item); // TODO: sprawdzić po co to jest 
    }
  }

  private void RemoveCard (Card card) {
    if (cardsMap.ContainsKey (card)) {
      CardItem item = cardsMap[card];
      cardsMap.Remove (card);
      _currentZOffset += _zOffset;
      // TODO: sprawdzić, czy wszystko jest ok
    }
  }

  void OnDrawGizmos () {
    Gizmos.color = Color.white;
    Gizmos.DrawWireCube (_positionCenter, _size);

    Gizmos.color = Color.black;
    Gizmos.DrawWireCube (_positionCenter, _itemSize);
  }
}