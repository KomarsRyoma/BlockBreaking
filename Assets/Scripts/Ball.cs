using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isDead = false; // 死亡フラグ
    public float speed = 3.0f; // 速度
    public float accelSpeed = 0.5f; // 加速度
    public ScoreManager scoreManager;
    public GameObject explosionPrefab;
    public AudioClip touchBarSE; // バーに当たった時の効果音
    public AudioClip touchOtherSE; // バー以外に当たった時の効果音

    bool isStart = false;
    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart == false && Input.GetMouseButtonDown(0)){
            isStart = true;
            rb.AddForce(new Vector3(1,-1,0) * speed, ForceMode.VelocityChange);
        }
    }

    // オブジェクトにぶつかったときの処理
    private void OnCollisionEnter(Collision collision)
    {
        // ブロックだったら消す
        if(collision.gameObject.CompareTag("Block")){
            scoreManager.AddScore();
            Destroy(collision.gameObject);
            GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
            explosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }

        // 下の壁に当たったらゲームオーバー
        if(collision.gameObject.name == "Wall_Bottom"){
            isDead = true;
        }

        // バーに当たった時に方向を変える
        if(collision.gameObject.name == "Bar"){
            // コンボリセット
            scoreManager.ResetCombo();

            // 加速させる
            speed += accelSpeed;

            Vector3 vec = transform.position - collision.transform.position;
            rb.velocity = Vector3.zero;
            rb.AddForce(vec.normalized * speed, ForceMode.VelocityChange);

            // 効果音を鳴らす
            audioSource.PlayOneShot(touchBarSE);
        }else{
            // 効果音を鳴らす
            audioSource.PlayOneShot(touchOtherSE);
        }
    }
}
