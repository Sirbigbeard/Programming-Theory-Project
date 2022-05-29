using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool moving = false;
    private float randomX;
    private float randomY;
    protected Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    protected void Move()
    {
        int direction = Random.Range(1, 2);
        if(direction == 1)
        {
            MoveX();
        }
        else
        {
            MoveY();
        }
        new WaitForSeconds(15);
        moving = false;
    }
    protected void MoveX()
    {
        randomX = Random.Range(1, 15);
        while (transform.position.x < randomX)
        {
            enemyRb.AddForce(1 * Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
        while (transform.position.x >= randomX)
        {
            enemyRb.AddForce(-1, 0, 0, ForceMode.Impulse);
        }
        enemyRb.velocity = new Vector3(0, 0, 0);
    }
    protected void MoveY()
    {
        randomY = Random.Range(1, 15);
        while (transform.position.y < randomY)
        {
            enemyRb.AddForce(0, 1, 0, ForceMode.Impulse);
        }
        while (transform.position.y >= randomY)
        {
            enemyRb.AddForce(0, -1, 0, ForceMode.Impulse);
        }
        enemyRb.velocity = new Vector3(0, 0, 0);
    }
}
