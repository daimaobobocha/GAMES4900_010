using UnityEngine;
using UnityEngine.SceneManagement;

public class LL4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level4");
        }
    }
}