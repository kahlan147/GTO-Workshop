using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {

    public Unit unit;
    public List<RequiredMaterial> RequiredMaterials;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [System.Serializable]
    public struct RequiredMaterial
    {
        public ResourceModel resource;
        public int cost;
    }

    public void PlaceUnit(Vector3 coordinates)
    {
        bool canPay = true;
        foreach(RequiredMaterial material in RequiredMaterials) {
            if (material.cost > material.resource.CurrentAmount)
            {
                canPay = false;
                break;
            }
        }
        if (canPay)
        {
            foreach (RequiredMaterial material in RequiredMaterials)
            {
                material.resource.pay(material.cost);
            }

            Instantiate(unit, coordinates, this.transform.rotation);
        }
        else
        {
            Debug.Log("No error message implemented <Not enough resources>");
        }

    }
}
