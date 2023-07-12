using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    private MoveAction moveAction;
    private GridPosition curentPosition;
    

    private void Start(){
        moveAction = GetComponent<MoveAction>();
        curentPosition = LevelGridCreate.Instance.GetGridFromWorldPosition(transform.position);
        LevelGridCreate.Instance.SetUnitAtGridPosition(curentPosition, this);
    }

    
    

    void Update(){
        GridPosition newPosition = LevelGridCreate.Instance.GetGridFromWorldPosition(transform.position);
        if (curentPosition != newPosition){
            LevelGridCreate.Instance.MoveUnit(this, curentPosition, newPosition);
            curentPosition = newPosition;
        }
       
    }

    public MoveAction GetMoveAction(){
        return moveAction;
    }

    public GridPosition GetGridPosition(){
        return curentPosition;
    }
    
}