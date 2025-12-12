using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorMechanic : MonoBehaviour
{

    public TileBase doorClosedLeft;
    public TileBase doorClosedRight;
    public TileBase doorOpenLeft;
    public TileBase doorOpenRight;
    public TileBase rightDoorClosedTop;
    public TileBase rightDoorClosedBottom;
    public TileBase leftDoorClosedTop;
    public TileBase leftDoorClosedBottom;
    public Tilemap tilemap;
    public Vector3Int topLeftDoorPos;
    public Vector3Int topRightDoorPos;
    public bool northDoor;
    public Vector3Int bottomLeftDoorPos;
    public Vector3Int bottomRightDoorPos;
    public bool southDoor;
    public Vector3Int leftTopDoorPos;
    public Vector3Int leftBottomDoorPos;
    public bool westDoor;
    public Vector3Int rightTopDoorPos;
    public Vector3Int rightBottomDoorPos;
    public bool eastDoor;
    public bool isLocked = false;
    private GameObject player;
    private GameObject cam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
        cam = GameObject.FindGameObjectWithTag("Cam");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (!isLocked)
        {
            if (northDoor)
            {
                tilemap.SetTile(topLeftDoorPos, doorOpenLeft);
                tilemap.SetTile(topRightDoorPos, doorOpenRight);
            }
            if (southDoor)
            {
                tilemap.SetTile(bottomLeftDoorPos, doorOpenLeft);
                tilemap.SetTile(bottomRightDoorPos, doorOpenRight);
            }
            if (westDoor)
            {
                tilemap.SetTile(leftTopDoorPos, null);
                tilemap.SetTile(leftBottomDoorPos, null);
            }
            if (eastDoor)
            {
                tilemap.SetTile(rightTopDoorPos, null);
                tilemap.SetTile(rightBottomDoorPos, null);
            }
        }
        else
        {
            if (northDoor)
            {
                tilemap.SetTile(topLeftDoorPos, doorClosedLeft);
                tilemap.SetTile(topRightDoorPos, doorClosedRight);
            }
            if (southDoor)
            {
                tilemap.SetTile(bottomLeftDoorPos, doorClosedLeft);
                tilemap.SetTile(bottomRightDoorPos, doorClosedRight);
            }
            if (westDoor)
            {
                tilemap.SetTile(leftTopDoorPos, leftDoorClosedTop);
                tilemap.SetTile(leftBottomDoorPos, leftDoorClosedBottom);
            }
            if (eastDoor)
            {
                tilemap.SetTile(rightTopDoorPos, rightDoorClosedTop);
                tilemap.SetTile(rightBottomDoorPos, rightDoorClosedBottom);
            }
        }

    }
    //private void OnTriggerEnter2D(Collider2D other) {
        
    //    player.transform.position = new Vector2(0f, 9f);
    //    cam.transform.position = new Vector3(0f, 12f, -10f);
        
    //}

    
}
