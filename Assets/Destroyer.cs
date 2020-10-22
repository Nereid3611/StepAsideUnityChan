using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject unitychan;
    private float DestroyerPosition ;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.DestroyerPosition = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z -DestroyerPosition);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CoinTag" || other.gameObject.tag == "CarTag" || other.gameObject.tag == "ConeTag")
        {
            Debug.Log(other.gameObject.tag + "消去");
            Destroy(other.gameObject);
        }
    }
}
