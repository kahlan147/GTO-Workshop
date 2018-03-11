using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    public Camera camera;
    public UnitPlacer unitPlacer;

    private Vector3 LastMovementVector = new Vector3(1000, 1000, 1000);

    private bool one_click = false;
    private bool timer_running;
    private float timer_for_double_click;

    //this is how long in seconds to allow for a double click
    float delay = .25f;

    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Drag();
        DoubleClick();
    }

    private void Drag()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 MousePosition = GetMousePositionInGameWorld();
            this.transform.position = MousePosition;

            if (LastMovementVector.x == 1000 && LastMovementVector.y == 1000 && LastMovementVector.z == 1000)
            {
                LastMovementVector = this.transform.position;
            }
            else
            {
                Vector3 movement = LastMovementVector - this.transform.position;
                camera.transform.position += movement;

            }
        }

        else if (!Input.GetMouseButton(0))
        {
            LastMovementVector = new Vector3(1000, 1000, 1000);
        }
    }
    
    public Vector3 GetMousePositionInGameWorld()
    {
        //To get the current mouse position
        Vector3 mousePosition = Input.mousePosition;
        //Convert the mousePosition according to World position
        return Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, camera.transform.position.y - 1.5f));
    }

    private void DoubleClick()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!one_click) // first click no previous clicks
            {
                one_click = true;

                timer_for_double_click = Time.time; // save the current time
                                                    // do one click things;
            }
            else
            {
                one_click = false; // found a double click, now reset

                PlaceUnit();
            }
        }
        if (one_click)
        {
            // if the time now is delay seconds more than when the first click started. 
            if ((Time.time - timer_for_double_click) > delay)
         {

                //basically if thats true its been too long and we want to reset so the next click is simply a single click and not a double click.

                one_click = false;

            }
        }
    }

    private void PlaceUnit()
    {
        Vector3 coordinates = this.transform.position;
        unitPlacer.PlaceUnit(coordinates);
    }
}
