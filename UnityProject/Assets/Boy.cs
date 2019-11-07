using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
