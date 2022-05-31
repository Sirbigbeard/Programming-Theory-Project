using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float speed = 15;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        RegisterMovement();

    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("Game Over");
    }
    private void RegisterMovement()
    {
        playerRb.velocity = new Vector3(0, 0, 0);
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(-Vector3.left * Time.deltaTime * horizontalInput * speed);
    }
}
