using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _主機: MonoBehaviour {
    public float 速度 = 6.0f, 寬 = 11.0f, 長 = 9.0f,計時器 = 0.0f;
    public int HP = 3;
    public GameObject 我的子彈;

    string 狀態 = "進場";      //狀態值

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        switch (狀態)      //判斷狀態
        {
            case "進場":
                狀態 = "一般";
                break;

            case "一般":
                this.飛行();
                break;

            case "受傷":
                this.飛行();
                計時器 += Time.deltaTime;
                if (計時器>=1.0f)
                {
                    狀態 = "一般";
                }
                break;

            case "死亡":
                Destroy(this.gameObject);
                break;

            default:

                break;
        }
        
    }

    void 飛行()
    {
        if (Input.GetKey(KeyCode.D))        //判斷是否按下D鍵
        {
            this.transform.Translate(速度 * Time.deltaTime, 0.0f, 0.0f, Space.Self);     //朝自己的Z軸前進，speed*Time.deltaTime,速度X 時間.每秒更新
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-速度 * Time.deltaTime, 0.0f, 0.0f, Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, 速度 * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -速度 * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.Translate(0.0f, 速度 * Time.deltaTime, 0.0f, Space.Self);
        }


        //子彈
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject TempObject;      //
            TempObject = Instantiate(我的子彈, this.transform.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f));        //Quaternion=四元數，Euler=尤拉角
            TempObject.SetActive(true);     //關閉物件隱形
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="敵機子彈(Clone)")
        {
            if (狀態 == "一般")
            {
                if (HP > 0)
                {
                    HP -= 1;
                    計時器 = 0;
                    狀態 = "受傷";
                }
                else
                {
                    狀態 = "死亡";
                }
            }
        }

    }
}
