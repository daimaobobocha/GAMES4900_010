using UnityEngine;
using System.Collections;

public class DisappearFloor : MonoBehaviour
{
    [SerializeField] private float delay = 0.2f;

    private bool hasTriggered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (hasTriggered) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}