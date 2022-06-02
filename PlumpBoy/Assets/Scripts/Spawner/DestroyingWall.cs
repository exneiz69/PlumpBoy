using UnityEngine;

public class DestroyingWall : MonoBehaviour
{
    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Barrier>(out Barrier barrier))
        {
            barrier.Destroy();
        }
    }

    #endregion
}
