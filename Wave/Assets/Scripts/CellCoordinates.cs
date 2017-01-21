using UnityEngine;

[System.Serializable]
public struct CellCoordinates
{
    [SerializeField]
    private int x, z;

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Z
    {
        get
        {
            return z;
        }
    }

    public CellCoordinates(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public int Y
    {
        get
        {
            return -X - Z;
        }
    }

    public override string ToString()
    {
        return "(" +
            X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return X.ToString() + "\n" + Y.ToString() + "\n" + Z.ToString();
    }

    public static CellCoordinates FromPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);

        return new CellCoordinates(x, y);
    }
}

