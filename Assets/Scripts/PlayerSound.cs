using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{

    private Rigidbody m_CharacterController;
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.
    private float m_StepCycle;
    private float m_NextStep;
    private bool m_PreviouslyGrounded;

    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = GetComponent<Rigidbody>();
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle / 2f;
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!m_PreviouslyGrounded && m_CharacterController)
        {
            PlayLandingSound();
        }
    }

    private void FixedUpdate()
    {
        ProgressStepCycle();
    }

    private void ProgressStepCycle()
    {
        PlayFootStepAudio();
    }

    private void PlayLandingSound()
    {
        m_AudioSource.clip = m_LandSound;
        m_AudioSource.Play();
        m_NextStep = m_StepCycle + .5f;
    }

    private void PlayFootStepAudio()
    {
        if (!m_CharacterController)
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
