using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour {

    // Referencia al Audio Source
    public AudioSource audioSource;

    // Sonido de daño
    public AudioClip hitSFX;

    // Game Object referido al texto de derrota
    public GameObject gameOverTextPrefab;

    // Mostrar dicho Game Object
    public void ShowGameOverText() {
        GameObject gameOverText = Instantiate(gameOverTextPrefab);
        gameOverText.SetActive(true);
        gameOverText.transform.position = new Vector3(this.gameObject.transform.position.x,
                                                      this.gameObject.transform.position.y,
                                                      this.gameObject.transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Si el personaje se colisiona con el objeto,
        // el personaje desaparece
        if (collision.transform.CompareTag("Player")) {
            Debug.Log("Player Damaged");

            if (audioSource.isPlaying) {
                return;
            }

            // Ejecuta sonido de daño
            audioSource.PlayOneShot(hitSFX);

            // Elimina el objeto que colisiona (el jugador)
            Destroy(collision.gameObject);

            // Muestra mensaje de derrota por consola
            Debug.Log("GAME OVER");

            if (gameOverTextPrefab) {
                ShowGameOverText();
            }
        }
    }
}
