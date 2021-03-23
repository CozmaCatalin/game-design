using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoolDownBar : MonoBehaviour
{

    // Start is called before the first frame update
    private Slider slider;
    public float fillSpeedWhenNotCooling = 0.01f;
    public float fillSpeedWhenCooling = 0.01f;
    private float targetProgress = 0;
    public bool isCooling = false;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 1f;
    }
    void Start()
    {
        IncrementProgress(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0f)
        {
            isCooling = true;
        }

        if(slider.value < targetProgress)
        {
            if (isCooling)
            {
                slider.value += fillSpeedWhenCooling * Time.deltaTime;
            } else
            {
                slider.value += fillSpeedWhenNotCooling * Time.deltaTime;

            }
            if (isCooling == true && slider.value == 1f)
            {
                isCooling = false;
            }
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
