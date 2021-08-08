using UnityEngine;

public class envCloudFX : MonoBehaviour
{
    public float movementSpeed = 2f;// Speed ​​setting

    void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);// Object movement

    }
}
