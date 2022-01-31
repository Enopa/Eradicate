using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject slash;

    private float slashTimer;

    private Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((enemy.attacking() && !slash.activeSelf))
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
    }
}
