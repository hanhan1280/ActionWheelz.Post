using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFade : MonoBehaviour
{

    public Animator animator;
    // Update is called once per frame
    public void CamTo()
    {
        FindObjectOfType<CameraBackground>().selectCamera(true);
    }
}
