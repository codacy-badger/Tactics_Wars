using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables
    [Header("Actions Settings")]
    [SerializeField]
    private int _movementSpeed = 1;

    [Header("Game Events")]
    [SerializeField]
    private UnitEvent _onUnitSelectedEvent;
    [SerializeField]
    private VoidEvent _onEntityDeselectedEvent;
    [SerializeField]
    private ListVector3Event _updateActionAreaEvent;
    [SerializeField]
    private ListVector3Event _updateMovementArrowEvent;

    [Header("Entity Settings")]
    [SerializeField]
    private GameObject _unitsParent;
    [SerializeField]
    private GameObject _buildingsParent;

    private Camera _camera;

    private Unit _selectedUnit;

    private ActionHandler _actionHandler;
    private InputBaseState _currentState;
    private InputStateFactory _states;
    #endregion

    #region Getters and Setters
    public int MovementSpeed { get { return _movementSpeed; } }
    public Unit SelectedUnit { get { return _selectedUnit; } set { _selectedUnit = value; } }
    public UnitEvent OnUnitSelectedEvent { get { return _onUnitSelectedEvent; } }
    public VoidEvent OnEntityDeselectedEvent { get { return _onEntityDeselectedEvent; } }
    public ListVector3Event UpdateActionAreaEvent { get { return _updateActionAreaEvent; } }
    public ListVector3Event UpdateMovementArrowEvent { get { return _updateMovementArrowEvent; } }
    public GameObject UnitsParent { get { return _unitsParent; } }
    public GameObject BuildingsParent { get { return _buildingsParent; } }
    public InputBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public ActionHandler ActionHandler { get { return _actionHandler; } set { _actionHandler = value; } }
    #endregion

    void Start()
    {
        _actionHandler = new ActionHandler();
        _states = new InputStateFactory(this);
        _currentState = _states.NoAction();
        _currentState.EnterState();
        _camera = Camera.main;
    }

    void Update()
    {
        _currentState.UpdateState();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            Node node = Grid.Instance.GetNode(mousePosition);
            if (node != null)
            {
                node.ShowInfo();
            }
        }
    }

    public void SwitchState(InputBaseState state)
    {
        _currentState = state;
        state.EnterState();
    }

    #region OnClick Events
    public void SetMoveState()
    {
        SwitchState(_states.MoveAction());
    }

    public void SetAttackState()
    {
        SwitchState(_states.AttackAction());
    }

    public void SetBuildState(EntityInfoSO buildingInfo)
    {
        SwitchState(_states.BuildAction(buildingInfo));
    }

    public void SetRepairState()
    {
        SwitchState(_states.RepairAction());
    }

    public void FinalizeUnit()
    {
        SwitchState(_states.FinalizeUnit());
    }
    #endregion

    public Vector3 GetMouseWorldPosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector3 GetMouseNodePosition()
    {
        return Grid.Instance.GetNodeWorldPosition(GetMouseWorldPosition());
    }
}
