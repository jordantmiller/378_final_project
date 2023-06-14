using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    int buildIndex = 0;

    public void RestartGame(){
        SceneManager.LoadScene(buildIndex);
    }
}
