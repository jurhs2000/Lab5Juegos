using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {*/
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, Vector3.right, out hitInfo, 3))
            {
                Debug.DrawRay(transform.position, Vector3.right * 3, Color.red);
                if (hitInfo.collider.CompareTag("Point"))
                    Destroy(hitInfo.collider.gameObject);
            }
            else
            {
                Debug.DrawRay(transform.position, new Vector3(transform.eulerAngles.x,transform.eulerAngles.x,0), Color.green);
            }
        //}
    }
}
