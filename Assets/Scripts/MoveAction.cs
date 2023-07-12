using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] private int maxDistanceMove = 4;
    private Unit unit;
    private Vector3 targetPosition;

    private void Awake(){
        unit = GetComponent<Unit>();
        targetPosition = transform.position;
    }

    private void Update(){
        float endedDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > endedDistance){
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            float speed = 4f;
            transform.position += moveDirection * speed * Time.deltaTime;
            float speedRotation = 10f;
            transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * speedRotation);
            animator.SetBool("IsWalking", true);
        }
        else{
            animator.SetBool("IsWalking", false);
        }
    }

    public void Move(Vector3 _targetPosition){
        this.targetPosition = _targetPosition;
    }

    public List<GridPosition> GetValidActionGridPositionList(){
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitCurentGridPosition = unit.GetGridPosition();
        for (int x = -maxDistanceMove; x <= maxDistanceMove; x++){
            for (int z = -maxDistanceMove; z <= maxDistanceMove; z++){
                GridPosition offsetPosition = new GridPosition(x, z);
                GridPosition testPosition = unitCurentGridPosition + offsetPosition;
                Debug.Log(testPosition);
            }
        }
        return validGridPositionList;
    }
}