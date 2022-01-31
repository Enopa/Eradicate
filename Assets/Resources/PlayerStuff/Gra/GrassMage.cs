using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMage : MonoBehaviour
{

    public GameObject slash;
    public GameObject bigSlash;
    private PlayerController player;
    private Rigidbody2D body;
    public GameObject ultSlash;

    private float slashTimer;

    private float bigTimer;

    private float ultTimer;


    // Start is called before the first frame update
    void OnEnable()
    {
        player = GetComponent<PlayerController>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButton("Fire1")) && !slash.activeSelf)
        {
            if (slashTimer <= 0)
            {
                slash.SetActive(true);
                slashTimer = .5f;
            }
        }

        if (slashTimer >= 0)
        {
            slashTimer -= Time.deltaTime;
        }

        if (slashTimer <= .25f)
        {
            slash.SetActive(false);
        }


        if (Input.GetButtonDown("Special"))
        {
            if (bigTimer <= 0)
            {
                bigSlash.SetActive(true);
                bigTimer = 3;
            }
        }

        if (bigTimer >= 0)
        {
            bigTimer -= Time.deltaTime;
        }

        if (bigTimer <= 2.5f)
        {
            bigSlash.SetActive(false);
        }


        if (player.hasUlt() && Input.GetButtonDown("Ultimate") && !ultSlash.activeSelf)
        {
            player.updateUlt();
            ultTimer = 0.25f;
            player.speed *= 2;
            ultSlash.SetActive(true);
        }

        if (ultTimer >= 0)
        {
            ultTimer -= Time.deltaTime;
        }
        else if (ultSlash.activeSelf)
        {
            ultSlash.SetActive(false);
            player.speed /= 2;

        }
    }
}
