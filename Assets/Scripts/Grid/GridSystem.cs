using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridSystem {
    private int width;
    private int heigth;
    private float cellSize;
    private GridObject[,] gridObjectsArray;

    public GridSystem(int _width, int _heigth, float _cellSize){
        width = _width;
        heigth = _heigth;
        cellSize = _cellSize;
        gridObjectsArray = new GridObject[width, heigth];
        for (int x = 0; x < width; x++){
            for (int z = 0; z < heigth; z++){
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectsArray[x, z] = new GridObject(this, gridPosition);
            }
        }
    }

    public void CreateDebugObjects(Transform prefab){
        for (int x = 0; x < width; x++){
            for (int z = 0; z < heigth; z++){
                GridPosition gridPosition = new GridPosition(x, z);
                Transform transformGridObj =
                    GameObject.Instantiate(prefab, GetWorldPosition(gridPosition), quaternion.identity);
                GridObjectVisual gridObjectVisual = transformGridObj.GetComponent<GridObjectVisual>();
                gridObjectVisual.SetGridObjectVisual(GetGridObjectPosition(gridPosition));
            }
        }
    }
    public GridPosition GetGridPosition(Vector3 worldPosition){
        return new GridPosition(
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize)
        );
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition){
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }


    public GridObject GetGridObjectPosition(GridPosition gridPosition){
        return gridObjectsArray[gridPosition.x, gridPosition.z];
    }
}