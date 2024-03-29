using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    private void OnMouseDown()
    {
        if(isPlaceable)
        {
            Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            this.isPlaceable = false;
        }
    }
}
