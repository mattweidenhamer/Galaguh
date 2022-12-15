using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneSwitcher : MonoBehaviour
{
    public void changeScene(string sceneName){
        Debug.Log("Changing scene");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
