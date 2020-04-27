using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointerRay : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
    }


    GameObject sponge = null;
    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hitInfo;
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hitInfo, 50f))
        {
            if (hitInfo.collider.CompareTag("sponge"))
            {
                hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                sponge = hitInfo.collider.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                    var hitPoint = myRay.GetPoint(500f);
                    var mouseDir = hitPoint - gameObject.transform.position;
                    mouseDir = mouseDir.normalized;
                    sponge.GetComponent<Rigidbody>().AddForce(mouseDir * 500);
                }
            } else
            {
                if (sponge.gameObject.name.Contains("Cube"))
                    sponge.GetComponent<Renderer>().material = Resources.Load("Pink", typeof(Material)) as Material;
                if (sponge.gameObject.name.Contains("Sphere"))
                    sponge.GetComponent<Renderer>().material = Resources.Load("Yellow", typeof(Material)) as Material;
            }
        }

    }
}
