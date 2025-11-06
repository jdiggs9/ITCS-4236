using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorMechanic : MonoBehaviour
{

    public TileBase doorClosedLeft;
    public TileBase doorClosedRight;
    public TileBase doorOpenLeft;
    public TileBase doorOpenRight;
    public Tilemap tilemap;
    public Vector3Int leftDoorPos;
    public Vector3Int rightDoorPos;
    public bool isLocked;
    public GameObject player;
    public GameObject cam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (!isLocked) {
            tilemap.SetTile(leftDoorPos, doorOpenLeft);
            tilemap.SetTile(rightDoorPos, doorOpenRight);
            GetComponent<CompositeCollider2D>().isTrigger = true;
        } else {
            tilemap.SetTile(leftDoorPos, doorClosedLeft);
            tilemap.SetTile(rightDoorPos, doorClosedRight);
            GetComponent<CompositeCollider2D>().isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (!isLocked) {
            tilemap.SetTile(leftDoorPos, doorOpenLeft);
            tilemap.SetTile(rightDoorPos, doorOpenRight);
            GetComponent<TilemapCollider2D>().isTrigger = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        player.transform.position = new Vector2(0f, 9f);
        cam.transform.position = new Vector3(0f, 12f, -10f);
        
    }
}
