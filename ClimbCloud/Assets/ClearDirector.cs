using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene ��뿡 �ʿ�

public class ClearDirector : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene"); //LoadScene GameScene �� �ҷ���
        }
    }
}
