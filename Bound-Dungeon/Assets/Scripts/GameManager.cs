using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private string nextSceneName = "stage2";
    [SerializeField] private GameObject GameOverPanel;
    public  static GameManager Instance {  get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if(GameOverPanel != null)
        {
            GameOverPanel.SetActive(false);
        }
    }

    public void Judge()
    {
        //シーン上に"Enemy"タグの付いたオブジェクトがなければ次のシーン
        if(GameObject.FindWithTag("Enemy") == null)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            if(GameOverPanel != null)
            {
                GameOverPanel.SetActive(true);
            }
        }
    }

    public void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
