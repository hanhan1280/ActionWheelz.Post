using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMoveY : MonoBehaviour
{
    public float translate = 1f;
    public float speed;

    public Vector3 startPos;
    public Vector3 endPos;

    private void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, translate, 0);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(startPos, endPos, Mathf.PingPong(Time.time * speed, 1));
    }   


}
