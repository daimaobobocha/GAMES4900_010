using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel4OnTouch : MonoBehaviour
{
    [SerializeField] private string targetSceneName = "Level4";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}