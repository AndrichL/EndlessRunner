using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Celine : MonoBehaviour
{
    public float timer = 0f;
    public float timeBetweenSpawns;

    public GameObject randomObject;
    public GameObject randomObject1;
    public GameObject randomObject2;
    public GameObject randomObject3;

    public int Obstacles;
    public int Waves = 0;

    public Transform spawnY;
    public Transform spawnY2;

    public static GameManager_Celine instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    private void Spawn()
    {
       

        //If all the obstacles are not spawned yet, spawn that amount of obstacles
        for (int i = 0; i < Obstacles; i++)
        {   
            //Take 2 tranforms and make a random range out of that
            Vector3 randomPos = new Vector3(spawnY.position.x, (Random.Range(spawnY.position.y, spawnY2.position.y)));
            
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);

            int randomNum = Random.Range(1, 4);

            //spawn the obstacles
            if(randomNum == 1)
                Instantiate(randomObject, randomPos, spawnRotation);
            if(randomNum == 2)
                Instantiate(randomObject1, randomPos, spawnRotation);
            if (randomNum == 3)
                Instantiate(randomObject2, randomPos, spawnRotation);
            if (randomNum == 4)
                Instantiate(randomObject3, randomPos, spawnRotation);
        }
        Waves++;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1f * Time.deltaTime;

        if (timer >= timeBetweenSpawns)
        {
            timer = 0;
            Spawn();
        }
    }
}
