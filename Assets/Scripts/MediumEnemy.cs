using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody>();
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            new WaitForSeconds(1);
            Move();
            moving = true;
        }
        else
        {
            CheckPosition();
        }

    }
    protected void Move()
    {
        int direction = Random.Range(1, 3);
        if (direction == 1)
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
        randomX = Random.Range(-20f, 20f);
        if (transform.position.x < randomX)
        {
            enemyRb.AddForce(3, 0, 0, ForceMode.Impulse);
            xPositive = true;
        }
        else
        {
            enemyRb.AddForce(-3, 0, 0, ForceMode.Impulse);
            xPositive = false;
        }
    }
    protected void MoveY()
    {
        randomY = Random.Range(-8.8f, 9.5f);
        if (transform.position.z < randomY)
        {
            enemyRb.AddForce(0, 0, 3, ForceMode.Impulse);
            yPositive = true;

        }
        else
        {
            enemyRb.AddForce(0, 0, -3, ForceMode.Impulse);
            yPositive = false;
        }
    }
    protected void CheckPosition()
    {
        if ((!xPositive && transform.position.x < randomX) || (xPositive && transform.position.x > randomX) || (!yPositive && transform.position.z < randomY) ||
            (yPositive && transform.position.z > randomY) || (transform.position.x > 20) || (transform.position.x < -20) || (transform.position.z > 9.5f) || (transform.position.z < -8.8f))
        {
            enemyRb.velocity = new Vector3(0, 0, 0);
            transform.rotation = smallEnemy.transform.rotation;
            moving = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            DealDamage();
        }
    }
}