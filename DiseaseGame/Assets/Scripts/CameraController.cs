using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerLoc;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(playerLoc.position.x, playerLoc.position.y, playerLoc.position.z - 10);
    }
}
