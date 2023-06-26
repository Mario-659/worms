using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float life = 100f;
    
    public void damage(float damage)
    {
        life -= damage;
    }
    public bool isAlive()
    {
        return (life > 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Void")
        {
            life = 0;
        }
    }
}
