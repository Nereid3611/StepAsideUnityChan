using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody myRigdbody;
    private GameObject EndGameText;
    private GameObject ScoreText;

    private int Score = 0 ;

    private float VelZ = 16f;
    private float VelX = 10f;
    private float VelY = 10f;
    private float MoveRange = 3.4f;
    private float EndStop = 0.99f;

    private bool isEnd = false;
    private bool LB = false;
    private bool RB = false;
    private bool JB = false;



    // Start is called before the first frame update
    void Start()
    {

        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);

        this.myRigdbody = GetComponent<Rigidbody>();
        this.EndGameText = GameObject.Find("ResultUI");
        this.ScoreText = GameObject.Find("ScoreUI");

    }

    // Update is called once per frame
    void Update()
    {
        //キーコントロール↓
        float LRmoveSpeed = 0;
        float JumpSpeed = 0;
                                            　　　　　　　　　　　　　　　　 //左端の座標
        if((Input.GetKey(KeyCode.LeftArrow) || this.LB) && -this.MoveRange < this.transform.position.x)
        {
            LRmoveSpeed = -this.VelX;

        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.RB) &&  this.transform.position.x < this.MoveRange)
        {
            LRmoveSpeed = this.VelX;

        }

        if ((Input.GetKeyDown(KeyCode.Space) || this.JB) && this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            JumpSpeed = VelY;

        }
        else 
        {
            JumpSpeed = this.myRigdbody.velocity.y;

        }
        if(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);

        }
        this.myRigdbody.velocity = new Vector3(LRmoveSpeed, JumpSpeed, VelZ);
        //キーコントロール↑

        if (this.isEnd)
        {
            this.VelX *= EndStop;
            this.VelY *= EndStop;
            this.VelZ *= EndStop;
            this.myAnimator.speed *= this.EndStop;
        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag =="ConeTag")
        {
            this.isEnd = true;
            this.EndGameText.GetComponent<Text>().text = "Game Over";


        }
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            this.EndGameText.GetComponent<Text>().text = "CLEAR";
        }
        if (other.gameObject.tag == "CoinTag")
        {
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
            this.Score += 10;
            this.ScoreText.GetComponent<Text>().text = "Score" + this.Score + "pt";

        }
    }
    //タッチボタン↓
    public void GetMyJumpButtonDown()
    {
        this.JB = true;

    }
    public void GetMyJumpButtonUp()
    {
        this.JB = false;

    }
    public void GetMyLeftButtonDown()
    {
        this.LB = true;

    }
    public void GetMyLeftButtonUp()
    {
        this.LB = false;

    }
    public void GetMyRightButtonDown()
    {
        this.RB = true;

    }
    public void GetMyRightButtonUp()
    {
        this.RB = false;

    }
}//タッチボタン↑

