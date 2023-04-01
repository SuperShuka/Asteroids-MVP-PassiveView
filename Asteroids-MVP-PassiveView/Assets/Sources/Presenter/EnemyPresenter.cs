using UnityEngine;

public class EnemyPresenter : Presenter
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Enemy"))
        {
            DestroyCompose();
        }
    }
}
