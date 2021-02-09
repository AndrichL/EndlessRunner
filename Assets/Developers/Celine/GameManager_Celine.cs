using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Celine : MonoBehaviour
{
    public float timer = 0f;

    public GameObject randomObject;
    public GameObject spawnPosObject;
    public int Obstacles;
    public Transform spawnY;
    public Transform spawnY2;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Spawn()
    {
       

        //If all the obstacles are not spawned yet, spawn that amount of obstacles
        for (int i = 0; i < Obstacles; i++)
        {   

            float randomnum = Random.Range(1f, 20f);
            Vector3 randomPos = new Vector3(spawnY.position.x, (Random.Range(spawnY.position.y, spawnY2.position.y)));
            
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);

            if (randomnum < 10)
            {
                Instantiate(randomObject, randomPos, spawnRotation);
            }
        

        }
    }

    // Update is called once per frame
    void Update()
    {
      

        timer += 1f * Time.deltaTime;

        if (timer >= 5)
        {
            timer = 0;
            Spawn();
        }

        
    }
}
