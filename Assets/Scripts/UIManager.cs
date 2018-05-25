using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject m_ShopPanel;
    public TextMeshProUGUI m_ShopButtonText;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            OnMenuClick();
        }
    }

    public void OnMenuClick()
    {
        m_ShopPanel.SetActive(!m_ShopPanel.activeSelf);
        if (m_ShopPanel.activeSelf)
            m_ShopButtonText.text = "Close";
        else
            m_ShopButtonText.text = "Shop";
    }
}
