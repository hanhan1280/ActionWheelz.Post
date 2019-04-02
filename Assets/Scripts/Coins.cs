/* File: Coin
 * Description: collectable items and keeper
 * written by Hanan Au 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coins : MonoBehaviour
{
    public GameObject TextPrefab;
    public static int coinCount;
    public static bool collected = false;
    GameObject player;
    Vector3 transformPlayer;

    private void Start()
    {
        coinCount = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        transform.Rotate(0, 0, 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            
            collected = true;            
            coinCount += 1;
            showFloatingText();
            coinScore();
            gameObject.SetActive(false);
        }
        
    }


    public int coinScore()
    {        
        return coinCount;
    }

    public void showFloatingText()
    {
        var go = Instantiate(TextPrefab, player.transform.position, Quaternion.identity);
        
        go.GetComponent<TextMesh>().text = " + 5";        
       
        Destroy(gameObject, 3f);
    }
}
