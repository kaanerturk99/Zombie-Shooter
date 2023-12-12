using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame(){
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad(2,3));
    }

    public void QuitGame(){
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndex, float delay){
        yield return new  WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }
}
