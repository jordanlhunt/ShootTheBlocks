/* 
 * ShooterVFinal.cs
 * Attach to Main Camera Object
 * Wire Bullet prefab to Bullet Transform
 * Repairs(s):
 *      Smoother movment of player camera
 *      Bullet GameObjects are destoryed 
 *      Field of view is constrainted
 * Problems(s):
 *      None known
 */
using UnityEngine;

public class ShooterFinal : MonoBehaviour
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

        // Constrain Camera to Viewport
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.5f, 1.5f), Mathf.Clamp(transform.position.y, 2.5f, 8f), Mathf.Clamp(transform.position.z, -32, -30));

        // Shoot the bullet
        if (Input.GetButtonUp("Jump"))
        {
            GameObject newBulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Vector3 forwardVector = transform.TransformDirection(Vector3.forward);
            newBulletInstance.GetComponent<Rigidbody>().AddForce(forwardVector * bulletVelocity);
            Destroy(newBulletInstance, destoryBulletTimer);
        }
    }
}

/*
    This was a fun project! I thought the video length was perfect and the way it was broken up felt really good. I also really like how the project showed the naturally iterative process of experimenting with values to get a good "feel" of game in its proper context. I think this video showed that I need to think about my realtionship/expectations with game development. I often feel like i want things to be a very EXACT or precise way but I'm seeing now that game development (programming in general) is a less exact craft. Yes things can be exact towards the end or have a desired outcome but the process can be iterative and full of discovery and even misfires.

*/
