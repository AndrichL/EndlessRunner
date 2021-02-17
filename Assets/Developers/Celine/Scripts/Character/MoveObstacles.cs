using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Vector2 speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Spawn/speed changes 
        //if (GameManager_Celine.instance.Waves <= 4)
        //{
        //    GameManager_Celine.instance.timeBetweenSpawns = 5f;
        //}
        //else if (GameManager_Celine.instance.Waves > 4)
        //{
        //    GameManager_Celine.instance.timeBetweenSpawns = 3f;
        //}
        //else if (GameManager_Celine.instance.Waves > 6)
        //{
        //    GameManager_Celine.instance.timeBetweenSpawns = 1f;
        //}
       
        //Move the obstacles to the right
        rb2d.velocity = speed;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If they move into the death bordor, the obstacle gets deleted
        if (collision.tag == "Death")
        {
            SimplePool.PoolItem.ReturnToPoolOrDestroy(gameObject, GameManager_Celine.instance.useObjectPool = true);
        }

    }

}
