/* 
 * Shooterv1.cs
 * Attach to Main Camera Object
 * Wire Bullet prefab to Bullet Transform
 * Problems(s):
 * Player movement way too fast
 * Bullet transforms accumulates
 * Field of view not constrainted
 */

using UnityEngine;

public class ShooterV1 : MonoBehaviour
{
    public Transform bulletTransform;

    [SerializeField] float velocity = 3500;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetButtonUp("Jump"))
        {
            Transform newBulletInstance = Instantiate(bulletTransform, transform.position, transform.rotation);
            Vector3 forwardVector = transform.TransformDirection(Vector3.forward);
            newBulletInstance.GetComponent<Rigidbody>().AddForce(forwardVector * velocity);
        }
    }
}
