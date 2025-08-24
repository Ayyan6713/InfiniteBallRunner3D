using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;         // The player's transform
    public Vector3 offset;           // Offset between camera and player
    public float smoothSpeed = 3f;   // How smoothly the camera follows
    public Vector3 targetposition;
   

    private void LateUpdate()
    {
       
        if (player == null) return;

        targetposition = new Vector3(transform.position.x, player.position.y+3, player.position.z-5);
        
        

        // Follow player on X and Z axis, keep original Y (height)
        //Vector3 targetPosition = new Vector3(player.position.x + offset.x, transform.position.y, player.position.z + offset.z);

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, targetposition, smoothSpeed * Time.fixedDeltaTime);

        //transform.LookAt(player.position);
    }


}

