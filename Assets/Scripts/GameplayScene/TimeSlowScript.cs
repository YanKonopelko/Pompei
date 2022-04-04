using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlowScript : MonoBehaviour
{
    public float howLongTimeToSlow = 10f;
    public float slowCoeff = 0.5f;

    public Image slider;

    private float timer = 0f;

    private void Start()
    {
        timer = howLongTimeToSlow;
    }

    private void Update()
    {
        slider.fillAmount = timer / howLongTimeToSlow;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (timer > 0)
                Time.timeScale = slowCoeff;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (timer > 0)
                timer -= Time.deltaTime / Time.timeScale;
            if (timer <= 0 && Time.timeScale == slowCoeff)
                Time.timeScale = 1f;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            Time.timeScale = 1f;
        }

#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.E))
        {
            timer = howLongTimeToSlow;
        }
#endif
    }
}
