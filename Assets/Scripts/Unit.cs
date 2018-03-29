using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    
    public string unitName;
    public GameObject selectionShower;

    private Player myOwner;

	// Use this for initialization
	void Start () {
        selectionShower.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetColor(Material myNewColor)
    {
        this.GetComponentInChildren<Renderer>().material = myNewColor;
    }

    public void SetSelected(bool selected)
    {
        selectionShower.SetActive(selected);
    }

    public void SetPlayer(Player player)
    {
        myOwner = player;
    }

    public bool isMyOwner(Player player)
    {
        if (player == myOwner)
        {
            return true;
        }
        return false;
    }
    
}
