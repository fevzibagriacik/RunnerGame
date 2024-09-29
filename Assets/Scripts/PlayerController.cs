using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float touchXDelta;
    float newX;
    public float xSpeed;
    public float limitX;
    void Update()
    {
        xMove();

        AutoMove();
    }

    public void AutoMove()
    {
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    public void xMove()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + touchXDelta * xSpeed * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);
    }
}
