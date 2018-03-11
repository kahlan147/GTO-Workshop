using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int LocX;
    public int LocY;
    public Unit unit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetUnit(Unit unit)
    {
        this.unit = unit;
        unit.transform.position = new Vector3(this.transform.position.x, 1, transform.position.z);
    }
}
