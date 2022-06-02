public class ScoreView : TMPView<int>
{
    #region MonoBehaviour

    protected override void OnAwake() { }

    #endregion

    public override void Render(int score)
    {
        Text.text = score.ToString();
    }
}
