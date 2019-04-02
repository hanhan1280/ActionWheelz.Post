using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveX : MonoBehaviour
{
    public float translate = 1f;
    public float speed;

    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 endPos2;

    public bool check;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(translate, 0, 0);
        endPos2 = startPos - new Vector3(translate, 0, 0);
    }

    private void Update()
    {
        if (check)
        {
            transform.position = Vector3.Lerp(endPos2, endPos, Mathf.PingPong(Time.time * speed, 1));
        }
        else
        {
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * speed, 1));
        }
    }
    
}
