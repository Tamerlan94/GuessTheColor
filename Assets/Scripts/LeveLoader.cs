using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
  
    public void LoadBackLevel()
    {
        StartCoroutine(LoadLevel("Menu"));
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel("Game1"));
    }
    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }
}
