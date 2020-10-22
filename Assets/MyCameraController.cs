using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    private GameObject unitychan;
    private float CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
       this.unitychan = GameObject.Find("unitychan");
        this.CameraPosition = unitychan.transform.position.z - this.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - CameraPosition);

    }
}
