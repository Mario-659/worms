using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamChange : MonoBehaviour
{
    public GameObject[] teamBlue;
    public GameObject[] teamRed;
    [SerializeField]
    GameObject currentPlayer;
    int currentTeam; // even - teamBlue, odd - teamRed
    int nextWormTeamBlue;
    int nextWormTeamRed;
    void Start()
    {
        nextWormTeamBlue = 0;
        nextWormTeamRed = 0;
        currentTeam = -1;
        for(int i = 1; i < teamBlue.Length; i++)
        {
            teamBlue[i].GetComponent<PlayerMovement>().enabled = false;
            teamBlue[i].GetComponent<FireWeapon>().enabled = false;
        }
        for(int i = 1; i < teamRed.Length; i++)
        {
            teamRed[i].GetComponent<PlayerMovement>().enabled = false;
            teamRed[i].GetComponent<FireWeapon>().enabled = false;
        }             
        ChangeTeam();
    }
    void LateUpdate()
    {
        if(Input.GetMouseButtonUp(0))
        {
            ChangeTeam();
        }
    }
    public void ChangeTeam()
    {
        currentTeam++;
        if(currentTeam%2 == 0)
        {
            ChangePlayer(teamBlue[nextWormTeamBlue]);
            nextWormTeamBlue++;
            if(nextWormTeamBlue >= teamBlue.Length) nextWormTeamBlue = 0;
        }
        else
        {
            ChangePlayer(teamRed[nextWormTeamRed]);
            nextWormTeamRed++;
            if(nextWormTeamRed >= teamRed.Length) nextWormTeamRed = 0;
        }
    }
    public void ChangePlayer(GameObject player)
    {
        currentPlayer.GetComponent<PlayerMovement>().enabled = false;
        currentPlayer.GetComponent<FireWeapon>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<FireWeapon>().enabled = true;
        currentPlayer = player;
    }
    public GameObject getCurrentPlayer()
    {
        return currentPlayer;
    }
}

