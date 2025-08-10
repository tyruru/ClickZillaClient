using System;
using UnityEngine;

public class EnemyController : IDisposable
{
    private readonly EnemyView _enemyView;
    private readonly EnemyModel _enemyModel;
    
    public string EnemyName => _enemyModel.Name;
    
    public event Action<string> OnEnemyDead;
    
    public EnemyController(EnemyView enemyView)
    {
        _enemyView = enemyView;
        _enemyModel = new EnemyModel();
        
        _enemyModel.OnChanged += ChangeEnemyView;
        _enemyModel.OnDamaged += ChangeEnemyHpView;
        _enemyView.OnDamaged += _enemyModel.Damage;
        _enemyModel.OnDead +=  OnDead;
    }
    
    public void SetEnemyData(EnemyData enemyData)
    {
        if (enemyData == null)
        {
            Debug.LogError("Enemy data is null");
            return;
        }
        
        _enemyModel.SetData(enemyData);
    }

    private void OnDead()
    {
        OnEnemyDead?.Invoke(_enemyModel.Name);
        _enemyView.Dead();
    }
    
    private void ChangeEnemyHpView()
    {
        _enemyView.SetHpValue(_enemyModel.CurrentHp, _enemyModel.MaxHp);
    }
    
    private void ChangeEnemyView()
    {
        _enemyView.SetSprite(_enemyModel.Icon);
        _enemyView.SetHpValue(_enemyModel.CurrentHp, _enemyModel.MaxHp);
    }

    public void Dispose()
    {
        _enemyModel.OnChanged -= ChangeEnemyView;
        _enemyModel.OnDamaged -= ChangeEnemyHpView;
        _enemyView.OnDamaged -= _enemyModel.Damage;
        _enemyModel.OnDead -=  OnDead;
    }
}