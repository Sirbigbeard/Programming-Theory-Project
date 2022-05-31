using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    protected bool moving = false;
    protected float randomX = 15;
    protected float randomY = 15;
    protected Rigidbody enemyRb;
    protected bool xPositive = true;
    protected bool yPositive = true;
    public GameObject warning;
    public GameObject smallEnemy;
    public GameObject mediumEnemy;
    public GameObject largeEnemy;
    public GameObject player;
    protected Player playerScript;
    private float xLocation;
    private float yLocation;
    private bool spawning = true;
    private int score;
    public TextMeshProUGUI scoreText;
    protected static int health = 5;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        if (spawning)
        {
            Spawn();
            spawning = false;
            StartCoroutine(SpawnTimer());
        }
        if (health < 1)
        {
            playerScript.GameOver();
        }
    }
    void Spawn()
    {
        xLocation = Random.Range(-20, 20);
        yLocation = Random.Range(-8.8f, 9.5f);
        Instantiate(warning, new Vector3(xLocation, 0, yLocation), warning.transform.rotation);
        StartCoroutine(SpawnCoroutine());
        UpdateScore(1);
    }
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(2);
        int randomSpawn = Random.Range(1, 6);
        if (randomSpawn < 3)
        {
            Instantiate(smallEnemy, new Vector3(xLocation, 0, yLocation), smallEnemy.transform.rotation);
        }
        else if (randomSpawn == 5)
        {
            Instantiate(largeEnemy, new Vector3(xLocation, 0, yLocation), largeEnemy.transform.rotation);
        }
        else
        {
            Instantiate(mediumEnemy, new Vector3(xLocation, 0, yLocation), mediumEnemy.transform.rotation);
        }
    }
    void Contact()
    {

    }
    protected void DealDamage()
    {
        health -= 1;
        Debug.Log(health);
    }
    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(4);
        spawning = true;
    }
    void UpdateScore(int points) 
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
