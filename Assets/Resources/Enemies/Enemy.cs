using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Enemy : MonoBehaviour
{

    public float health;
    public GameObject healthBar;

    private GameObject playerHelth;
    private GameObject comboMeter;
    private AIPath path;
    private AIDestinationSetter dest;


    private float freezeTimer;
    public float speed;
    private float slowSpeed;


    public int attackDistance;

    // Start is called before the first frame update
    void OnEnable()
    {
        health = 100;

        playerHelth = GameObject.Find("helth");
        comboMeter = GameObject.Find("ComboTimer");
        path = GetComponent<AIPath>();
        dest = GetComponent<AIDestinationSetter>();
        path.maxSpeed = speed;
        slowSpeed = speed / 2;

    }

    // Update is called once per frame
    void Update()
    {

        dest.target = GameObject.Find("Player").transform;

        healthBar.GetComponent<Image>().fillAmount = health / 100;

        if (health <= 0)
        {
            die();
        }


        if (freezeTimer > 0)
        {
            healthBar.GetComponent<Image>().color = new Color(0, 106, 255);
            freezeTimer -= Time.deltaTime;
            path.maxSpeed = slowSpeed;
        }
        else
        {
            healthBar.GetComponent<Image>().color = new Color(255, 0, 0);
            path.maxSpeed = speed;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Posess":
                GameObject player = Resources.Load("PLayerStuff/" + gameObject.name.Substring(0, 3) + "/" + gameObject.name.Substring(0, 3)) as GameObject;
                Destroy(GameObject.Find("Player"));
                playerHelth.GetComponent<Image>().fillAmount = health / 100;
                Instantiate(player, gameObject.transform);
                Destroy(gameObject);
                break;
            case "Attack":
                if (collision.gameObject.name.Equals("Icicle(Clone)") && freezeTimer > 0)
                {
                    takeDamage(collision.GetComponent<BulletBehaviour>().damage * 10);
                    
                }
                else 
                {
                    takeDamage(collision.GetComponent<BulletBehaviour>().damage);
                }
                
                break;
            case "Electric":
                GameObject elec = collision.gameObject;
                elec.SetActive(false);
                takeDamage(2);
                elec.SetActive(true);
                break;
            case "Lava":
                takeDamage(50);
                break;
            case "Explosion":
                takeDamage(30);
                break;
            case "Slash":
                takeDamage(30);
                break;
            case "BigSlash":
                takeDamage(50);
                break;
            case "Flames":
                takeDamage(2);
                break;
            case "Discharge":
                takeDamage(50);
                break;
            case "Blizzard":
                GameObject bliz = collision.gameObject;
                bliz.SetActive(false);
                
                takeDamage(0.5f);
                bliz.SetActive(true);
                freezeTimer = 3;
                break;
            case "UltSlash":
                takeDamage(100);
                break;
            case "IceMine":
                takeDamage(5);
                freezeTimer = 3;
                break;

        }
    }

    void takeDamage(float damage)
    {
        health -= damage; 
    }


    private void die()
    {
        Destroy(gameObject);
        comboMeter.GetComponent<Image>().fillAmount += 0.2f;
    }


    public bool attacking()
    {
        if (path.remainingDistance < attackDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
