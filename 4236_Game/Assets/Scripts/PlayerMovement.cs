using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed;
    //public GameObject cam;
    private Rigidbody2D playerRB;
    //public Rigidbody2D camRB;

    private float sprint;
    private Vector2 moveDirection;
    public SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        sprint = 1f;
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        inputControl();
        //cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }

    private void inputControl() {
        //input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            sprint = 2f;
        } else {
            sprint = 1f;
        }
        //player movement
        moveDirection = new Vector2(moveX, moveY).normalized;
        playerRB.linearVelocity = moveDirection * 100f * moveSpeed * Time.deltaTime * sprint;

        if (moveX > 0)
        {
            sr.flipX = false;
        } else if (moveX < 0)
        {
            sr.flipX = true;
        }

        //cam movement
        //camRB.linearVelocity = moveDirection * 100f * moveSpeed * Time.deltaTime * sprint;
        //if (cam.transform.position != new Vector3(transform.position.x, transform.position.y, -10f)) {
        //    cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        //}

        
    }
}
