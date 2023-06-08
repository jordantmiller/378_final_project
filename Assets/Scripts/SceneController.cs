using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public TextMeshProUGUI controlText;
    public TextMeshProUGUI creditText;
    public Button startButton;
    public Button controlsButton;
    public Button creditsButton;
    public Button quitButton;
    public Rigidbody2D playerRb;
    private SceneController sc;
    private PlayerMovementScript pm;
    private float timer;
    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        controlText.enabled = false;
        creditText.enabled = false;
        startButton.onClick.AddListener(OnStartClick);
        controlsButton.onClick.AddListener(OnControlClick);
        creditsButton.onClick.AddListener(OnCreditClick);
        quitButton.onClick.AddListener(OnStartClick);
        timer = 0f;
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            resetGame();
        }        
    }

    public void resetGame() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
    public void winScreen() {
        this.playerRb.velocity = Vector2.zero;
        this.playerRb.angularVelocity = 0;
    }
    private void OnStartClick() {
        pm = FindObjectsOfType<PlayerMovementScript>()[0];
        //playerRb.position = new Vector2(60, 10);
        pm.enableControls(true);
        controlsButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);
        started = true;
        controlText.enabled = creditText.enabled = false;
    }

    private void OnControlClick() {
        controlText.enabled = !controlText.enabled;
    }

    private void OnCreditClick() {
        creditText.enabled = !creditText.enabled;
    }
}
