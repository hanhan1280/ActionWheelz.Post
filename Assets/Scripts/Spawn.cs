/* File: Spawn
 * Description: instantiate prefabs by random time
 * written by Hanan Au 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour

{
    public GameObject[] obstacles;
    public GameObject coins;
    public GameObject[] AllObjects;
    public List<GameObject>[] gameObstacles;
    public GameObject ground;
    GameObject x;
    GameObject coinSp;

    RaycastHit hit;

    public Collider[] colliders;

    bool past = false;
    
    public float spawnX = 5.6f;
    
    public int spacing = 0;
    int randomNum;

    

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(obstacleSpawn());
        StartCoroutine(InstantCoin());
    }
    
    // Update is called once per frame
    void Update()
    {        
        checkSpawnpoint();
        OutofBounds();
    }

    private void Spawner()
    {
        spacing = 0;
        var z = transform.position.z;
        randomNum = Random.Range(0,obstacles.Length);
        Vector3 spawnpos;
        switch (randomNum)
        {
            case 0:
                spawnpos = new Vector3(-4, 0.4f, z);
                break;
            case 1:
                spawnpos = new Vector3(0, 3, z);
                break;
            case 3:
                spawnpos = new Vector3(Random.Range(0, 6f), 3, z);
                break;
            case 4:
                spawnpos = new Vector3(Random.Range(-6, -1.5f), 3, z);
                break;
            case 6:
                spawnpos = new Vector3(-2, 3, z);
                break;
            case 7:
                spawnpos = new Vector3(-6, 3, z);
                break;
            case 8:
                spawnpos = new Vector3(Random.Range(-6, 3), 3, z);
                break;
            case 9:
                spawnpos = new Vector3(Random.Range(-4, 4), 3, z);
                break;            
            case 10:
                spawnpos = new Vector3(0, 0.5f, z);
                break;            
            case 11:
                spacing = 1;
                spawnpos = new Vector3(-3.8f, 3, z + 6);
                break;
            case 12:
                spawnpos = new Vector3(-6.8f, 4, z);
                break;
            case 13:
                spacing = 1;
                spawnpos = new Vector3(-2f, 3, z + 4);
                break;
            default:
                spawnpos = new Vector3(Random.Range(-spawnX, spawnX), 3, z);
                break;
        }
        
        x = Instantiate(obstacles[randomNum]) as GameObject;
        x.transform.position = spawnpos;
        
    }

    void spawnCoins()
    {
        float coinPosX = Random.Range(-6.43f, 6.43f);
        Vector3 origin = new Vector3(coinPosX, transform.position.y, transform.position.z);
        float spacer = 0f;
        int coinRange = Random.Range(4, 10);        
        for (int i = 0; i < coinRange; i++)
        {                      
            coinSp = Instantiate(coins) as GameObject;
            coinSp.transform.position = new Vector3(coinPosX, 1.83f, transform.position.z + spacer);            
            spacer += 2f;            
        }        
    }

    private void OutofBounds()
    {
        AllObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject obstacle in AllObjects)
        {
            if(obstacle.transform.position.z < Camera.main.transform.position.z /2)
            {
                Destroy(obstacle);
            }
            else if(obstacle.transform.position.x > 7.5f || obstacle.transform.position.x < -7.5f)
            {
                Destroy(obstacle);
            }
        }
        foreach (GameObject coin in coins)
        {
            if(coin.transform.position.z < Camera.main.transform.position.z / 2) 
                {
                Destroy(coin);
                } 
        }
    }

    void checkSpawnpoint()
    {
        if (transform.position.z > 600)
        {           
            past = true;
        }        

    }

    IEnumerator obstacleSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f,1f) + spacing);
            if (past)
            {
                Spawner();
            }
            
        }            

        
    }
    IEnumerator InstantCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            if (past)
            {
                spawnCoins();
            }
            
        }
        
    }
  

}
