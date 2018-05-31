using UnityEngine;

[CreateAssetMenu(menuName = "Data/Food")]
public class FoodData : ItemData {
    [SerializeField] private int _food;

    public int Food { get { return _food; } }
}
