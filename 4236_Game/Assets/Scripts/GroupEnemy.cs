using System.Collections.Generic;
using UnityEngine;

public class GroupEnemy : BaseEnemy
{
    public List<Transform> groupMembers = new List<Transform>();


    public float engageRange = 5f;
    public Vector2[] formationOffset;
    public Vector2[] surroundOffset;
    private bool isEngaging = false;

    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(rb.position, player.position);

        if (distanceToPlayer <= engageRange || isAlerted)
        {
            isEngaging = true;
        }

        MoveGroup();
    }
    
    void MoveGroup() {
        for (int i = 0; i < groupMembers.Count; i++)
        {
            Transform member = groupMembers[i];
            Rigidbody2D memberRb = member.GetComponent<Rigidbody2D>();
            Vector2 targetPos;

            if (!isEngaging)
            {
                // Initial formation
                targetPos = (Vector2)rb.position + formationOffset[i];
            }
            else
            {
                // Surround the player
                targetPos = (Vector2)player.position + surroundOffset[i];
            }

            Vector2 direction = (targetPos - (Vector2)memberRb.position).normalized;
            memberRb.MovePosition(memberRb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
