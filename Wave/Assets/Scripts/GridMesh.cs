using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridMesh : MonoBehaviour
{

    Mesh gridMesh;
    List<Vector3> vertices;
    List<int> triangles;

    void Awake()
    {
        GetComponent<MeshFilter>().mesh = gridMesh = new Mesh();
        gridMesh.name = "Grid Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    public void Triangulate(Cell[] cells)
    {
        gridMesh.Clear();
        vertices.Clear();
        triangles.Clear();
        for (int i = 0; i < cells.Length; i++)
        {
            Triangulate(cells[i]);
        }
        gridMesh.vertices = vertices.ToArray();
        gridMesh.triangles = triangles.ToArray();
        gridMesh.RecalculateNormals();
    }

    void Triangulate(Cell cell)
    {
        Vector3 center = cell.transform.localPosition;

        AddTriangle(
            center + CellMetric.corners[1],
            center + CellMetric.corners[2],
            center + CellMetric.corners[3]
        );
        AddTriangle(
            center + CellMetric.corners[2],
            center + CellMetric.corners[1],
            center + CellMetric.corners[4]
        );
    }

    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex + 1);
        triangles.Add(vertexIndex + 2);
    }



  //  public Cell GetCell(Vector3 position)
  //  {
     //   position = transform.InverseTransformPoint(position);
     //   CellCoordinates coordinates = HexCoordinates.FromPosition(position);
      //  int index =
     //       coordinates.X + coordinates.Z * cellCountX + coordinates.Z / 2;
    //    return cells[index];
  //  }
}