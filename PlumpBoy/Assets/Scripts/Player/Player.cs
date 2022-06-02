using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private int _score;
    private bool _alive = true;

    public event UnityEngine.Events.UnityAction ScoreChanged;
    public event UnityEngine.Events.UnityAction Died;

    public int Score => _score;

    #region MonoBehaviour

    private void Start()
    {
        ScoreChanged?.Invoke();
    }

    #endregion

    public void Die()
    {
        if (_alive)
        {
            _alive = false;
            Died?.Invoke();
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    public void Reward()
    {
        _score++;
        ScoreChanged?.Invoke();
    }
}
