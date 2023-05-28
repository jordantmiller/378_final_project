using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbar;
    public float damageMultiplier = 1.0f;
    public SceneController sc;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        sc = FindObjectsOfType<SceneController>()[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            sc.resetGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Finish")) {
            float damage = other.relativeVelocity.magnitude * damageMultiplier;
            TakeDamage((int)damage);
            if (audioSource.isPlaying) {
                audioSource.Stop();
            }

            audioSource.Play();

        }
    }

}
