using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // make the camera follow the player

        // get the player position

        Vector3 playerPosition = GameObject.Find("Player").transform.position;

        // set the camera position to the player position

        transform.position = new Vector3(playerPosition.x, playerPosition.y+4, -10);


    }
}
