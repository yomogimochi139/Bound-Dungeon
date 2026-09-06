using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus Instance { get; private set; }

    [SerializeField] public float attackPoint = 1f; //1ヒット当たりの攻撃力
    [SerializeField] public float characterScale = 1.0f;　//キャラクターの大きさ
    [SerializeField] public bool isPenetration = false; //貫通するかどうか

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ステータスを変更
    public void StatusUp(CustomType type)
    {
        switch(type)
        {
            case CustomType.PowerUp:
                attackPoint += 0.5f;
                break;
            case CustomType.ScaleUp:
                characterScale += 0.1f;
                transform.localScale = Vector3.one * characterScale;
                break;
            case CustomType.Penetration:
                if(!isPenetration)
                {
                    isPenetration = true;
                }
                else
                {
                    // すでに貫通状態の場合は攻撃力を上げる
                    attackPoint += 0.5f;
                }
                break;
        }
    }

    // ステータスを初期化
    public void StatusReset()
    {
        attackPoint = 1f;
        characterScale = 1.0f;
        isPenetration = false;
    }
}
