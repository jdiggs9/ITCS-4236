using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float detectionRange = 7;
    public bool isAlerted = false;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange || isAlerted) {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }
}
