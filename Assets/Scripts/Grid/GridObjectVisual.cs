using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridObjectVisual : MonoBehaviour {
    private GridObject gridObject;
    [SerializeField] private TextMeshPro textVisual;

    public void SetGridObjectVisual(GridObject _gridObject){
        gridObject = _gridObject;
    }

    private void Update(){
        textVisual.text = gridObject.ToString();
    }
}