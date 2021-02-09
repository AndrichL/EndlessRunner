using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager_Celine.instance.Waves <= 4)
        {
            GameManager_Celine.instance.timeBetweenSpawns = 5f;
            speed = 6;
        }
        else if (GameManager_Celine.instance.Waves > 4)
        {
            GameManager_Celine.instance.timeBetweenSpawns = 1f;
            speed = 12;
        }
       


        Vector3 move = new Vector3(-4f, 0);
        transform.position += move * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            Destroy(gameObject);
            ScoreManager_Celine.instance.AddScore();
        }

    }

}
