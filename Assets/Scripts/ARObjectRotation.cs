using UnityEngine;

public class ARObjectRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    private bool isRotating = false;

    void Update()
    {

        if (isRotating)
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f, Space.Self);
        }
    }


    public void StartRotation()
    {
        isRotating = true;
    }


    public void StopRotation()
    {
        isRotating = false;
    }
}
