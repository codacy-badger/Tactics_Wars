using UnityEngine;
using UnityEngine.UI;

public class UnitActionsUIManager : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField]
    private GameObject _actionsPanel;
    [SerializeField]
    private Button _moveButton;
    [SerializeField]
    private Button _attackButton;
    [SerializeField]
    private Button _finalizeButton;

    [Header("Debug Settings")]
    [SerializeField]
    private bool _isMoveActive;
    [SerializeField]
    private bool _isAttackActive;
    [SerializeField]
    private bool _isFinalizeActive;

    public void ShowEvent(Unit unit)
    {
        _actionsPanel.SetActive(true);
        _moveButton.interactable = !unit.HasMoved;
        _attackButton.interactable = _isAttackActive;
        _finalizeButton.interactable = _isFinalizeActive;
    }

    public void CleanUI()
    {
        _actionsPanel.SetActive(false);
    }
}
