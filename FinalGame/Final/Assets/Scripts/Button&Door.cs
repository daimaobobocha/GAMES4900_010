using UnityEngine;
using System.Collections;

public class ButtonDoorTrigger : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private float moveUpAmount = 3f;
    [SerializeField] private float resetDelay = 3f;

    private bool playerInRange = false;
    private bool isBusy = false;

    private Vector3 doorStartLocalPos;

    private void Start()
    {
        doorStartLocalPos = door.localPosition;
    }

    private void Update()
    {
        if (playerInRange && !isBusy && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(OpenThenReset());
        }
    }

    private IEnumerator OpenThenReset()
    {
        isBusy = true;

        door.localPosition = doorStartLocalPos + new Vector3(0f, moveUpAmount, 0f);

        yield return new WaitForSeconds(resetDelay);

        door.localPosition = doorStartLocalPos;

        isBusy = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}