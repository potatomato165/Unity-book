using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI를 사용하므로 잊지 않고 추가한다.
public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
