using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Battle.Board.Renderer
{
    public class BoardSelectionManager
    {
        private ISelection selector;
        private HashSet<BoardCell> selectedCells = new HashSet<BoardCell>();
        // TODO: być może można zrobić tutaj coś z typem aktywnego zaznaczenia. Być może możliwe będzie zaznaczanie kilku elementów, np. attack oraz przeciwnik. Trzeba to przemyśleć

        public void SetSelector(ISelection selector)
        {
            this.selector = selector;
        }

       // TODO: przemyśleć głębiej sens tej klasy

        public void Update()
        {
            // TODO: ta metoda jest tylko prezentacyjnie
            OnMouseMovement();
        }

        private void OnMouseMovement()
        {
            // TODO: może lepiej zrobić to w ten sposób, aby uderzało tylko w podłogę, a później brany byłby odpowiedni obiekt
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("Cell")))
            {
                GameObject gameObject = hit.collider.gameObject;
                BoardCell item = gameObject.GetComponent<BoardCell>();
                if (!selectedCells.Contains(item))
                {
                    DeselectAllCards();
                    selector.Select(item, SelectionType.MOVE);
                    selectedCells.Add(item);
                }
            } else
            {
                DeselectAllCards();
            }
        }

        private void DeselectAllCards()
        {
            foreach(BoardCell cell in selectedCells)
            { 
                selector.Deselect(cell, SelectionType.MOVE); // Czy ten typ jest tutaj potrzebny?
            }
            selectedCells.Clear();
        }
    }
}
