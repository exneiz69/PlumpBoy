using System;
using UnityEngine;
using UnityEngine.Events;

public class Barrier : MonoBehaviour, IFinishable<Barrier>
{
    private bool _isAlive = true;

    public event UnityAction<Barrier> Finished;

    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAlive)
        {
            if (collision.TryGetComponent<Player>(out Player player))
            {
                player.Die();
            }
        }
    }

    #endregion

    public void Destroy()
    {
        if (_isAlive)
        {
            _isAlive = false;
            Finished?.Invoke(this);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Restart()
    {
        _isAlive = true;
    }
}
