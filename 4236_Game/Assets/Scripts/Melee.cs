using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackRadius = 0.7f;
    public LayerMask enemyLayer;
    public int attackDamage = 1;
    public BaseEnemy baseEnemy;
    public float cooldownTime = 0.5f;
    private float cooldownTimer = 0f;

    private void Update()
    {
        if (cooldownTimer <= 0) {
            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyLayer);
                foreach (Collider2D enemy in hitEnemies)
                {
                    baseEnemy = enemy.GetComponent<BaseEnemy>();
                    baseEnemy.TakeDamage(attackDamage);
                }
                cooldownTimer = cooldownTime;
            }
        } else {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }
}
