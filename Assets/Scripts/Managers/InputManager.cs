using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = GetMouseWorlPosition();
            Node node = Grid.Instance.GetNode(mousePosition);

            Debug.Log(node.GetInfo());
        }
    }

    private Vector3 GetMouseWorlPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
