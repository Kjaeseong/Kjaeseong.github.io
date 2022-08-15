using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteSubject : MonoBehaviour, I_Subject
{
    List<Observer> observers = new List<Observer>();

    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(Observer observer)
    {
        if(observer.IndexOf(observer > 0))
        {
            observers.Remove(observer);
        }
    }

    public void Notify()
    {
        foreach (Observer o in observers)
        {
            o.OnNotify();
        }
        /*
        or
        for (int i = 0; i < observers.Count; ++i)
        {
            observers[i].OnNotiry();
        }
        */
    }

    void Start()
    {
        Observer observer_1 = new ConcreteObserver1();
        Observer observer_2 = new ConcreteObserver1();

        AddObserver(observer_1);
        AddObserver(observer_2);
    }
}