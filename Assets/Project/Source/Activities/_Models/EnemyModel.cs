using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public Sprite Icon { get; private set; }

    public List<Mesh> Meshes { get; private set; }

    private Mesh _currentMesh;
    public Mesh CurrentMesh
    {
        get => _currentMesh;
        set
        {
            _currentMesh = value;
            OnMeshChanged?.Invoke(value);
        }
    }
    public int CurrentHp { get; private set; }
    public int MaxHp { get; private set; }
    public string Name { get; private set; } 

    public event Action OnChanged;
    public event Action OnDamaged;
    public event Action OnDead;
    public event Action<Mesh> OnMeshChanged;
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
        
        ChangeMesh();

        OnDamaged?.Invoke();

        if (CurrentHp == 0)
        {
            OnDead?.Invoke();
        }
    }

    private void ChangeMesh()
    {
        if (Meshes == null)
        {
            Debug.LogError("Meshes are not set for the enemy model.");
            return;
        }

        // *** Change in future to something normal ***
        if (CurrentHp <= MaxHp / 3)
        {
            if (_currentMesh != Meshes[2])
                CurrentMesh = Meshes[2];
        }
        else if(CurrentHp <= MaxHp / 1.5)
        {
            if(_currentMesh != Meshes[1])
                CurrentMesh = Meshes[1];
        }
        else
        {
            if(_currentMesh != Meshes[0])
                CurrentMesh = Meshes[0];
        }
    }

    public void SetData(EnemyData enemyData)
    {
        Meshes = enemyData.BuildingMeshes;
        MaxHp = enemyData.Hp;
        CurrentHp = MaxHp;
        Name = enemyData.Name;
        CurrentMesh = Meshes[0];
        Debug.Log("Set new Enemy: " + Name);
        
        OnChanged?.Invoke();
    }
   
}