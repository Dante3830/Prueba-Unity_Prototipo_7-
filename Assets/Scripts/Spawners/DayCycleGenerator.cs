using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleGenerator : MonoBehaviour {

    [SerializeField] public Camera _camera;
    [SerializeField] public Color NightColor;
    // Por alguna razón, no puedo llamar a Light2D
    //[SerializeField] public Light light2d;

    [SerializeField] [Range(4, 128)] public int DayDuration;
    [SerializeField] [Range(4, 24)] public int Days;

    private Color DayColor;

    // Inicializa la rutina con el color de día
    void Start() {
        DayColor = _camera.backgroundColor;
        StartCoroutine(ChangeColor(DayDuration));
    }
    
    // Update is called once per frame
    IEnumerator ChangeColor(float time) {
        Color ColorDestinyBackground = _camera.backgroundColor == DayColor ? NightColor : DayColor;
        //Color ColorDestinyLight = light2d.color != Color.white ? Color.white : NightColor;
        float CycleDuration = time * 0.6f;
        float ChangeDuration = time * 0.4f;

        for (int i = 0; i < Days; i++) {
            yield return new WaitForSeconds(DayDuration);

            float ElapsedTime = 0f;

            while (ElapsedTime < ChangeDuration) {
                ElapsedTime += Time.deltaTime;
                float t = ElapsedTime / ChangeDuration;

                float smoothT = Mathf.SmoothStep(0f, 1f, t);

                _camera.backgroundColor = Color.Lerp(_camera.backgroundColor, ColorDestinyBackground, smoothT);
                //light2d.color = Color.Lerp(light2d.color, ColorDestinyLight, smoothT);

                yield return null;
            }

            ColorDestinyBackground = _camera.backgroundColor == DayColor ? NightColor : DayColor;
            //ColorDestinyLight = light2d.color != Color.white ? Color.white : NightColor;
        }
    }
}
