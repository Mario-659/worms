using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;  // Reference to the player's transform
    public TeamChange teamChange;
    public Vector3 offset = new Vector3(0f, 5f, -10f);  // Offset the camera's position
    void LateUpdate()
    {
        if(target != null)
            transform.position = target.position + offset;
    }
    public void FollowCurrentPlayer()
    {
        target = teamChange.getCurrentPlayer().GetComponent<Transform>();
    }
    public void FollowBullet()
    {
        target = GameObject.FindGameObjectWithTag ("Bullet").GetComponent<Transform>(); // ????????
    }
}
