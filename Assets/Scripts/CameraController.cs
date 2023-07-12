using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;

public class CameraController : MonoBehaviour {
    [SerializeField] private CinemachineVirtualCamera cineMachineVirtualCamera;
    private const float MIN_ZOOM = 2;
    private const float MAX_ZOOM = 12;
    private Vector3 targetCineMachinePos;
    private CinemachineTransposer cinemachineTransposer;

    private void Start(){
        cinemachineTransposer = cineMachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        targetCineMachinePos = cinemachineTransposer.m_FollowOffset;
    }

    void Update(){
        HandleMovent();
        HandleRotation();
        HandleZoom();
    }

    private void HandleMovent(){
        Vector3 moveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)){
            moveDirection.z = +1f;
        }
        if (Input.GetKey(KeyCode.S)){
            moveDirection.z = -1f;
        }
        if (Input.GetKey(KeyCode.A)){
            moveDirection.x = -1f;
        }
        if (Input.GetKey(KeyCode.D)){
            moveDirection.x = +1f;
        }
        float moveSpeed = 5f;
        Vector3 moveVector = transform.forward * moveDirection.z + transform.right * moveDirection.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }

    private void HandleRotation(){
        Vector3 rotation = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Q)){
            rotation.y = +1f;
        }
        if (Input.GetKey(KeyCode.E)){
            rotation.y = -1f;
        }
        float rotationSpeed = 100f;
        transform.eulerAngles += rotation * rotationSpeed * Time.deltaTime;
    }

    private void HandleZoom(){
        float zoomAmount = 1f;
        if (Input.mouseScrollDelta.y < 0){
            targetCineMachinePos.y += zoomAmount;
        }
        if (Input.mouseScrollDelta.y > 0){
            targetCineMachinePos.y -= zoomAmount;
        }
        targetCineMachinePos.y = Mathf.Clamp(targetCineMachinePos.y, MIN_ZOOM, MAX_ZOOM);
        float speedSmooth = 5f;
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetCineMachinePos,
            Time.deltaTime * speedSmooth);
    }
}