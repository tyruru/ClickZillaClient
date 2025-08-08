using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : IDisposable, IInitializable
{
    private EnemyView _enemyView;
    private EnemiesDataDefinition _enemiesDef;
    private EnemyModel _enemyModel;
    
    public EnemyController(EnemyView enemyView, EnemiesDataDefinition enemiesDef)
    {
        _enemyView = enemyView;
        _enemiesDef = enemiesDef;
        _enemyModel = new EnemyModel();
        
        _enemyModel.OnChanged += ChangeEnemyView;
        _enemyModel.OnDamaged += ChangeEnemyHpView;
        _enemyView.OnDamaged += _enemyModel.Damage;
        _enemyModel.OnDead +=  SetRandomEnemy;
        _enemyModel.OnDead +=  _enemyView.Dead;
        _enemyModel.OnAddedExp += _enemyView.GiveExp;
    }
    
    public void Initialize()
    {
        if (!_enemiesDef.EnemyList.Any())
        {
            Debug.LogError("No enemies available in the definition");
            return;
        }

        SetRandomEnemy();
    }

    public void SetRandomEnemy()
    {
        var randomIndex = Random.Range(0, _enemiesDef.EnemyList.Count());

        var randomEnemyModel = _enemiesDef.EnemyList.ElementAt(randomIndex);
        
        _enemyModel.SetData(randomEnemyModel);
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
        _enemyModel.OnDead -=  SetRandomEnemy;
        _enemyModel.OnDead -=  _enemyView.Dead;
        _enemyModel.OnAddedExp -= _enemyView.GiveExp;
    }
}