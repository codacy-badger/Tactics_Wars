using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitActionsUIManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField]
    private UnitEvent _onBuildActionSelected;

    [Header("Unit Actions")]
    [SerializeField]
    private GameObject _actionsPanel;
    [SerializeField]
    private Button _moveButton;
    [SerializeField]
    private Button _attackButton;
    [SerializeField]
    private Button _finalizeButton;
    [SerializeField]
    private Button _buildButton;
    [SerializeField]
    private Button _repairButton;

    [Header("Buildings Menu")]
    [SerializeField]
    private GameObject _buildingMenu;

    private const int NUM_OF_BUTTONS = 5;
    private Button[] _buttons;
    private Unit _unit;

    void Awake()
    {
        _buttons = new Button[NUM_OF_BUTTONS];

        _buttons[0] = _moveButton;
        _buttons[1] = _attackButton;
        _buttons[2] = _finalizeButton;
        _buttons[3] = _buildButton;
        _buttons[4] = _repairButton;
    }

    public void CleanUI()
    {
        _actionsPanel.SetActive(false);
        _buildingMenu.SetActive(false);
    }

    public void ShowUnitActions(Unit unit)
    {
        _unit = unit;
        _actionsPanel.SetActive(true);

        _buildButton.gameObject.SetActive(_unit.UnitType == UnitType.ALDEANO);
        _repairButton.gameObject.SetActive(_unit.UnitType == UnitType.ALDEANO);

        if (_unit.HasFinished)
        {
            DeactivateButtons();
        }
        else
        {
            ShowMoveButton();
            ShowAttackButton();
            ShowFinalizeButton();
            ShowBuildButton();
            ShowRepairButton();
        }
    }

    private void DeactivateButtons()
    {
        foreach (Button button in _buttons)
        {
            button.interactable = false;
        }
    }

    private void ShowMoveButton()
    {
        _moveButton.interactable = !_unit.HasMoved;
    }

    private void ShowAttackButton()
    {
        List<Vector3> attackArea = Pathfinding.Instance.GetAttackArea(
            _unit.transform.position,
            _unit.AttackRange);

        _attackButton.interactable = attackArea.Count > 0;
    }

    private void ShowFinalizeButton()
    {
        _finalizeButton.interactable = true;
    }

    private void ShowBuildButton()
    {
        if (_unit.UnitType != UnitType.ALDEANO)
        {
            _buildButton.gameObject.SetActive(false);
            return;
        }

        _buildButton.gameObject.SetActive(true);
        Node node = Grid.Instance.GetNode(_unit.transform.position);

        if (node.Resource != ResourceType.NONE)
            _buildButton.interactable = true;
        else if (node.CanBuildUB)
            _buildButton.interactable = true;
        else
            _buildButton.interactable = false;
    }

    private void ShowRepairButton()
    {
        if (_unit.UnitType != UnitType.ALDEANO)
        {
            _repairButton.gameObject.SetActive(false);
            return;
        }

        _repairButton.gameObject.SetActive(true);
        Node node = Grid.Instance.GetNode(_unit.transform.position);
        _repairButton.interactable = node.GetEntity(0) != null;
    }

    public void RaiseBuildButtonEvent()
    {
        _onBuildActionSelected?.Raise(_unit);
    }
}
