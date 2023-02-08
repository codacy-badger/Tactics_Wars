using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private int _health;
    [SerializeField]
    private TeamEnum _team;

    public string Name { get { return _name; } }
    public int Health { get { return _health; } set { _health = Mathf.Max(0, value); } }
    public TeamEnum Team { get { return _team; } private set { _team = value; } }

    public void SetEntityInGrid()
    {
        Node node = Grid.Instance.GetNode(transform.position);
        node.AddEntity(this);
    }

    public abstract void ApplyDamage();
}

public enum TeamEnum
{
    BLUE = 0,
    RED = 1
}