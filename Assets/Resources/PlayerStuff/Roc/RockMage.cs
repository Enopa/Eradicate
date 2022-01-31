using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMage : MonoBehaviour
{

    public GameObject point;
    public GameObject rock;
    public GameObject wall;
    public GameObject ultWall;

    private PlayerController player;

    private int rockCounter;
    private bool isShooting;
    private float rockCooldown;
    private float rockBuffer;

    private float wallCooldown;

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
            if (rockCooldown <= 0 && !isShooting)
            {
                isShooting = true;
                rockCounter = 7;
            }
        }
        if (isShooting && rockBuffer <= 0f)
        {
            point.transform.localEulerAngles = new Vector3(0, 0, Random.Range(-45.0f, 45.0f));
            Instantiate(rock, point.transform);
            rockCounter -= 1;
            rockBuffer = .025f;
        }
        if (rockBuffer >= 0f)
        {
            rockBuffer -= Time.deltaTime;
        }
        if (rockCounter <= 0 && isShooting)
        {
            isShooting = false;
            rockCooldown = .5f;
        }
        if (rockCooldown >= 0)
        {
            rockCooldown -= Time.deltaTime;
        }


        if (Input.GetButtonDown("Special"))
        {
            if (wallCooldown <= 0)
            {
                Instantiate(wall, gameObject.transform);
                wallCooldown = 5.1f;
            }
        }


        if (wallCooldown >= 0)
        {
            wallCooldown -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Ultimate") && player.hasUlt())
        {
            player.updateUlt();
            Transform pos = gameObject.transform;
            Instantiate(ultWall, pos);
        }


        
    }
}
