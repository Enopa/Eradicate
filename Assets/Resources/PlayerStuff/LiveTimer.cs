using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTimer : MonoBehaviour
{
    public float liveTimer = 1;
    // Start is called before the first frame update
    void OnEnable()
    {
         transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (liveTimer <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            liveTimer -= Time.deltaTime;
        }
    }
}
