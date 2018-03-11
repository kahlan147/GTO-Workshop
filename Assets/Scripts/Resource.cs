using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour {

    public string resourceName;
    public delegate void ChangedValues();
    public static event ChangedValues ResourceChanged;

    public int StartingAmount;
    [HideInInspector]
    public int CurrentAmount;


	// Use this for initialization
	void Start () {
        this.CurrentAmount = StartingAmount;
        ResourceChanged();
	}

    public void Add()
    {
        CurrentAmount += 1;
        ResourceChanged();
    }

    public void Remove()
    {
        CurrentAmount -= 1;
        ResourceChanged();
    }

    public void pay(int amount)
    {
        CurrentAmount -= amount;
        ResourceChanged();
    }


}
