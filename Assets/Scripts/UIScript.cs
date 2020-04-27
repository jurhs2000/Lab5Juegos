using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private CameraRay cameraRay;
    private Text targets_text;
    // Start is called before the first frame update
    void Start()
    {
        cameraRay = FindObjectOfType(typeof(CameraRay)) as CameraRay;
        targets_text = GetComponentInChildren<Text>();
    }

    private void FixedUpdate()
    {
        targets_text.text = "Targets: " + cameraRay.targets;
    }
}
