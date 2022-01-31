using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject electricHB;

    private Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        electricHB.SetActive(enemy.attacking());
    }
}
