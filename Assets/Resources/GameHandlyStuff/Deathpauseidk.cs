using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathpauseidk : MonoBehaviour
{
    private bool paused;
    public GameObject pause;
    public GameObject deathScreen;

    [SerializeField]
    private GameObject[] players;

    // Start is called before the first frame update
    void OnEnable()
    {
        Instantiate(players[Random.Range(0, 4)]);
    }

    // Update is called once per frame
    void Update()
    {
            GameObject player = GameObject.Find("Player");
            if (player.GetComponent<PlayerController>().isDead())
            {
                Time.timeScale = 0f;
                deathScreen.SetActive(true);
                if (Input.GetButtonDown("Posess"))
                {
                    Time.timeScale = 1f;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }

            if (Input.GetButtonDown("Cancel"))
            {
                paused = !paused;
                Time.timeScale = (paused) ? 0f : 1f;
                pause.SetActive(paused);
            }
         
        
    }
}
