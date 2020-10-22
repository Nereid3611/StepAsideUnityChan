
using System.Collections;
using UnityEngine;

public class ItenGenerator : MonoBehaviour
{
    public GameObject CarTypeA;
    public GameObject PointCoin;
    public GameObject ObstacleCone;

    private UnityChanController script;

    //ポップ位置↓
    private GameObject unitychan;
    private float PopPosition;
    
    private bool End;

    private int PopCooldown = 300;

    //ポップタイミング　スタートから８０ｍ(２０ｍ進んだ地点）～ゴール１０ｍ前（300ｍ地点到達）
    private int StartPos = 20;
    private int GoalPos = 300;

    private float PopRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
       
    }

    // Update is called once per frame
    void Update()
    {
        
        script = unitychan.GetComponent<UnityChanController>();
        End = script.isEnd;
        Debug.Log(End);
        if (End == false)
        {
            if (unitychan.transform.position.z > StartPos && unitychan.transform.position.z < GoalPos)
            {
                PopCooldown--;

                PopPosition = unitychan.transform.position.z + 60;
                if (PopCooldown == 0)
                {
                    PopCooldown += 300;

                    int num = Random.Range(1, 18);
                    //コーンＰＯＰ↓
                    if (num <= 2)
                    {
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(ObstacleCone);
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, PopPosition);
                        }
                    }
                    //ココマデ↑
                    else
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int item = Random.Range(1, 18);
                            int SetPositionZ = Random.Range(-5, 6);
                            //コイン精製
                            if (1 <= item && item <= 7)
                            {
                                GameObject coin = Instantiate(PointCoin);
                                coin.transform.position = new Vector3(PopRange * j, coin.transform.position.y, PopPosition + SetPositionZ);
                            }
                            //車精製
                            else if (8 <= item && item <= 14)
                            {
                                GameObject car = Instantiate(CarTypeA);
                                car.transform.position = new Vector3(PopRange * j, car.transform.position.y, PopPosition + SetPositionZ);
                            }
                        }
                    }
                }
            }
        }

    }
}
