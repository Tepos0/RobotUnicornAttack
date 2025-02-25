using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public IEnumerator LoadScenWithDelay (string sceneName , float delay = 0f) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds (delay);
    }

    public void LoadScene (string sceneName) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
    }



}
