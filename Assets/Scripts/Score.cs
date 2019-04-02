/* File: Score
 * Description: Keep Score By Position
 * written by Hanan Au 
 */
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {        
        scoreText.text = player.position.z.ToString("0");  
    }
    
    
}

