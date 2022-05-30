using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool moving = false;
    protected float randomX = 15;
    protected float randomY = 15;
    public Rigidbody enemyRb;
    protected bool xPositive = true;
    protected bool yPositive = true;
    public GameObject largeEnemy;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = largeEnemy.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        

    }
    protected void Move()
    {
        int direction = Random.Range(1, 3);
        if(direction == 1)
        {
            MoveX();
        }
        else
        {
            MoveY();
        }
    }
    protected void MoveX()
    {
        randomX = Random.Range(1, 15);
        if (transform.position.x < randomX)
        {
            enemyRb.AddForce(3, 0, 0, ForceMode.Impulse);
            xPositive = true;
            Debug.Log("moved x positive");
        }
        else
        {
            enemyRb.AddForce(-3, 0, 0, ForceMode.Impulse);
            xPositive = false;
            Debug.Log("moved x negative");
        }
    }
    protected void MoveY()
    {
        randomY = Random.Range(1, 15);
        if (transform.position.z < randomY)
        {
            enemyRb.AddForce(0, 0, 3, ForceMode.Impulse);
            yPositive = true;
            Debug.Log("moved z positive");

        }
        else
        {
            enemyRb.AddForce(0, 0, -3, ForceMode.Impulse);
            yPositive = false;
            Debug.Log("moved z negative");
        }
    }
    protected void CheckPosition()
    {
        if(!xPositive && largeEnemy.transform.position.x < randomX)
        {
            enemyRb.velocity = new Vector3(0, 0, 0);
            moving = false;
        }
        if (xPositive && largeEnemy.transform.position.x > randomX)
        {
            enemyRb.velocity = new Vector3(0, 0, 0);
            moving = false;
        }
        if (!yPositive && largeEnemy.transform.position.z < randomY)
        {
            enemyRb.velocity = new Vector3(0, 0, 0);
            moving = false;
        }
        if (yPositive && largeEnemy.transform.position.z > randomY)
        {
            enemyRb.velocity = new Vector3(0, 0, 0);
            moving = false;
        }
    }
}
