using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningStory : MonoBehaviour
{
    void OnEnable(){
        SceneManager.LoadScene("MainGame", LoadSceneMode.Single);
    }
}
