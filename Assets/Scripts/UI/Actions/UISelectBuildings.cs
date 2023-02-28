using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelectBuildings : MonoBehaviour
{
    [SerializeField]
    private bool _resources;

    private Button _button;

    private void OnEnable()
    {
        // checkear si los recursos son suficientes
        _button.interactable = _resources;
    }
}
