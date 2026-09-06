using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("‘Ì—Í")]
    [SerializeField] private int hp = 5;

    [Header("ˆÚ“®")]
    [SerializeField] private EnemyMoveAxis enemyAxis = EnemyMoveAxis.X;
    [SerializeField] private float enemyspeed = 1.5f;
    [SerializeField] private float moveDistance = 2f;

    public enum EnemyMoveAxis
    {
        None,
        X,
        Y
    }

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {

        if(enemyAxis == EnemyMoveAxis.None) return;

        float offset = Mathf.PingPong(Time.time * enemyspeed, moveDistance);

        if(enemyAxis == EnemyMoveAxis.X)
        {
            transform.position = startPosition + new Vector3(offset, 0, 0);
        }
        else
        {
            transform.position = startPosition + new Vector3(0, offset, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           hp--;
           if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }   
}
