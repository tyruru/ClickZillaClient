using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "SO/EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] private Sprite _icon { get; set; }
    [field: SerializeField] private int _hp { get; set; }
    [field: SerializeField] private string _name { get; set; }
    [field: SerializeField] private int _exp { get; set; }
    
    public Sprite Icon => _icon;
    public int Hp => _hp;
    public string Name => _name;
    public int Exp => _exp;
}