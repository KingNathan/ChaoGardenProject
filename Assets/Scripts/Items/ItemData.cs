using UnityEngine;

[CreateAssetMenu(menuName ="Data/Item")]
public class ItemData : ScriptableObject {
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _value;
    [SerializeField] private Sprite _sprite;

    public string Name { get { return _name; } }
    public string Description { get { return _description; } }
    public int Value { get { return _value; } }
    public Sprite Sprite { get { return _sprite; } }
}
