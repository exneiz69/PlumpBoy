using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private int _gameBuildIndex;

    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_gameBuildIndex);
    }
}
