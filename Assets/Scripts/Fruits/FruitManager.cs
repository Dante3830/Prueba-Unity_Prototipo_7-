using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class FruitManager : MonoBehaviour {

    private int apples = 30;
    public int Apples { get => apples; set => apples = value; }

    [SerializeField] private UnityEvent<int> OnApplesChanged;
    [SerializeField] public UnityEvent<string> OnTextChanged;

    // Referencia al texto de victoria
    [SerializeField] public TextMeshProUGUI victoryText;

    private void UpdateApplesCount() {
        OnApplesChanged.Invoke(Apples);
        OnTextChanged.Invoke(Apples.ToString());
    }

    // Si todas las frutas del nivel fueron recolectadas,
    // se muestra texto de victoria
    public void AllFruitsCollected() {
        if (transform.childCount <= 1) {

            Debug.Log("No apples left. VICTORY!");

            victoryText.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }
}