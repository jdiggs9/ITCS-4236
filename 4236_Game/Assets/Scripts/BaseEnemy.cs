using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float moveSpeed = 3f;
    public float detectionRange = 7;
    public bool isAlerted = false;
    public float radiusOfSatisfaction = 1f;
    public bool isFlipped = false;
    public LayerMask ground;
    private HUD hud;
    public float damageCooldown = 1f;
    private float lastDamageTime = 0f;
    public int maxHealth = 3;
    public int currentHealth;
    public bool destroyOnDamage = false;

    [HideInInspector] public bool inGroup = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        hud = FindObjectOfType<HUD>();
        currentHealth = maxHealth;
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
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped) {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        } else if (transform.position.x < player.position.x && !isFlipped) {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (Time.time - lastDamageTime >= damageCooldown) {
                hud.Damaged();
                lastDamageTime = Time.time;

                if (destroyOnDamage)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
