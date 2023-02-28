public abstract class InputBaseState
{
    private InputManager _context;
    private InputStateFactory _factory;
    private InputBaseState _nextState;

    protected InputManager Context { get { return _context; } }
    protected InputStateFactory Factory { get { return _factory; } }
    protected InputBaseState NextState { get { return _nextState; } set { _nextState = value; } }

    protected InputBaseState(InputManager context, InputStateFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();

    public void SwitchToNextState()
    {
        SwitchState(_nextState);
    }

    protected void SwitchState(InputBaseState newState)
    {
        // Se podria definir un metodo ExitState con la logica necesaria para salir del estado
        newState.EnterState();
        _context.CurrentState = newState;
    }
}
