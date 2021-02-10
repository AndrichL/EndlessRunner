using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimplePool;

public class GameManager_Celine : MonoBehaviour
{
    public float timer = 0f;
    public float timeBetweenSpawns;


    [Header("Obstacles")]
    public GameObject randomObject1;
    public GameObject randomObject2;
    public GameObject randomObject3;
    public GameObject randomObject4;
    public bool useObjectPool = true;

    public int Obstacles;
    public int Waves = 0;

    public Transform spawn;
    public Transform spawn2;

    SimplePool.ObjectPool obstaclePool1;
    SimplePool.ObjectPool obstaclePool2;
    SimplePool.ObjectPool obstaclePool3;
    SimplePool.ObjectPool obstaclePool4;

    public static GameManager_Celine instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        obstaclePool1 = gameObject.AddComponent<SimplePool.ObjectPool>() as ObjectPool;
        obstaclePool1.pooledObject = randomObject1;
        obstaclePool1.autoExpand = true;   
        
        obstaclePool2 = gameObject.AddComponent<SimplePool.ObjectPool>() as ObjectPool;
        obstaclePool2.pooledObject = randomObject2;
        obstaclePool2.autoExpand = true;   
       
        obstaclePool3 = gameObject.AddComponent<SimplePool.ObjectPool>() as ObjectPool;
        obstaclePool3.pooledObject = randomObject3;
        obstaclePool3.autoExpand = true;    
        
        obstaclePool4 = gameObject.AddComponent<SimplePool.ObjectPool>() as ObjectPool;
        obstaclePool4.pooledObject = randomObject4;
        obstaclePool4.autoExpand = true;

    }

    private void Spawn()
    {
        //If all the obstacles are not spawned yet, spawn that amount of obstacles
        for (int i = 0; i < Obstacles; i++)
        {   
            //Take 2 tranforms and make a random range out of that
            Vector3 randomPos = new Vector3(Random.Range(spawn.position.x, spawn2.position.x), (Random.Range(spawn.position.y, spawn2.position.y)));
            
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 180);

            int randomNum = Random.Range(1, 4);

            //spawn the obstacles
            if (randomNum == 1)
                obstaclePool1.GetPooledObject(randomPos, spawnRotation);
            if(randomNum == 2)
                obstaclePool2.GetPooledObject(randomPos, spawnRotation);
            if (randomNum == 3)
                obstaclePool3.GetPooledObject(randomPos, spawnRotation);
            if (randomNum == 4)
                obstaclePool4.GetPooledObject(randomPos, spawnRotation);
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
