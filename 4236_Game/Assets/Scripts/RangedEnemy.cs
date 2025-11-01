using UnityEngine;

public class RangedEnemy : BaseEnemy
{
    public float attackRange = 5f;
    public float buffer = 0.2f;

    void Update() {
        MoveEnemy();
    }

    void MoveEnemy() {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if ((distanceToPlayer > attackRange + buffer && distanceToPlayer <= detectionRange) || (isAlerted && distanceToPlayer > attackRange + buffer)) {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        } else if (distanceToPlayer < attackRange - buffer) {
            Vector2 direction = (transform.position - player.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        } else {

        }
    }
}
