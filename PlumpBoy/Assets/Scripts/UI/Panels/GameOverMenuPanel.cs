using UnityEngine;

public class GameOverMenuPanel : HideablePanel
{
    [SerializeField] private ScoreView _scoreView;

    #region MonoBehaviour

    protected override void OnAwake() { }

    #endregion

    public void Init(int score) => _scoreView.Render(score);
}
