using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    public Camera camera;
    public TurnManager turnManager;

    private Player currentPlayer;
    private UnitPlacer unitPlacer;
    private Vector3 LastMovementVector = new Vector3(1000, 1000, 1000);
    private Unit selectedUnit;
    private Tile previousSelectedTile;

    private bool one_click = false;
    private bool timer_running;
    private float timer_for_double_click;

    //this is how long in seconds to allow for a double click
    float DoubleClickDelay = .25f;

    // Use this for initialization
    void Start() {
        
    }

    private void OnEnable()
    {
        TurnManager.nextPlayerTurn += NextPlayerTurn;
    }

    // Update is called once per frame
    void Update() {
        Drag();
        DoubleClick();
    }

    private void NextPlayerTurn() {
        currentPlayer = turnManager.GetPlayer();
        unitPlacer = currentPlayer.GetComponentInChildren<UnitPlacer>();

        if (selectedUnit != null)
        {
            this.selectedUnit.SetSelected(false);
            this.selectedUnit = null;
        }
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
            if (!one_click)
            {
                one_click = true;

                timer_for_double_click = Time.time;
            }
            else
            {
                one_click = false;

                PlaceUnit();
            }
        }
        if (one_click){
            if ((Time.time - timer_for_double_click) > DoubleClickDelay){
                one_click = false;
            }
        }
    }

    private void PlaceUnit()
    {
        RaycastHit hit;
        Tile tile = null;
        
        if (Physics.Raycast(transform.position, -Vector3.up*3, out hit))
        {
            if (!SelectUnit(hit.collider.gameObject.transform.parent.GetComponent<Unit>())){
                tile = hit.collider.gameObject.transform.parent.GetComponent<Tile>();
            }
        }
        if (tile != null)
        {
            Vector3 coordinates = this.transform.position;
            if (tile.CanPlaceUnit())
            {
                if (selectedUnit != null)
                {
                    previousSelectedTile.SetUnit(null);
                    tile.SetUnit(selectedUnit);
                    selectedUnit.SetSelected(false);
                    selectedUnit = null;
                }
                else
                {
                    unitPlacer.PlaceUnit(tile, currentPlayer.MyColor, currentPlayer);
                }
            }
            else
            {
                SelectUnit(tile.unit);
                previousSelectedTile = tile;
            }
        }
    }

    private bool SelectUnit(Unit selectedUnit)
    {
        if (selectedUnit == null)
        {
            return false;
        }

        if (this.selectedUnit != null)
        {
            this.selectedUnit.SetSelected(false);
        }
        if (selectedUnit.isMyOwner(currentPlayer))
        {
            this.selectedUnit = selectedUnit;
            selectedUnit.SetSelected(true);
        }
        return true;
    }

    public void ChooseFactory(string unitName)
    {
        unitPlacer.ChooseFactory(unitName);
    }
    
}
