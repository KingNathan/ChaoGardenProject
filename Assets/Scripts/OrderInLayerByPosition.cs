using UnityEngine;

public class OrderInLayerByPosition : MonoBehaviour {
    [SerializeField] SpriteRenderer _spriteRenderer;

	private void Update () {
        _spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }
}
