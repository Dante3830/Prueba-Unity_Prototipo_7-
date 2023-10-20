using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour {

    // Referencia al texto de derrota 
    [SerializeField] public TextMeshProUGUI defeatText;

    // Referencia al Audio Source
    public AudioSource audioSource;

    // Sonido de daño
    public AudioClip hurtSFX;

    void Start() {
        Invoke("DisableObject", 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Si el personaje se colisiona con el enemigo,
        // el personaje desaparece
        if (collision.transform.CompareTag("Player")) {
            Debug.Log("Player Damaged. GAME OVER");

            // Elimina el objeto que colisiona (el jugador)
            Destroy(collision.gameObject);

            if (audioSource.isPlaying) {
                return;
            }

            audioSource.PlayOneShot(hurtSFX);

            defeatText.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }

    private void DisableObject () {
        gameObject.SetActive(false);
    }
}
