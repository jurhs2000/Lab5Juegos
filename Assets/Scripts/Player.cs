using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform gunEnd;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    public float fireRate = .25f;
    public float weaponRange = 50f;
    private Camera fpsCamera;
    public AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        fpsCamera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(lineOrigin, fpsCamera.transform.forward * weaponRange, Color.red);
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit, weaponRange)) {
                laserLine.SetPosition(1, hit.point);
            } else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCamera.transform.forward * weaponRange));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        //gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
