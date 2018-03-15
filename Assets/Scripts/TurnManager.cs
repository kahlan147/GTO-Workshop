using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public delegate void NextPlayerTurn();
    public static event NextPlayerTurn nextPlayerTurn;

    public List<Player> Players;
    public UnitPlacer unitPlacer;

    private Player currentPlayer;
    private int playerNumber = -1;

	// Use this for initialization
	void Start () {
        NextTurn();
	}

    // Update is called once per frame
    void Update () {
		
	}

    public void NextTurn()
    {
        playerNumber++;
        if (playerNumber >= Players.Capacity)
        {
            playerNumber = 0;
        }
        currentPlayer = Players[playerNumber];
        nextPlayerTurn();
    }

    public Player GetPlayer()
    {
        return currentPlayer;
    }


}
