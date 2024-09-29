using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget; 
    private Vector3 distance;
    private void Awake()
    {
        distance = transform.position - cameraTarget.position;
    }

    private void LateUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        transform.position = cameraTarget.position + distance;
    }
}
