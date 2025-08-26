using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float moveHorizontal;

    Vector3 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        movement = new Vector3(moveHorizontal, 0.0f, 1.0f);
    }

    private void FixedUpdate()
    {
        //Vector3 movement = new Vector3(moveHorizontal, 0f, 1f).normalized;
        rb.velocity = movement * speed;
    }



    public void MoveRightPointerDown()

    {
        moveHorizontal = 1f;


    }
    public void MoveRightPointerUp()
    {
        moveHorizontal = 0f;


    }

    public void MoveLeftPointerDown()
    {
        moveHorizontal = -1f;


    }
    public void MoveLeftPointerUp()
    {
        moveHorizontal = 0f;


    }

    



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("hurdle"))
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(2);

        }
        


            

                    
    }
}
