using UnityEngine;

public class RewardArea : MonoBehaviour
{
    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.TryGetComponent<Player>(out Player player))
        {
            player.Reward();
        }
    }

    #endregion
}
