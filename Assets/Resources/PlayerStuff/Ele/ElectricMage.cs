using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricMage : MonoBehaviour
{

    private PlayerController player;
    private Rigidbody2D body;
    public GameObject elecHB;
    public GameObject discharge;

    public float dashTime;
    private float dashTimer;
    private float dashCountdown;
    public float dashCooldown;
    public float dashForce;
    private bool dashing = false;
    private float ultTimer;

    // Start is called before the first frame update
    void OnEnable()
    {
        body = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            elecHB.SetActive(true);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            elecHB.SetActive(false);
        }

        if (Input.GetButtonDown("Special"))
        {
            if (dashCountdown <= 0)
            {
                player.speed *= 10;
                dashCountdown = dashCooldown;
                dashing = true;
                dashTimer = dashTime;
            }
        }

        if (dashing)
        {
            dashTimer -= Time.deltaTime;
        }

        if ((dashTimer <= 0) && (dashing)) 
        {
            //body.velocity = controller.movePos * controller.speed;
            player.speed /= 10;
            dashing = false;
        }

        
        if (!(dashCountdown <= 0))
        {
            dashCountdown -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Ultimate") && player.hasUlt() && !discharge.activeSelf)
        {
            discharge.SetActive(true);
            player.updateUlt();
            ultTimer = .5f;
        }

        if (discharge.activeSelf)
        {
            if (ultTimer >= 0)
            {
                ultTimer -= Time.deltaTime;
            }
            else
            {
                discharge.SetActive(false);
            }
            
        }
    }
}
