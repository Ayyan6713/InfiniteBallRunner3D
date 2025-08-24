using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float forwardSpeed = 3.0f;
    public Rigidbody rb;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private float moveHorizontal = 0f;

    private void FixedUpdate()
    {
        HandleTouchInput();

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 1.0f); // Always move forward (z = 1)
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;
                Vector2 swipe = touchEndPos - touchStartPos;

                if (Mathf.Abs(swipe.x) > 50) // Horizontal swipe threshold
                {
                    moveHorizontal = swipe.x > 0 ? 1 : -1;
                }
                else
                {
                    moveHorizontal = 0;
                }
            }
        }
        else
        {
            moveHorizontal = 0;
        }
    }
}

