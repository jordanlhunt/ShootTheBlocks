/* 
 * Shooterv4.cs
 * Attach to Main Camera Object
 * Wire Bullet prefab to Bullet Transform
 * Repairs(s):
 *      Smoother movment of player camera
 *      Bullet GameObjects are destoryed 
 * Problems(s):
 *      Field of view not constrainted
 */
using UnityEngine;

public class ShooterV4 : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField] float bulletVelocity = 3500.0f;
    [SerializeField] float movementSpeed = 7.5f;
    private int mouseWheelSenstivity = 100;
    private float destoryBulletTimer = 4.5f;
    // Update is called once per frame
    void Update()
    {
        // Smoother Movement on the camera
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * movementSpeed * mouseWheelSenstivity;
        transform.Translate(horizontal, vertical, mouseWheel);
        if (Input.GetButtonUp("Jump"))
        {
            GameObject newBulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Vector3 forwardVector = transform.TransformDirection(Vector3.forward);
            newBulletInstance.GetComponent<Rigidbody>().AddForce(forwardVector * bulletVelocity);
            Destroy(newBulletInstance, destoryBulletTimer);
        }
    }
}
