using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject m_ShopPanel;

    public void Update()
    {
        if(Input.GetKey(KeyCode.S))
        {
            OnMenuClick();
        }
    }

    public void OnMenuClick()
    {
        m_ShopPanel.SetActive(!m_ShopPanel.activeSelf);
    }
}
