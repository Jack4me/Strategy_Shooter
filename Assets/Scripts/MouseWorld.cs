using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour {
    private static MouseWorld Instance;
    [SerializeField] private LayerMask planeMask;

    private void Awake(){
        Instance = this;
    }

    void Update(){
        transform.position = GetMouseWorlPosition();
    }

    public static Vector3 GetMouseWorlPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, Instance.planeMask));
        return raycastHit.point;
    }
}