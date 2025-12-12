using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openDoor;
    // 1 = needs a door facing South
    // 2 = needs a door facing North
    // 3 = needs a door facing West
    // 4 = needs a door facing East

    
    private RoomTemplate temp;
    private int random;
    private bool hasSpawned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        temp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("SpawnRoom", 1f);
    }

    // Update is called once per frame
    private void SpawnRoom() {
        if (!hasSpawned && temp.roomCount < 15) {
            if (openDoor == 1) {
                random = Random.Range(0, temp.SouthRooms.Length);
                Instantiate(temp.SouthRooms[random], transform.position, temp.SouthRooms[random].transform.rotation);
                temp.roomCount++;
            } else if (openDoor == 2) {
                random = Random.Range(0, temp.NorthRooms.Length);
                Instantiate(temp.NorthRooms[random], transform.position, temp.NorthRooms[random].transform.rotation);
                temp.roomCount++;
            } else if (openDoor == 3) {
                random = Random.Range(0, temp.WestRooms.Length);
                Instantiate(temp.WestRooms[random], transform.position, temp.WestRooms[random].transform.rotation);
                temp.roomCount++;
            } else if (openDoor == 4) {
                random = Random.Range(0, temp.EastRooms.Length);
                Instantiate(temp.EastRooms[random], transform.position, temp.EastRooms[random].transform.rotation);
                temp.roomCount++;
            }
            hasSpawned = true;
        } if (!hasSpawned && temp.roomCount >= temp.maxRooms) {
            if (!temp.hasBoss) {
                if (openDoor == 1) {
                    Instantiate(temp.BossRooms[0], transform.position, temp.BossRooms[0].transform.rotation);
                    temp.roomCount++;
                } else if (openDoor == 2) {
                    Instantiate(temp.BossRooms[1], transform.position, temp.BossRooms[1].transform.rotation);
                    temp.roomCount++;
                } else if (openDoor == 3) {
                    Instantiate(temp.BossRooms[2], transform.position, temp.BossRooms[2].transform.rotation);
                    temp.roomCount++;
                } else if (openDoor == 4) {
                    Instantiate(temp.BossRooms[3], transform.position, temp.BossRooms[3].transform.rotation);
                    temp.roomCount++;
                }
                temp.hasBoss = true;
            } else {
                if (openDoor == 1) {
                    Instantiate(temp.EndRooms[0], transform.position, temp.EndRooms[0].transform.rotation);
                    temp.roomCount++;
                } else if (openDoor == 2) {
                    Instantiate(temp.EndRooms[1], transform.position, temp.EndRooms[1].transform.rotation);
                    temp.roomCount++;
                } else if (openDoor == 3) {
                    Instantiate(temp.EndRooms[2], transform.position, temp.EndRooms[2].transform.rotation);
                    temp.roomCount++;
                } else if (openDoor == 4) {
                    Instantiate(temp.EndRooms[3], transform.position, temp.EndRooms[3].transform.rotation);
                    temp.roomCount++;
                }
            }
                hasSpawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("SpawnPoint")) {
            Destroy(gameObject);
            
        }
    }
}
