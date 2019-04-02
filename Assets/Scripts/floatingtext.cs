using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingtext : MonoBehaviour
{
    float DestroyTime = 0.5f;
    Vector3 pos = new Vector3(0.5f, 0.1f, 10);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.position += pos;
    }

    // Update is called once per frame

}
