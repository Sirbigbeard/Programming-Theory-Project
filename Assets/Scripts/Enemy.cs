using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected bool moving = false;
    protected float randomX;
    protected float randomY;
    protected Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        
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
        /*for(int x = 0; x < randomMovement; x++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            WaitForSeconds(.1);
        }*/
        moving = false;
        
        //Look at how they moved their trucks around
    }
    protected void MoveX()
    {
        randomX = Random.Range(1, 15);
        while (transform.position.x < randomX)
        {
            enemyRb.AddForce(1, 0, 0, ForceMode.Impulse);
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
            transform.Translate(1, 0, 0);
        }
        while (transform.position.y >= randomY)
        {
            transform.Translate(-1, 0, 0);
        }
    }
}
