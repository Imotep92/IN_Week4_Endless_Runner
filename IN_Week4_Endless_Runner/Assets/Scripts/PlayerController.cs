using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    #region player physics    

    //Player speed and movement variables
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityModifier;

    #endregion player physics

    #region game rules

    public bool isDead = false; //trigger gameOver UI in Game Manager script
    [SerializeField] bool isOnGround = true;

    #endregion game rules

    #region sfx

    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    private Animator anim;

    #endregion sfx

    #region Audio

    public AudioClip jumpSound;  //player jump sound

    public AudioClip crashSound;  //player hitting obstacle sound

    private AudioSource playerAudio; //Game music

    #endregion Audio


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

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
        
         /*
        if (player box collider ==!isOnGround)
       {
           anim.SetBool("Wolf_Run_Static", !anim.GetBool("Wolf_Run_Static")); // pause running animation
       }
       */

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
            isDead = true;
            Debug.Log("Game Over"); // gameover ui?
        }


    }
}
