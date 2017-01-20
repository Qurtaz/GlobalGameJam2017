using UnityEngine;

public class CellGrid : MonoBehaviour
{
    public int width = 10;
    public int height = 16;

    public Cell cellPrefab;
    GridMesh gridMesh;

    Cell[] cells;

    void Awake()
    {
        gridMesh = GetComponentInChildren<GridMesh>();

        cells = new Cell[height * width];

        for (int z = 0, i = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    void Start()
    {
        gridMesh.Triangulate(cells);
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = x;
        position.y = 0f;
        position.z = z;

        Cell cell = cells[i] = Instantiate<Cell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
    }
}
