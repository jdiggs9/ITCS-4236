using UnityEngine;

public class EnemyDetector : MonoBehaviour
{

    private DoorMechanic doorMechanic;
    private bool playerInRoom = false;
    private bool enemiesInRoom = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorMechanic = GetComponentInParent<DoorMechanic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 13)
        {
            playerInRoom = true;
        }
        if (other.gameObject.layer == 6)
        {
            enemiesInRoom = true;
        }
        if (playerInRoom && enemiesInRoom)
        {
            doorMechanic.isLocked = true;
        }
    }
}
