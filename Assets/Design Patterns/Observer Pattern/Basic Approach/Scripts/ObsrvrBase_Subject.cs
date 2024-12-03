using System.Collections.Generic;
using UnityEngine;

public abstract class ObsrvrBase_Subject : MonoBehaviour
{
    /// <summary>
    /// Subject abstract class handles the adding, removing, notifying of observers
    /// This class will be inherited by the classes that needs to trigger some events and notify their subscribers
    /// </summary>

    private List<ObsrvrBase_IObserver> _observersList = new List<ObsrvrBase_IObserver>(); // for storing observers with the interface

    public void AddObserver(ObsrvrBase_IObserver ObsrvrBase_IObserver)
    {
        // adding the observer to the list
        _observersList.Add(ObsrvrBase_IObserver);
    }

    public void RemoveObserver(ObsrvrBase_IObserver ObsrvrBase_IObserver)
    {
        // removing the observer from the list
        _observersList.Remove(ObsrvrBase_IObserver);
    }

    internal void NotifyObservers()
    {
        // notifying all the observers of some event
        int len = _observersList.Count;
        for (int i = 0; i < len; i++)
        {
            _observersList[i].OnNotify();
        }
    }
}
