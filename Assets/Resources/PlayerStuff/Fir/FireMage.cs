using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMage : MonoBehaviour
{

    private float lavaTimer;
    private float lavaCooldown;
    public GameObject lava;
    private GameObject bomba;

    public GameObject flames;

    private PlayerController player;

    private float shotTimer;

    // Start is called before the first frame update
    void OnEnable()
    {
        bomba = Resources.Load("PlayerStuff/Fir/Bomba") as GameObject;
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Special"))
        {
            if (lavaCooldown <= 0)
            {
                lava.SetActive(true);

                lavaCooldown = 2;
                lavaTimer = 0.2f;
            }
        }

        if (lavaCooldown >= 0)
        {
            lavaCooldown -= Time.deltaTime;
        }

        if (lava.activeSelf)
        {
            if (lavaTimer <= 0)
            {
                lava.SetActive(false);
            }
            else
            {
                lavaTimer -= Time.deltaTime;
            }
            
        }


        if (Input.GetButtonDown("Fire1"))
        {
            if (shotTimer <= 0)
            {
                Instantiate(bomba, gameObject.transform);
                shotTimer = 0.8f;
            }
        }

        if (shotTimer >= 0)
        {
            shotTimer -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Ultimate") && player.hasUlt())
        {
            Instantiate(flames, gameObject.transform);
            player.updateUlt();
        }
    }
}
