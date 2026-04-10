using UnityEngine;
using System.Collections;

public class BD : MonoBehaviour
{
    [SerializeField] private Transform door;

    private bool Touch = false;
    private bool Busy = false;
    private Vector3 StartPos;

    private void Start()
    {
        StartPos = door.localPosition;
    }

    private void Update()
    {
        if (Touch && !Busy && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(OpenThenReset());
        }
    }

    private IEnumerator OpenThenReset()
    {
        Busy = true;
        door.localPosition = StartPos + new Vector3(0f, 3f, 0f);
        yield return new WaitForSeconds(3f);
        door.localPosition = StartPos;
        Busy = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Touch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Touch = false;
        }
    }
}