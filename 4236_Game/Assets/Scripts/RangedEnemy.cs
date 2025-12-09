using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    public float attackRange = 5f;
    public float buffer = 0.2f;

    void FixedUpdate() {
        MoveEnemy();
    }

    void MoveEnemy() {
        float distanceToPlayer = Vector2.Distance(rb.position, player.position);
        Vector2 direction;

        if ((distanceToPlayer > attackRange + buffer && distanceToPlayer <= detectionRange) || (isAlerted && distanceToPlayer > attackRange + buffer)) {
            direction = ((Vector2)player.position - rb.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        } else if (distanceToPlayer < attackRange - buffer) {
            direction = (rb.position - (Vector2)player.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        } else {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
