using UnityEngine;

public class CowardEnemy : BaseEnemy
{
    public float fleeRange = 10f;
    public float alertRange = 5f;
    public LayerMask enemyLayer;

    void Update() {
        FleeFromPlayer();
        AlertEnemies();
    }

    void FleeFromPlayer() {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= fleeRange) {
            Vector2 direction = (transform.position - player.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
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
}