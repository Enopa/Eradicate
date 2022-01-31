using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float cooldown;

    private Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.attacking() && cooldown <= 0)
        {
            Instantiate(projectile, gameObject.transform);
            cooldown = 1f;
        }

        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
}
