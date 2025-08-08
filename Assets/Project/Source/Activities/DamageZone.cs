using UnityEngine;
using UnityEngine.UI;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private int _damage = 10;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(DealDamage);
    }

    private void DealDamage()
    {
        _enemyView.Damage(_damage);
    }
}