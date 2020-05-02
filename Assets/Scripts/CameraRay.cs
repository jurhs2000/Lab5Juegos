using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public int bullets = 5;
    public int targets = 0;
    public AudioSource gunAudio;
    public AudioClip shootSound;
    public AudioClip targetSoundSFX;

    // Start is called before the first frame update
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
        shootSound = Resources.Load<AudioClip>("gunSound");
        gunAudio.clip = shootSound;
        targetSoundSFX = Resources.Load<AudioClip>("target-hit-sfx");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        //Debug.DrawRay(lineOrigin, transform.forward * 50f, Color.green);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            gunAudio.Play();
            bullets--;
            Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(rayOrigin, transform.forward, out hitInfo, 50f))
            {
                if (hitInfo.collider.CompareTag("Target"))
                {
                    Destroy(hitInfo.collider.gameObject);
                    targets++;
                    gunAudio.PlayOneShot(targetSoundSFX);
                }
            }
            if (bullets == 0)
            {
                bullets = 10;
            }
        }
    }
}
