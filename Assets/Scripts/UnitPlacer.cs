using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPlacer : MonoBehaviour {

    private Factory chosenFactory;
    public RawImage image;

    public Text unitName;
    public Text cost;

    private Coroutine currentTimer = null;

	// Use this for initialization
	void Start () {
        image.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChooseFactory(Factory factory)
    {
        this.chosenFactory = factory;
        if (currentTimer != null)
        {
            StopCoroutine(currentTimer);
        }
        currentTimer = StartCoroutine(ShowCostScreenTimer());
        unitName.text = factory.unit.unitName;
        cost.text = "Cost: " + factory.RequiredMaterials[0].resource.resourceName + " " + factory.RequiredMaterials[0].cost;
    }

    public void PlaceUnit(Vector3 coordinates)
    {
        if (chosenFactory != null)
        {
            chosenFactory.PlaceUnit(coordinates);
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
