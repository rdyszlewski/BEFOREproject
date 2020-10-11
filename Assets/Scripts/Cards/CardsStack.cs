using System.Collections;
using System.Collections.Generic;

public class CardsStack<T>
{

  private List<T> elements;
  public CardsStack()
  {
    elements = new List<T>();
  }

  public void Clear(){
    elements.Clear();
  }

  public T PeekFirst(){
    return elements[GetLastIndex()];
  }

  private int GetLastIndex(){
   return elements.Count - 1;
  }

  public T PeekLast(){
    return elements[0];
  }

  public T PopFirst(){
    return Pop(GetLastIndex());
  }

  public T PopLast(){
    return Pop(0);
  }

  private T Pop(int index){
    if(elements.Count == 0){
      return default(T);
    }
    T element = elements[index];
    elements.RemoveAt(index);
    return element;
  }

  public void Push(T element){
    elements.Add(element);
  }


}