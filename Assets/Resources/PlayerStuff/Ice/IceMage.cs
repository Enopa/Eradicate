using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMage : MonoBehaviour
{
    public GameObject icicle;
    public GameObject iceMine;
    public GameObject blizzard;

    private float iceCooldown;
    private float mineCooldown;

    private PlayerController player;

    // Start is called before the first frame update
    void OnEnable()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (iceCooldown <= 0)
            {
                Instantiate(icicle, gameObject.transform);
                iceCooldown = .5f;
            }
        }
        if (iceCooldown >= 0)
        {
            iceCooldown -= Time.deltaTime;        
        }

        if (Input.GetButtonDown("Special"))
        {
            if (mineCooldown <= 0)
            {
                Instantiate(iceMine, gameObject.transform);
                iceMine.transform.parent = null;
                mineCooldown = 1.5f;
            }
        }
        if (mineCooldown >= 0)
        {
           mineCooldown -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Ultimate") && player.hasUlt())
        {
            player.updateUlt();
            Instantiate(blizzard, gameObject.transform);
        }
    }
}
