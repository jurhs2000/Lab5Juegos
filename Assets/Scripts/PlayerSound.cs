using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip scream;
    private GameObject meeseeks;
    private bool isMeesWalk;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scream = Resources.Load<AudioClip>("scream");
        meeseeks = GameObject.Find("meeseeks");
        isMeesWalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMeesWalk)
        {
            meeseeks.transform.Translate(0,0,0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("scream") && !isMeesWalk)
        {
            audioSource.PlayOneShot(scream);
            isMeesWalk = true;
        }
    }
}
