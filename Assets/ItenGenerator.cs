
using System.Collections;
using UnityEngine;

public class ItenGenerator : MonoBehaviour
{
    public GameObject CarTypeA;
    public GameObject PointCoin;
    public GameObject ObstacleCone;

    private int StartPos = 80;
    private int GoalPos = 360;

    private float PopRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = StartPos; i<GoalPos ; i+=15)
        {
            int num　= Random.Range(1, 11);
            //コーンＰＯＰ↓
            if (num <= 2)
            {
                for(float j = -1; j<=1; j+=0.4f)
                {
                    GameObject cone = Instantiate(ObstacleCone);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            //ココマデ↑
            else
            {
                for(int j = -1; j<=1; j++)
                {
                    int item = Random.Range(1, 11);
                    int SetPositionZ = Random.Range(-5, 6);
                    //コイン精製
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(PointCoin);
                        coin.transform.position = new Vector3(PopRange * j, coin.transform.position.y, i + SetPositionZ);
                    }
                    //車精製
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(CarTypeA);
                        car.transform.position = new Vector3(PopRange * j, car.transform.position.y, i + SetPositionZ);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
