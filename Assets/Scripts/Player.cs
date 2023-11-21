using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserOffset = 0.5f;
    [SerializeField] private float playerSpeed = 10f;
    private Rigidbody2D playerRb;
    private float horizontalInput, verticalInput;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(laserPrefab, transform.position + Vector3.up * laserOffset, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * playerSpeed * Time.fixedDeltaTime;
        playerRb.MovePosition(playerRb.position + movement);
    }
}
