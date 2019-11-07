using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;
    [Header("跳躍音效")]
    public AudioClip soundJump;

    private bool isGround;

    private Rigidbody rig;
    private Animator ani;
    private AudioSource aud;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }


    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGround == true)
        {
            rig.AddForce(0, jump, 0);
            ani.SetBool("跳躍開關", true);
            isGround = false;
            aud.PlayOneShot(soundJump);
        }
    }

    public void ResetAnimator()
    {
        ani.SetBool("跳躍開關", false);
    }
}
