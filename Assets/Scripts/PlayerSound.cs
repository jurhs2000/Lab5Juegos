using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    private CharacterController m_CharacterController;
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ProgressStepCycle();
    }

    private void ProgressStepCycle()
    {
        PlayFootStepAudio();
    }


    private void PlayFootStepAudio()
    {
        if (!m_CharacterController.isGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }

}
