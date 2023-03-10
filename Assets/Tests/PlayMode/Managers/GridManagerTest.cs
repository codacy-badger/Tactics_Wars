using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Tilemaps;

public class GridManagerTest
{
    [UnityTest]
    public IEnumerator Positive_InitializeGrid()
    {
        GridManager manager = A.GridManager;
        yield return null;

        Assert.IsNotNull(Grid.Instance);
        Assert.AreEqual(10, Grid.Instance.Width);
        Assert.AreEqual(10, Grid.Instance.Height);
        Assert.AreEqual(4, Grid.Instance.GetNode(1, 1).Neighbours.Count);
    }
}
