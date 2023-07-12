using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCircleVisual : MonoBehaviour {
    [SerializeField] private Unit unit;
    [SerializeField] private MeshRenderer visualCircle;

    private void Awake(){
        visualCircle = GetComponent<MeshRenderer>();
        
    }

    private void Start(){
        UpdateVisual();
        UnitActionSystem.Instance.OnUnitVisualSelected += OnUnitVisualSelected;
    }

    private void OnUnitVisualSelected(object sender, EventArgs e){
        UpdateVisual();
        
    }

    public void UpdateVisual(){
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit){
            visualCircle.enabled = true;
        }
        else{
            visualCircle.enabled = false;
            
        }
    }
}