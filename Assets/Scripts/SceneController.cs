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

        // if (started) {
        //     timer += Time.deltaTime;
        // }

        // if (timer > 2.0f && timer <= 10.0f) {
        //     storyText1.enabled = true;
        // } else if (timer > 10.0f && timer <= 18.0f) {
        //     storyText1.enabled = false;
        //     storyText6.enabled = true;
        // } else if (timer > 26.0f && timer <= 34.0f) {
        //     storyText6.enabled = false;
        //     storyText5.enabled = true;
        // } else if (timer > 42.0f && timer <= 50.0f) {
        //     storyText5.enabled = false;
        //     storyText2.enabled = true;
        // } else if (timer > 58.0f && timer <= 66.0f) {
        //     storyText2.enabled = false;
        //     storyText3.enabled = true;
        // } else if (timer > 74.0f && timer <= 82.0f) {
        //     storyText3.enabled = false;
        //     storyText4.enabled = true;
        // } else if (timer > 90.0f) {
        //     storyText4.enabled = false;
        // }
        
    }

    public void resetGame() {
        SceneManager.LoadScene("MainGame");
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
