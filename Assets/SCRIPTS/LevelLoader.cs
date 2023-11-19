using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneLoader : MonoBehaviour
{

    public Animator transition1, transition2;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadMainMenuFromTutorial()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
    }

    public void LoadMainMenuLevel1()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 3));
    }

    public void LoadMainMenuLevel2()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 4));
    }

    public void LoadMainMenuLevel3()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 5));
    }

    public void LoadMainMenuBossLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 6));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition1.SetTrigger("Start");
        transition2.SetTrigger("Start2");

        yield return new WaitForSeconds(transitionTime);
            
        SceneManager.LoadScene(levelIndex);
    }
}
