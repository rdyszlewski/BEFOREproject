using Assets.Scripts.Battle.Board;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class CellCreatorBase : MonoBehaviour
{
    [System.Serializable]
    protected class CellElement<T>
    {
        public T type;
        public Texture2D texture;
    }

    protected class CellElementsMap<T>
    {
        private Dictionary<T, CellElement<T>> elementsMap;

        public void Initialize(List<CellElement<T>> elements)
        {
            Debug.unityLogger.Log(elements.Count);
            elementsMap = CreateElementsMap(elements);
        }
        private Dictionary<T, CellElement<T>> CreateElementsMap(List<CellElement<T>> elements)
        {
            Dictionary<T, CellElement<T>> elementsMap = new Dictionary<T, CellElement<T>>();
            foreach (CellElement<T> element in elements)
            {
                Debug.Assert(!elementsMap.ContainsKey(element.type));
                elementsMap.Add(element.type, element);
            }
            return elementsMap;
        }

        public CellElement<T> GetCellElement(T key)
        {
            //Debug.unityLogger.Log(elementsMap.Count);
            //Debug.unityLogger.Log(key);
            if (elementsMap.ContainsKey(key))
            {
                //Debug.unityLogger.Log("Znaleziono");
                return elementsMap[key];
            }
            //Debug.unityLogger.Log("Nie znaleziono");
            return null;
        }

        public void AddCellELement(CellElement<T> element)
        {
            elementsMap.Add(element.type, element);
        }
    }

    // TODO: jak to teraz przerobić 

    private int renderOrder;
    protected int RenderOrder { get { return renderOrder; } }
    public void Initialize(int renderOrder)
    {
        this.renderOrder = renderOrder;
        InitializeCreator();
    }

    protected abstract void InitializeCreator();

    // TODO: wymyslić tutaj jakiś polimorfizm do przekazania typu. Wtedy będzie można zrobić taką metodę
    //public abstract BoardCell CreateCell();


}
