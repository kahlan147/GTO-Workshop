using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceView : MonoBehaviour {

    public Text resourceText;
    public ResourceModel resource;
    
    private void OnEnable()
    {
        ResourceModel.ResourceChanged += ChangedResources;
    }

    private void ChangedResources()
    {
        resourceText.text = resource.resourceName + ": " + resource.CurrentAmount;
    }
}
