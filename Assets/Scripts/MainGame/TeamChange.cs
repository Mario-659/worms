using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamChange : MonoBehaviour
{
    public GameObject[] wormsArray;
    private List<GameObject> teamBlue;
    private List<GameObject> teamRed;
    [SerializeField]
    GameObject currentPlayer;
    int currentTeam; // even - teamBlue, odd - teamRed. Dla prostoty pracy lepszy byłby tu pointer na jeden z teamów ale nie wiem czy chce mi się z tym w c# jebać    
    public int nextWormTeamBlue;
    public int nextWormTeamRed;
    public GameObject cameraControl;
    public int turnDelay = 2;
    void Start()
    {
        teamBlue = new List<GameObject>();
        teamRed = new List<GameObject>();
        nextWormTeamBlue = 0;
        nextWormTeamRed = 0;
        currentTeam = -1;
        int wormsCount = wormsArray.Length;
        for(int i = 0; i < wormsCount/2; i++)
        {
            wormsArray[i].GetComponent<PlayerMovement>().enabled = false;
            wormsArray[i].GetComponent<FireWeapon>().enabled = false;
            teamBlue.Insert(i, wormsArray[i]);
        }
        for(int i = wormsCount/2, j = 0; i < wormsCount; i++, j++)
        {
            wormsArray[i].GetComponent<PlayerMovement>().enabled = false;
            wormsArray[i].GetComponent<FireWeapon>().enabled = false;
            teamRed.Insert(j, wormsArray[i]);
        }             
        ChangeTeam();
    }
    void LateUpdate()
    {
        if(Input.GetMouseButtonUp(0))
        {
            cameraControl.GetComponent<CameraFollow>().FollowBullet();
            Invoke("ChangeTeam", turnDelay);
        }
        if(!currentPlayer.GetComponent<PlayerState>().isAlive())
        {
            GameObject deadPlayer = currentPlayer;
            ChangeTeam();
            PlayerDeath(deadPlayer);
        }
        foreach(GameObject worm in teamBlue)
        {
            if(!worm.GetComponent<PlayerState>().isAlive())
            {
                PlayerDeath(worm);
                break;
            }
        }
        foreach(GameObject worm in teamRed)
        {
            if(!worm.GetComponent<PlayerState>().isAlive())
            {
                PlayerDeath(worm);
                break;
            }
        }
    }
    public void PlayerDeath(GameObject deadPlayer)
    {
        teamBlue.Remove(deadPlayer);
        teamRed.Remove(deadPlayer);
        if(teamBlue.Count == 0 || teamRed.Count == 0)
            GameEnd();        
        Destroy(deadPlayer);
        FixTeams();
    }
    public void GameEnd()
    {
        if(teamBlue.Count == 0)
        {
            SceneManager.LoadScene(2);
        }
        if(teamRed.Count == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    public void FixTeams()
    {
        if(nextWormTeamBlue >= teamBlue.Count) nextWormTeamBlue = 0;
        if(nextWormTeamRed >= teamRed.Count) nextWormTeamRed = 0;
    }
    public void ChangeTeam()
    {
        currentTeam++;
        if(currentTeam%2 == 0)
        {
            ChangePlayer(teamBlue[nextWormTeamBlue]);
            nextWormTeamBlue++;
        }
        else
        {
            ChangePlayer(teamRed[nextWormTeamRed]);
            nextWormTeamRed++;
        }
        FixTeams();
        cameraControl.GetComponent<CameraFollow>().FollowCurrentPlayer();
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

