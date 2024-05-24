using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public ButtonManager buttonManager;

    public void NewScene(int i)
    {
        if(i == 1)
        {
            buttonManager.ExitMenu();
            
            StartCoroutine(ChangeSceneWithDelay(i));
        }
        else
        {
            SceneManager.LoadScene(i);
        }
    }

    public void NewScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    IEnumerator ChangeSceneWithDelay(int j)
    {
        yield return new WaitForSeconds(.7f);

        SceneManager.LoadScene(j);
    }
}
