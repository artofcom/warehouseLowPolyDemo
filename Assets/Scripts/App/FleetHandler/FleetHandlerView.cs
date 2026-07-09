using UnityEngine;
using System;
using UnityEngine.AI;

public class FleetHandlerView : AView
{
    public event Action EventOnBtnStartClicked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    { 
    }


    public void OnBtnStartClicked()
    {
        EventOnBtnStartClicked?.Invoke();
    }
}
