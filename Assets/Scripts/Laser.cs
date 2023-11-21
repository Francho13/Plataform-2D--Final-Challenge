using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float laserSpeed = 5f;
    [SerializeField] private Rigidbody2D laserRb;

    private void Start()
    {
        laserRb.velocity = Vector2.up * laserSpeed;
    }

    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }




}
