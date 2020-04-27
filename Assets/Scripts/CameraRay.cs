using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, transform.forward * 50f, Color.green);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(rayOrigin, transform.forward, out hitInfo, 50f))
            {
                if (hitInfo.collider.CompareTag("Target"))
                    Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}
