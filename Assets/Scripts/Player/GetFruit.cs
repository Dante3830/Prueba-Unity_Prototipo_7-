using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFruit : MonoBehaviour {

    // Referencia al Player Profile
    public PlayerProfile playerProfile;

    // Referencia al Player Audio
    private ICollision collision;

    // Llamando al sistema de progresión
    private Progression progressionPlayer;

    // Iniciar componente del sonido de colisión
    private void Start() {
        collision = GetComponent<ICollision>();
    }

    // Despertar el componente de progresión
    private void Awake() {
        progressionPlayer = GetComponent<Progression>();
    }

    // Detecta la colisión entre el objeto y el jugador
    private void OnTriggerEnter2D(Collider2D collider) {
        // Si hay colision con una manzana,
        // el Sprite Renderer de la manzana se desactiva
        if (collider.CompareTag("Fruit")) {

            // Ejecuta sonido de colisión
            collision.PlayCollision();

            // Agrega experiencia ganada
            progressionPlayer.WinExperience(playerProfile.ExpScale);

            Debug.Log("Experience: " + playerProfile.Experience);

            Debug.Log("Level: " + playerProfile.Level);
        }
    }
}
