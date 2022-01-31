using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera cam;
    private Rigidbody2D body;
    public float speed;
    public GameObject posessShot;
    private GameObject camBrain;

    private GameObject helth;
    private float hp;
    public float defence;

    private TMPro.TextMeshProUGUI ultCount;

    private float posessTimer;

    [HideInInspector]
    public Vector2 movement;
    Vector2 mousePos;
    

    void OnEnable()
    {
        transform.parent = null;
        cam = Camera.main;
        body = GetComponent<Rigidbody2D>();
        gameObject.name = "Player";
        camBrain = GameObject.Find("CM vcam1");
        camBrain.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
        
        helth = GameObject.Find("helth");
        hp = helth.GetComponent<Image>().fillAmount * 100;

        ultCount = GameObject.Find("Combo").GetComponent<TMPro.TextMeshProUGUI>();
    }

    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Posess"))
        {
            if (posessTimer <= 0)
            {
                Instantiate(posessShot, gameObject.transform);
                posessTimer = 5f;
            }
        }
        if (posessTimer >= 0)
        {
            posessTimer -= Time.deltaTime;
        }


        

        
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * speed * Time.deltaTime);


        
        Vector2 lookDir = mousePos - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;

        if (hp >= 0)
        {
            hp -= 0.04f;
            helth.GetComponent<Image>().fillAmount = hp / 100;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Damage":
                    print(gameObject.tag);
                    takeDamage(collision.GetComponent<BulletBehaviour>().damage);
                break;
            case "EnemyElectric":
                    print(gameObject.tag);
                    GameObject elec = collision.gameObject;
                    elec.SetActive(false);
                    takeDamage(0.2f);
                    elec.SetActive(true);
                break;
            case "EnemyGrass":
                print(gameObject.tag);
                takeDamage(10);
                break;
        }

    }

    public void takeDamage(float dmg)
    {
        //remember to implement unique defense values
        float toSet = hp - dmg;
        if (toSet <= 0)
        {
            hp = 0;
        }
        else 
        {
            hp -= dmg;
        }
        
    }

    public void setHealth(float value)
    {
        hp = value;
        print(hp);
    }

    public void updateUlt()
    {
        ultCount.text = string.Format("{0}", int.Parse(ultCount.text) - 1);
    }

    public bool hasUlt()
    {
        if (int.Parse(ultCount.text) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isDead()
    {
        if (helth.GetComponent<Image>().fillAmount <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
