using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameOverMenuPanel _gameOverMenu;

    #region MonoBehaviour

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    #endregion

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Reload()
    {
        Time.timeScale = 1;
        int activeSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(activeSceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void OnDied()
    {
        _gameOverMenu.Init(_player.Score);
        _gameOverMenu.Show();
        Pause();
    }
}
