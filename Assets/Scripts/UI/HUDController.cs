using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour {

    // Referencia al texto para actualizar
    [SerializeField] TextMeshProUGUI appleCountText;

    // Actualizar texto de IU
    public void UpdateTextHUD(string numberText) {
        Debug.Log("SE LLAMA " + numberText);
        appleCountText.text = numberText;
    }

}
