using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private int bullet = 5;
    public Animator gunAnimator;
    // Start is called before the first frame update
    void Start()
    {
        gunAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gunAnimator.Play("Shoot");
            bullet--;
            if (bullet == 0)
            {
                gunAnimator.Play("Reload");
                bullet = 5;
            }
        }
    }
}
