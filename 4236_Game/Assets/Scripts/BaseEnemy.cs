using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float moveSpeed = 3f;
    public float detectionRange = 7;
    public bool isAlerted = false;
    public float radiusOfSatisfaction = 1f;

    [HideInInspector] public bool inGroup = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (inGroup) return;

        float distanceToPlayer = Vector3.Distance(rb.position, player.position);

        if (distanceToPlayer <= detectionRange || isAlerted) {
            if (distanceToPlayer > radiusOfSatisfaction) {
                Vector2 direction = (player.position - transform.position).normalized;
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            }
        } else {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
