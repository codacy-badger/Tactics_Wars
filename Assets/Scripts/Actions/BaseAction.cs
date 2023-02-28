using System;

public abstract class BaseAction
{
    private Action _actionFinished;

    public Action ActionFinished { get { return _actionFinished; } set { _actionFinished = value; } }

    public abstract void Execute();

    protected void FinishAction()
    {
        _actionFinished?.Invoke();
    }
}
