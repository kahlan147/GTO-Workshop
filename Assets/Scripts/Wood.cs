using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour {

    public Text woodText;
    public Resource resource;
    
    private void OnEnable()
    {
        Resource.ResourceChanged += ChangedResources;
    }

    private void ChangedResources()
    {
        woodText.text = "Wood: " + resource.CurrentAmount;
    }
}
