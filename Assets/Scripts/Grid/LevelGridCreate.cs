using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGridCreate : MonoBehaviour {
    public static LevelGridCreate Instance{ get; private set; }
    private GridSystem gridSystem;
    private Unit unit;
    [SerializeField] private Transform gridDebugVisual;

    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            Debug.Log("There is more than one Instances_GridHandler" + transform + " - " + Instance);
        }
        Instance = this;
        gridSystem = new GridSystem(10, 10, 2f);
        gridSystem.CreateDebugObjects(gridDebugVisual);
    }

   

    public void SetUnitAtGridPosition(GridPosition gridPosition, Unit _unit){
        GridObject gridObject = gridSystem.GetGridObjectPosition(gridPosition);
        gridObject.AddUnitList(_unit);
    }

    public List<Unit> GetUnitFromGridPosition(GridPosition _gridPosition){
        GridObject gridObject = gridSystem.GetGridObjectPosition(_gridPosition);
        return gridObject.GetUnitListAtGrid();
    }

    public void ClearUnitAtGridPosition(GridPosition _gridPosition, Unit _unit){
        GridObject gridObject = gridSystem.GetGridObjectPosition(_gridPosition);
        gridObject.RemoveUnit(_unit);
    }

    public void MoveUnit(Unit _unit, GridPosition _startPosition, GridPosition _toPosition){
        ClearUnitAtGridPosition(_startPosition, _unit);
        SetUnitAtGridPosition(_toPosition, _unit );
    }
    public GridPosition GetGridFromWorldPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
}