using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour {
    public static UnitActionSystem Instance{ get; private set; }
    public event EventHandler OnUnitVisualSelected;
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask units;

    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            Debug.Log("There is more than one Instances" + transform + " - " + Instance);
        }
        Instance = this;
    }

    private void Update(){
        if (Input.GetMouseButtonDown(1)){
            if (TryUnitSelection()) return;
            selectedUnit.GetMoveAction().Move(MouseWorld.GetMouseWorlPosition());
        }
    }

    public bool TryUnitSelection(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, units)){
            Unit unit = raycastHit.transform.GetComponent<Unit>();
            SetSelectedUnit(unit);
            return true;
        }
        return false;
    }

    public void SetSelectedUnit(Unit _unit){
        selectedUnit = _unit;
        OnUnitVisualSelected?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit(){
        return selectedUnit;
    }
}