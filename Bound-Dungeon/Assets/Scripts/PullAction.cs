using UnityEngine;
using UnityEngine.InputSystem;
public class PullAction : MonoBehaviour
{
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;
    private Vector2 startPosition;
    private bool isPulled = false;
    private bool isDrag = false;

    [SerializeField] private float forceMultiplier = 5f; //移動する力の強さを調整するための変数
    [SerializeField] private float lineLengthMultiplier = 1.0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false; //引っ張っていなければ非表示
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

            lineRenderer.enabled = true;
        }
        //ドラッグしているとき
        if(isDrag)
        {
            Vector2 screenPosition = pointer.position.ReadValue();
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            //飛ぶ方向を計算
            Vector2 PullDirection = (startPosition - currentPosition);
            Vector3 lineStart = new Vector3(transform.position.x, transform.position.y, 0f);
            Vector3 lineEnd = lineStart + new Vector3(PullDirection.x, PullDirection.y, 0f);
            //飛ぶ方向へ線を伸ばす
            lineRenderer.SetPosition(0, lineStart);
            lineRenderer.SetPosition(1, lineEnd);
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

            lineRenderer.enabled = false;//線を消す
        }
    }
}
