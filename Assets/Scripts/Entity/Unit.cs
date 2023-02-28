using System.Collections.Generic;
using UnityEngine;

public class Unit : Entity
{
    [Header("Unit Settings")]
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _movementRange;
    [SerializeField]
    private int _attackRange;
    [SerializeField]
    private bool _hasMoved = false;
    [SerializeField]
    private bool _hasFinished = false;
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private Color _inactiveUnitColor;
    [SerializeField]
    private UnitType _unitType;
    [SerializeField]
    private List<UnitType> _weaknesses;

    private Animator _animator;

    public int Damage { get { return _damage; } }
    public int MovementRange { get { return _movementRange; } }
    public int AttackRange { get { return _attackRange; } }
    public bool HasMoved { get { return _hasMoved; } set { _hasMoved = value; } }
    public bool HasFinished
    {
        get { return _hasFinished; }
        set {
            _hasFinished = value;
            if (_hasFinished)
                _sprite.color = _inactiveUnitColor;
            else
                _sprite.color = Color.white;
        }
    }
    public UnitType UnitType { get { return _unitType; } }
    public List<UnitType> Weaknesses { get { return _weaknesses; } }
    public Animator Animator { get { return _animator; } }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void EntityDeath()
    {
        _animator.SetTrigger("Death");
    }

    public void DestroyObject() // called at the end of an animation
    {
        Destroy(gameObject);
    }
}

public enum UnitType
{
    NONE,
    ALDEANO,
    CABALLERO,
    CABALLERIA_LIGERA,
    ALABARDERO,
    PIQUERO,
    SOLDADO,
    MILICIA,
    BALLESTERO,
    ARQUERO
}