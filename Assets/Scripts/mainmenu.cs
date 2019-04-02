using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public int PlayGame()
    {
        return SceneManager.GetActiveScene().buildIndex + 1;
    }
}
