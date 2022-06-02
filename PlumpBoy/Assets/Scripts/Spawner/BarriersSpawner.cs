using UnityEngine;

public class BarriersSpawner : Spawner<Barrier>
{
    [SerializeField] private float _minSpawnHeight;
    [SerializeField] private float _maxSpawnHeight;
    [SerializeField] private Transform _spawnPoint;

    #region MonoBehaviour

    protected override void OnValidate()
    {
        base.OnValidate();
        if (_minSpawnHeight > _maxSpawnHeight)
        {
            _minSpawnHeight = _maxSpawnHeight;
        }
    }

    protected override void OnAwake() { }

    protected override void OnStart() { }

    #endregion

    protected override bool CheckSpawnAvailability() => true;

    protected override void Prepare(Barrier barrier)
    {
        var spawnHeight = Random.Range(_minSpawnHeight, _maxSpawnHeight);
        var spawnPoint = new Vector3(_spawnPoint.position.x, spawnHeight, _spawnPoint.position.z);
        barrier.transform.position = spawnPoint;
        barrier.gameObject.SetActive(true);
    }
}
