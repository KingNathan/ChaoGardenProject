using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fruit_Orange : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Camera m_Camera;

    private int m_UILayer;

    [Header("Fruit de base")]
    public GameObject m_OrangePrefab;

    private Vector2 m_OrangeStartPosition = new Vector2();
    private Vector2 m_OrangeInstantiatePosition = new Vector2();

    private void Awake()
    {
        m_UILayer = LayerMask.GetMask("UI");
        m_OrangeStartPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {        
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit m_hit;
        Ray m_Ray = m_Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(m_Ray, out m_hit, m_UILayer))
        {
            transform.localPosition = m_OrangeStartPosition;
        } else
        {
            transform.localPosition = m_OrangeStartPosition;
            m_OrangeInstantiatePosition = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(m_OrangePrefab, m_OrangeInstantiatePosition, Quaternion.identity);
        }
    }
}
