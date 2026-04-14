using UnityEngine;
using UnityEngine.SceneManagement;

public class LL5 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level5");
        }
    }
}