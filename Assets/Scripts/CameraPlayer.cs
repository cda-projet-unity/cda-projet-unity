using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float z;
    [SerializeField] private float width;
    [SerializeField] private float height;
    private Camera cam;
    private Vector3 leftLimit;
    private Vector3 rightLimit;
    private bool isMoving;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(player.position);
        leftLimit = cam.ViewportToScreenPoint(new Vector3(width, height, z));
        rightLimit = cam.ViewportToScreenPoint(new Vector3(1 - width, 1 - height, z));

        if (screenPos.x < leftLimit.x || screenPos.x > rightLimit.x || isMoving)
        {
            isMoving = true;
            if (Vector2.Distance(screenPos, cam.WorldToScreenPoint(transform.position)) <= 100f)
            {
                isMoving = false;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, z), Time.deltaTime);
            }
        }
    }
}

