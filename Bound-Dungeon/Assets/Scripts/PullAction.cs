using UnityEngine;
using UnityEngine.InputSystem;
public class PullAction : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private bool isPulled = false;
    private bool isDrag = false;

    [SerializeField] private float forceMultiplier = 5f; //移動する力の強さを調整するための変数

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPulled ) return;
        // InputSystemのPointerを使用して、マウスやタッチの入力を取得する
        var pointer = Pointer.current;
        if (pointer == null ) return;
        //ボタンを押した瞬間にドラッグ開始位置を記録する
        if (pointer.press.wasPressedThisFrame)
        {
            isDrag = true;
            Vector2 screenPosition = pointer.position.ReadValue();
            startPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        }
        //ボタンを離した瞬間にドラッグ終了位置を記録し、力を加える
        if (pointer.press.wasReleasedThisFrame && isDrag)
        {
            Vector2 screenPosition = pointer.position.ReadValue();
            Vector2 endPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            Vector2 force = (startPosition - endPosition) * forceMultiplier;
            rb.AddForce(force, ForceMode2D.Impulse);

            isPulled = true;
            isDrag = false;
        }
    }
}
