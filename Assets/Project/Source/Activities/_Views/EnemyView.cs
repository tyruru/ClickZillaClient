using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private MeshFilter  _meshFilter;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _nameText;
    
    // [SerializeField] private ParticleSystem _deadParticles;
    [SerializeField] private ParticleSystem _hitParticles;
    
    public event Action<int> OnDamaged;
    public event Action<int> OnKilled; 
    public void Dead()
    {
        // _deadParticles?.Play();   
    }
    
    public void Damage(int damage)
    {
        Debug.Log("Enemy damaged: " + damage);
        
        if (damage < 0)
        {
            Debug.LogError("Damage cannot be negative");
            return;
        }
        
        OnDamaged?.Invoke(damage);
        Instantiate(_hitParticles, transform.position, Quaternion.identity);   
    }

    public void SetMesh(Mesh mesh)
    {
        if (mesh == null)
        {
            Debug.LogError("Mesh is null");
            return;
        }
        _meshFilter.sharedMesh = mesh;
    }
    
    
    public void SetName(string name)
    {
        _nameText.text = name;
    }
    
    public void SetHpValue(int currentHp, int maxHp)
    {
        Debug.Log("Hp view updated: " + currentHp + "/" + maxHp);
        _hpSlider.value = currentHp/(float)maxHp;
        _hpText.text = currentHp + "/" + maxHp;
    }

    public void OnEnemyKilled(int exp)
    {
        OnKilled?.Invoke(exp);
    }
}
