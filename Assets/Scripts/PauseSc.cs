using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSc : MonoBehaviour
{
    private bool isActive;
    private GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isActive)
            {
                pauseScreen.SetActive(false);
                isActive = false;
                Time.timeScale = 1;
                Cursor.visible = false;
                Screen.lockCursor = true;
                CharacterController cc = FindObjectOfType<CharacterController>();
                if (cc)
                    cc.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            }
            else
            {
                pauseScreen.SetActive(true);
                isActive = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Screen.lockCursor = false;
                CharacterController cc = FindObjectOfType<CharacterController>();
                if (cc)
                    cc.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            }
        }
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        isActive = false;
        Time.timeScale = 1;
    }
}
