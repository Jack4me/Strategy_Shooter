
using System.Collections.Generic;
using Unity.VisualScripting;

public class GridObject {
    private GridSystem gridSystem;
    private GridPosition _gridPosition;
    private List<Unit> unitList;
    public GridObject(GridSystem _gridSystem, GridPosition gridPosition){
        gridSystem = _gridSystem;
        _gridPosition = gridPosition;
        unitList = new List<Unit>();

    }
     
    public override string ToString(){
        string unitName = "";
        foreach (Unit unit in unitList){
            unitName += unit.name + "\n";
        }
        return _gridPosition.ToString() + "\n" + unitName;
    }


    public void AddUnitList(Unit _unit){
        unitList.Add(_unit);
        
    }

    public void RemoveUnit(Unit _unit){
        unitList.Remove(_unit);
    }
    public List<Unit> GetUnitListAtGrid(){
       return unitList;
    }
}
