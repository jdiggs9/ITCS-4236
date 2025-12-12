using UnityEngine;

public class EnemyDetector : MonoBehaviour
{

    private DoorMechanic doorMechanic;
    private bool playerInRoom = false;
    private bool enemiesInRoom = false;
    private float countdown = 3f;
    private bool startCountdown = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorMechanic = GetComponentInParent<DoorMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountdown)
        {
            playerInRoom = true;
        } else
        {
            countdown -= Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 13)
        {
            startCountdown = true;
        }
        if (other.gameObject.layer == 6)
        {
            enemiesInRoom = true;
        } else
        {
            enemiesInRoom = false;
        }
        if (playerInRoom && enemiesInRoom)
        {
            doorMechanic.isLocked = true;
        }
    }
}
