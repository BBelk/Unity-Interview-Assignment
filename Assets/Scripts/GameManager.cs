using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;
    public void LoadScene(int sceneIndex){
        SceneManager.LoadScene(sceneIndex);
    }
}
