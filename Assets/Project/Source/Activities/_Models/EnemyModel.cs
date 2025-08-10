using System;
using UnityEngine;

public class EnemyModel
{
    public Sprite Icon { get; private set; }
    public int CurrentHp { get; private set; }
    public int MaxHp { get; private set; }
    public string Name { get; private set; } 

    public event Action OnChanged;
    public event Action OnDamaged;
    public event Action OnDead;
    public EnemyModel()
    {
        
    }

    public void Damage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogError("Damage cannot be negative");
            return;
        }
        
        CurrentHp -= damage;
        if (CurrentHp < 0) CurrentHp = 0;

        OnDamaged?.Invoke();

        if (CurrentHp == 0)
        {
            OnDead?.Invoke();
        }
    }
    
    public void SetData(EnemyData enemyData)
    {
        Icon = enemyData.Icon;
        MaxHp = enemyData.Hp;
        CurrentHp = MaxHp;
        Name = enemyData.Name;

        Debug.Log("Set new Enemy: " + Name);
        
        OnChanged?.Invoke();
    }
   
}