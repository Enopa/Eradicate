using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Transform forwardRef;
    private Rigidbody2D body;
    private Vector2 moveDir;
    public int bulletSpeed;
    public float liveTime;
    private float timer;

    public float damage;

    // Start is called before the first frame update
    void OnEnable()
    {
        body = GetComponent<Rigidbody2D>();
        moveDir = forwardRef.position - gameObject.transform.position;
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = moveDir * bulletSpeed;
        if (timer >= liveTime)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string[] tags;
        switch (gameObject.tag)
        {
            case "Damage":
                tags = new string[] {"Enemy", "Damage", "Posess", "IceMine"};
                
                if (!checkTag(tags, collision.tag))
                {
                    Destroy(gameObject);
                }
                break;
            case "Posess":
                tags = new string[] {"Enemy"};
                if (collision.tag.Equals("Enemy") || collision.tag.Equals("Wall"))
                {
                    Destroy(gameObject);
                }
                break;
            case "Attack":
                
                if (gameObject.name.Equals("Icicle(Clone)"))
                {
                    tags = new string[] { "Player", "Attack", "Blizzard", "IceMine", "Damage"};
                    if (!checkTag(tags, collision.tag))
                    {
                        Destroy(gameObject);
                    }
                }
                else 
                {
                    tags = new string[] { "Player", "Attack", "Blizzard", "IceMine"};
                    if (!checkTag(tags, collision.tag))
                    {
                        Destroy(gameObject);
                    }
                }
                break;
        }
           
        
    }

    bool checkTag(string[] toCheck, string tag)
    {
        bool toReturn = false;
        for (int i = 0; i <= toCheck.Length - 1; i++)
        {
            if (toCheck[i].Equals(tag))
            {
                toReturn = true;
            }
        }
        return toReturn;
    }
  
}
