using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float miny, maxy;

    [SerializeField] Transform subFloor,midleFloor;
    Vector2 endPosition;
    private void Start()
    {
        endPosition = transform.position;
    }
    private void Update()
    {
        ClampCamera();
        BackgroundMove();
    }
    void ClampCamera()
    {
        transform.position = new Vector3(player.transform.position.x, Mathf.Clamp(player.transform.position.y, miny, maxy), transform.position.z);
    }
    void BackgroundMove()
    {
        Vector2 difference = new Vector2(transform.position.x - endPosition.x, transform.position.y - endPosition.y);
        subFloor.position += new Vector3(difference.x, difference.y, 0);
        midleFloor.position += new Vector3(difference.x, difference.y, 0) * .5f;
        endPosition = transform.position;
    }
}
