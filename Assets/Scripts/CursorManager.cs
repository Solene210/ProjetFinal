using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    #region Unity Life Cycle
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Press the space bar to apply no locking to the Cursor
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            Cursor.lockState = CursorLockMode.None;
        if (Input.GetKeyUp(KeyCode.LeftAlt))
            Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion
}
