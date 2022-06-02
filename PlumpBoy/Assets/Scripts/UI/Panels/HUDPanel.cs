using UnityEngine;

public class HUDPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreView _scoreView;

    #region MonoBehaviour

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    #endregion

    private void OnScoreChanged()
    {
        _scoreView.Render(_player.Score);
    }
}
