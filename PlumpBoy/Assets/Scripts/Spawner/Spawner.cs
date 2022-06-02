using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component, IFinishable<T>
{
    [SerializeField] private T _prefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private GameObject _poolContainer;
    [SerializeField] private int _poolCapacity;

    protected ObjectPool<T> ObjectPool => _objectPool;

    private ObjectPool<T> _objectPool;

    #region MonoBehaviour

    protected virtual void OnValidate()
    {
        _secondsBetweenSpawn = _secondsBetweenSpawn < 0 ? 0 : _secondsBetweenSpawn;
        _poolCapacity = _poolCapacity < 0 ? 0 : _poolCapacity;
    }

    protected abstract void OnAwake();

    protected abstract void OnStart();

    private void Awake()
    {
        _objectPool = new ObjectPool<T>(_poolContainer, _poolCapacity, _prefab);
        OnAwake();
    }

    private void Start()
    {
        Timer.Instance.AddWaitingAction(Spawn, _secondsBetweenSpawn);
        OnStart();
    }

    #endregion

    protected abstract bool CheckSpawnAvailability();

    protected abstract void Prepare(T spawnObject);

    private void Spawn()
    {
        if (CheckSpawnAvailability())
        {
            if (_objectPool.TryGetObject(out T spawnObject))
            {
                Prepare(spawnObject);
            }
        }
        Timer.Instance.AddWaitingAction(Spawn, _secondsBetweenSpawn);
    }
}
