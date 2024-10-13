using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // 마찬가지로 LoadScene 을 만들때 필요

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float threshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //점프한다
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0) //&&은 and   무한점프 금지
        {
            this.rigid2D.AddForce(transform.up*this.jumpForce);
        }

        //좌우 이동
        int key = 0;
        if (Input.acceleration.x > this.threshold) key = 1; //핸드폰을 기울였을때 값이 0.2 보다 크면 오른쪽이 눌린것으로 간주
        if (Input.acceleration.x < -this.threshold) key = -1; // 마찬가지로 반대방향
        

        //플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //스피드 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        //움직이는 방향에 따라 반전한다.
        if (key !=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //플레이어 속도에 맞춰 에니메이션 속도를 바꾼다.
        this.animator.speed = speedx / 2.0f;
        
        //플레이어 추락 시 처음부터
        if (transform.position.y <-10)
        {
            SceneManager.LoadScene("GameScene");
        }

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
