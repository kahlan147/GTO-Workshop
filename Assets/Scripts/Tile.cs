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
        if (unit != null)
        {
            unit.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z);
        }
    }

    public bool CanPlaceUnit()
    {
        if (this.unit == null)
        {
            return true;
        }
        return false;
    }
}
