using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider = GetComponent<Slider>();
        Debug.Log(slider.value);
        FindObjectOfType<AudioManager>().setVolume("back", slider.value);
    }

}
