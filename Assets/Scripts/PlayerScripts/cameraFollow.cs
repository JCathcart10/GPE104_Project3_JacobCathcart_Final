using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()// using late update because I want the camera to move after the player moves
    {
        transform.position = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, transform.position.z); 
    }
}
