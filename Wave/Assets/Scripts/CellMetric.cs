using UnityEngine;

public class CellMetric : MonoBehaviour
{

    public const float cellRadius = 0.5f;

    public static Vector3[] corners = {
        new Vector3(cellRadius, 0f, -cellRadius),
        new Vector3(cellRadius, 0f, cellRadius),
        new Vector3(-cellRadius, 0f, -cellRadius),
        new Vector3(-cellRadius, 0f, cellRadius),
        new Vector3(cellRadius, 0f, -cellRadius),
    };
}
