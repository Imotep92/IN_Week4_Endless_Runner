using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRB;

    public float jumpForce;
    public float gravityModifier;

    public bool gameOver = false;

    [SerializeField] bool isOnGround = true;

    public ParticleSystem dirtParticle;

    public ParticleSystem explosionParticle;

    public AudioClip jumpSound;

    public AudioClip crashSound;

    private AudioSource playerAudio;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            dirtParticle.Stop();
            explosionParticle.Play();
            gameOver = true;
            Debug.Log("Game Over");
        }
        
        
    }
}
