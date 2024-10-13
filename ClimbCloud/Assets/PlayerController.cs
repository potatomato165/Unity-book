using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; // ���������� LoadScene �� ���鶧 �ʿ�

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
        //�����Ѵ�
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0) //&&�� and   �������� ����
        {
            this.rigid2D.AddForce(transform.up*this.jumpForce);
        }

        //�¿� �̵�
        int key = 0;
        if (Input.acceleration.x > this.threshold) key = 1; //�ڵ����� ��￴���� ���� 0.2 ���� ũ�� �������� ���������� ����
        if (Input.acceleration.x < -this.threshold) key = -1; // ���������� �ݴ����
        

        //�÷��̾��� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //���ǵ� ����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        //�����̴� ���⿡ ���� �����Ѵ�.
        if (key !=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //�÷��̾� �ӵ��� ���� ���ϸ��̼� �ӵ��� �ٲ۴�.
        this.animator.speed = speedx / 2.0f;
        
        //�÷��̾� �߶� �� ó������
        if (transform.position.y <-10)
        {
            SceneManager.LoadScene("GameScene");
        }

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }
}
