using UnityEngine;

public class CowardEnemy : BaseEnemy
{
    public float fleeRange = 10f;
    public float alertRange = 5f;
    public LayerMask enemyLayer;

    void Update() {
        AlertEnemies();
        LookAtPlayer();
    }

    void FixedUpdate() {
        inGroup = true;
        FleeFromPlayer();
    }

    void FleeFromPlayer() {
        float distanceToPlayer = Vector2.Distance(rb.position, player.position);

        if (distanceToPlayer <= fleeRange) {
            Vector2 direction = (rb.position - (Vector2)player.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        } else {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void AlertEnemies() {
        Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, alertRange, enemyLayer);

        foreach (Collider2D nearbyEnemy in nearbyEnemies) {
            BaseEnemy enemy = nearbyEnemy.GetComponent<BaseEnemy>();
            if (enemy != null && enemy != this) {
                enemy.isAlerted = true;
            }
        }
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
}