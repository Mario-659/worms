using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamChange : MonoBehaviour
{
    public GameObject[] teamBlue;
    [SerializeField]
    GameObject currentPlayer;

    void Start()
    {
        for(int i = 1; i < teamBlue.Length; i++)
        {
            teamBlue[i].GetComponent<PlayerMovement>().enabled = false;
            teamBlue[i].GetComponent<FireWeapon>().enabled = false;
        }        
        currentPlayer = teamBlue[0];
    }
    public void ChangePlayer(GameObject player)
    {
        currentPlayer.GetComponent<PlayerMovement>().enabled = false;
        currentPlayer.GetComponent<FireWeapon>().enabled = false;
        currentPlayer = player;
    }
}

