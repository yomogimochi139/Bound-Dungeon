using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string _loadScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_loadScene);
    }
}
