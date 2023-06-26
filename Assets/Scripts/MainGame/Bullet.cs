using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrehab;
    public float life = 5f;
    
    private GameObject world;
    private Tilemap tilemap;
    public GameObject cameraControl;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Player")
            BlowUp();
    }

    void BlowUp()
    {
        GameObject explosion = Instantiate(explosionPrehab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        Destroy(explosion, 1f);
    }
}
