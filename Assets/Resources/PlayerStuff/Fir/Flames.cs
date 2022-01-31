using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    private float lifeTime;

    // Start is called before the first frame update
    void OnEnable()
    {
        transform.parent = null;
        lifeTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else 
        {
            lifeTime -= Time.deltaTime;
        }
    }
}
