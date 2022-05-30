using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            new WaitForSeconds(1);
            Move();
            Debug.Log("test1");
            moving = true;
        }
        else
        {
            CheckPosition();
        }

    }
    //I normally would not overload this method, instead making a variable in parent Enemy class to track the speed and setting it in this class, but gotta perform the assignment's requirements and one is method overriding
    protected void MoveX()
    {
        randomX = Random.Range(1, 15);
        if (transform.position.x < randomX)
        {
            enemyRb.AddForce(2, 0, 0, ForceMode.Impulse);
            xPositive = true;
            Debug.Log("moved x positive");
        }
        else
        {
            enemyRb.AddForce(-2, 0, 0, ForceMode.Impulse);
            xPositive = false;
            Debug.Log("moved x negative");
        }
    }
    protected void MoveY()
    {
        randomY = Random.Range(1, 15);
        if (transform.position.z < randomY)
        {
            enemyRb.AddForce(0, 0, 2, ForceMode.Impulse);
            yPositive = true;
            Debug.Log("moved z positive");

        }
        else
        {
            enemyRb.AddForce(0, 0, -2, ForceMode.Impulse);
            yPositive = false;
            Debug.Log("moved z negative");
        }
    }
}