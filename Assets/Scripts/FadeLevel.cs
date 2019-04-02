/* File: FadeLevel
 * Description: scene manager using fade transition by changing alpha component to panel
 * written by Hanan Au 
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeLevel : MonoBehaviour
{
    public Animator animator;
    
    
    private static int levelToLoad;

    public void PlayGame()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);        
    }

    public void Restart()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
