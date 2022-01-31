using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDestroy : MonoBehaviour
{

    public GameObject toCreate;
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (gameObject.tag)
        {
            case ("Attack"):
                if (!collision.tag.Equals("Player"))
                {
                    Instantiate(toCreate, gameObject.transform);
                    Destroy(gameObject);
                }
                break;
            case ("Damage"):
                if (!collision.tag.Equals("Enemy") && !collision.tag.Equals("Blizzard"))
                {
                    Instantiate(toCreate, gameObject.transform);
                    Destroy(gameObject);
                }
                break;
            default:
                if (!collision.tag.Equals("Player"))
                {
                    Instantiate(toCreate, gameObject.transform);
                    Destroy(gameObject);
                }
                break;
        }
        
    }
}
