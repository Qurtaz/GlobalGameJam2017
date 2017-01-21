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

    public override string ToString()
    {
        return "(" +
            X.ToString() + ", " + Z.ToString() + ")";
    }

    public string ToStringOnSeparateLines()
    {
        return X.ToString() + "\n" + Z.ToString();
    }

    public static CellCoordinates FromPosition(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int z = Mathf.RoundToInt(position.z);

        return new CellCoordinates(x, z);
    }
}

