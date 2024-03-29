using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSpead=4f;
    public float minZoom=5f;
    public float maxZoom=15f;
    public float pitch=2f;
    public float yawSpaed=100f;
    public float currentZoom=10f;
    public float currentYaw=0;
    void Update()
    {
        currentZoom-=Input.GetAxis("Mouse ScrollWheel")*zoomSpead;
        currentZoom=Mathf.Clamp(currentZoom,minZoom,maxZoom);
        currentYaw-=Input.GetAxis("Horizontal")*yawSpaed*Time.deltaTime;
        transform.position=target.position-offset*currentZoom;
        transform.LookAt(target.position+Vector3.up*pitch);
        transform.RotateAround(target.position,Vector3.up,currentYaw);
    }
}
