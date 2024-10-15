using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private Animator animatotor;
    public float speed = 5.0f; // Vitesse de déplacement
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 newPosition = targetPosition + new Vector3(0, 1, 0);
            if (CheckTagAtPosition(newPosition, "Sol"))
            {
                targetPosition = newPosition;
            }
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }

    bool CheckTagAtPosition(Vector3 position, string tag)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
