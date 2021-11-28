using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _target;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeLastSpawn;
    private int _spawnedEnemies;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)        
            return;

        _timeLastSpawn += Time.deltaTime;

        if(_timeLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawnedEnemies++;
            _timeLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawnedEnemies, _currentWave.Count);
        }

        if(_currentWave.Count<= _spawnedEnemies)
        {
            if(_waves.Count > _currentWaveNumber + 1)            
                AllEnemySpawned?.Invoke();

            _currentWave = null;           
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawnedEnemies = 0;
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _target.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
