using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        
    }
    private void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }
    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(this.transform.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(this.transform.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.ToString();
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
