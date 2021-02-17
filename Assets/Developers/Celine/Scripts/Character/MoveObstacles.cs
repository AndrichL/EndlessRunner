using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{

    public int speed;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawn/speed changes 
        if (GameManager_Celine.instance.Waves <= 4)
        {
            GameManager_Celine.instance.timeBetweenSpawns = 5f;
            speed = 2 + Random.Range(2, 10);
        }
        else if (GameManager_Celine.instance.Waves > 4)
        {
            GameManager_Celine.instance.timeBetweenSpawns = 1f;
            speed = 4 + Random.Range(2, 10);
        }
       
        //Move the obstacles to the right
        Vector3 move = new Vector3(-4f, 0);
        transform.position += move * speed * Time.deltaTime;

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
