using UnityEngine;

public class Boy : MonoBehaviour
{
    #region 設定變數
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;
    [Header("確認是否在地板上")]
    public bool isGround = false;//確認是否在地板上

    public AudioClip audioJump;//跳躍音效
    private AudioSource boyAudioSource;//設定角色的音樂播放
    private Rigidbody boyR2d;//設定角色剛體
    private Animator boyAin;//設定角色動畫
    #endregion
    private void Start()
    {
        boyAudioSource = GetComponent<AudioSource>();//自動抓取角色音樂
        boyR2d = GetComponent<Rigidbody>();//自動抓取角色鋼體
        boyAin = GetComponent<Animator>();//自動抓取角色動畫
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    /// <summary>
    /// Boy跳躍方法
    /// </summary>
    public void BoyJump()
    {
        if (isGround == true)
        {
            boyAin.SetBool("跳躍開關", true);
            boyR2d.AddForce(new Vector2(0.0f, jump));//向上跳躍
            boyAudioSource.PlayOneShot(audioJump, 0.7f);//播放跳躍音效
            isGround = false;
        }
        //Debug.Log("跳躍");

        //girl.Translate(0.0f, 4.0f, 0.0f);//Girl向上移動
    }

    /// <summary>
    /// 重設角色動畫
    /// </summary>
    public void ResetGirlAnimator()
    {
        boyAin.SetBool("跳躍開關", false);
    }

    private void OnCollisionEnter(Collision collision)//查看角色是否在地板上
    {
        if (collision.gameObject.name == "地板")//當角色碰到地板時
        {
            isGround = true;//有在地板上
        }
    }
}
