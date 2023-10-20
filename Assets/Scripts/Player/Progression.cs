using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour {

    // Referncia al Player Profile
    [SerializeField] private PlayerProfile playerProfile;
    public PlayerProfile PlayerProfile { get => playerProfile; set => playerProfile = value; }

    // Suma la experiencia ganada
    public void WinExperience(int newExp) {
        // Averigua si Player Profile es null
        if (playerProfile == null) {
            Debug.LogError("Player Profile is null. Cannot win experience.");
            return;
        }

        playerProfile.Experience += newExp;

        if (playerProfile.Experience >= playerProfile.ExpNextLevel) {
            LevelUp();
        }
    }

    // Sube al siguente nivel
    private void LevelUp() {
        // Averigua si Player Profile es null
        if (playerProfile == null) {
            Debug.LogError("Player Profile is null. Cannot level up.");
            return;
        }

        playerProfile.Level++;
        playerProfile.Experience -= playerProfile.ExpNextLevel;
        playerProfile.ExpNextLevel += playerProfile.ExpScale;

        // Ensure experience is non-negative
        playerProfile.Experience = Mathf.Max(playerProfile.Experience, 0);

        // Ensure level is non-negative
        playerProfile.Level = Mathf.Max(playerProfile.Level, 0);
    }
}