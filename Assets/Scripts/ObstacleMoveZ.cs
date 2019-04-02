using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveZ : MonoBehaviour
{
    public float translate;
    public float speed;
    public bool check;

    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 endPos2;

    

    private void Start()
    {        
        startPos = transform.position;
        endPos = startPos + new Vector3(0, 0, translate);
        endPos2 = startPos - new Vector3(0, 0, translate);
    }

    private void Update()
    {
      
        transform.position = Vector3.Lerp(endPos2, endPos, Mathf.PingPong(Time.time * speed, 1));
    }
    
}
