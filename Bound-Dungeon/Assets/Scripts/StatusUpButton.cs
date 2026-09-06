using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusUpButton : MonoBehaviour
{
    [SerializeField] private CustomType StatusType;//強化するステータスの種類を指定する
    [SerializeField] private string nextSceneName = "stage2";//次のシーンの名前を指定する

    public void OnSelectStatusUp()
    {
        if (PlayerStatus.Instance != null)
        {
            PlayerStatus.Instance.StatusUp(StatusType);
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
