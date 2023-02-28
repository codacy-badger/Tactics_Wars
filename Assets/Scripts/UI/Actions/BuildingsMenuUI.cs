using UnityEngine;

public class BuildingsMenuUI : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private GameObject _unitBuidingsMenu;
    [SerializeField]
    private GameObject _resourceBuildingsMenu;

    [Header("Resource Buildings Buttons")]
    [SerializeField]
    private GameObject _windmillButton;
    [SerializeField]
    private GameObject _farmButton;
    [SerializeField]
    private GameObject _goldmineButton;

    public void ActivateMenu(Unit unit)
    {
        Node node = Grid.Instance.GetNode(unit.transform.position);

        _unitBuidingsMenu.SetActive(node.CanBuildUB);
        _resourceBuildingsMenu.SetActive(!node.CanBuildUB);

        if (!node.CanBuildFarm)
        {
            _windmillButton.SetActive(node.Resource == ResourceType.FOOD);
            _farmButton.SetActive(node.CanBuildFarm);
            _goldmineButton.SetActive(node.Resource == ResourceType.GOLD);
        }
    }
}
