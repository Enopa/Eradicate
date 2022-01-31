using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class RockEnemy : MonoBehaviour
{

    public GameObject point;
    public GameObject rock;
    private float rockBuffer;
    private bool isShooting;
    private float rockCooldown;
    private int rockCounter;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.attacking())
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
    }
}
