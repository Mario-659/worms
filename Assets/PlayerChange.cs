using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public TeamChange teamChange;
    public KeyCode keyCode;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(keyCode))
        {
            teamChange.ChangePlayer(this.gameObject);
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<FireWeapon>().enabled = true;
        }
    }
}
