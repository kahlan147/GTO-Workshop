using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour {

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

    public void AddWood()
    {
        CurrentAmount += 1;
        ResourceChanged();
    }

    public void RemoveWood()
    {
        CurrentAmount -= 1;
        ResourceChanged();
    }



}
