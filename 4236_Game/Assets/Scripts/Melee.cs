using UnityEngine;

public class Melee : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            BaseEnemy enemy = other.GetComponent<BaseEnemy>();
            if (enemy != null) {
                enemy.TakeDamage(damage);
            }
        }
    }
}
