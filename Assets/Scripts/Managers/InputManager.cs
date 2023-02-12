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

    [SerializeField]
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
    public InputBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    //public InputStateFactory States { get { return _states; } set { _states = value; } }
    public ActionHandler ActionHandler { get { return _actionHandler; } set { _actionHandler = value; } }
    #endregion

    void Start()
    {
        _actionHandler = new ActionHandler();
        _states = new InputStateFactory(this);
        _currentState = _states.NoAction();
        _currentState.EnterState();
    }

    void Update()
    {
        _currentState.UpdateState();
    }

    public void SwitchState(InputBaseState state)
    {
        // Hay que mirar si esta funcion se puede elimirar, en InputBaseState existe SwitchSate
        _currentState = state;
        state.EnterState();
    }

    #region OnClick Events
    public void SetMoveState() // called from button click event
    {
        SwitchState(_states.MoveAction());
    }

    public void SetAttackState() // called from button click event
    {
        SwitchState(_states.AttackAction());
    }
    #endregion

    public Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector3 GetMouseNodePosition()
    {
        return Grid.Instance.GetNodeWorldPosition(GetMouseWorldPosition());
    }
}
