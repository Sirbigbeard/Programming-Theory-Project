using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeEnemy : Enemy
{
    //protected Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == false)
        {
            Move();
            Debug.Log("test1");
            moving = true;
        }
    }
}
