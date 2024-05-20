using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBtnUI : MonoBehaviour
{
    public void EnablePopUp(GameObject obj)
    {
        Time.timeScale = 0;
        obj.SetActive(true);
    }

    public void DisablePopUp(GameObject obj)
    {
        Time.timeScale = 1;
        obj.SetActive(false);
    }
}
