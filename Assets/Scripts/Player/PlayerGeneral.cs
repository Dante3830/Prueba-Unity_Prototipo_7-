using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneral : MonoBehaviour {

    private IMoveLeft moveLeft;
    private IMoveRight moveRight;
    private IStill still;
    private IJumping jumping;

    // Referencia al Player Profile
    public PlayerProfile playerProfile;

    private void Start() {
        // Inicia los movimientos del personaje
        moveLeft = GetComponent<IMoveLeft>();
        moveRight = GetComponent<IMoveRight>();
        still = GetComponent<IStill>();
        jumping = GetComponent<IJumping>();

        // Inicia la Experience en 0 y el Level en 1
        if (playerProfile != null) {
            playerProfile.Experience = 0;
            playerProfile.Level = 1;
            Debug.Log("Player Profile is not null. Experience: " + playerProfile.Experience);
        } else {
            Debug.LogWarning("Player Profile is null. Make sure to assign it in the Unity Editor.");
        }
    }

    // Presta atención a las teclas
    private void FixedUpdate() {
 
        if ((Input.GetKey("a")) || Input.GetKey("left")) {
            moveLeft.MoveLeft();
        }
        else if ((Input.GetKey("d")) || Input.GetKey("right")) {
            moveRight.MoveRight();
        }
        else {
            still.StayStill();
        }

        if ((Input.GetKey("space") || Input.GetKey("up")) && CheckGround.isGrounded) {
            jumping.Jump();
        }
    }

}
