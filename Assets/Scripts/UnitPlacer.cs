using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPlacer : MonoBehaviour {

    private Factory chosenFactory;
    public RawImage image;

    public Text unitName;
    public Text cost;

    public List<Factory> factories;

    private Coroutine currentTimer = null;

	// Use this for initialization
	void Start () {
        image.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseFactory(string unitname)
    {
        Debug.Log("1 " + unitname);
        foreach (Factory factory in factories)
        {
            Debug.Log(factory.unit.unitName);
            if (factory.unit.unitName == unitname)
            {
                this.chosenFactory = factory;
            }
        }
        if (currentTimer != null)
        {
            StopCoroutine(currentTimer);
        }
        currentTimer = StartCoroutine(ShowCostScreenTimer());
        unitName.text = chosenFactory.unit.unitName;
        cost.text = "Cost: " + chosenFactory.RequiredMaterials[0].resource.resourceName + " " + chosenFactory.RequiredMaterials[0].cost;
    }

    public void PlaceUnit(Tile tile, Material material)
    {
        if (chosenFactory != null)
        {
            chosenFactory.PlaceUnit(tile, material);
        }
        else
        {
            Debug.Log("No error text implemented <No unit chosen>");
        }
    }

    private IEnumerator ShowCostScreenTimer()
    {
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        image.gameObject.SetActive(false);
        yield return null;
    }
}
