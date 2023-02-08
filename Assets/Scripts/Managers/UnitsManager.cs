using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class UnitsManager : MonoBehaviour
{
    public void AddUnitToGrid()
    {
        Entity[] entities = this.GetComponentsInChildren<Entity>();
        foreach (Entity entity in entities)
        {
            Node node = Grid.Instance.GetNode(entity.transform.position);
            if (node != null)
            {
                node.AddEntity(entity);
            }
        }
    }
}
