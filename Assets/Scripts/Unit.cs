using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Material test;
    public string unitName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColor(Material myNewColor)
    {
        this.GetComponentInChildren<Renderer>().material = myNewColor;
    }
    
}
