using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MainMenuPanel))]
public class MainMenuButtonsHandler : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private GameLoader _gameLoader;

    #region MonoBehaviour

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }

    #endregion

    private void OnStartButtonClick()
    {
        _gameLoader.Load();
    }
}
