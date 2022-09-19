using UnityEngine;
using UnityEngine.SceneManagement;

namespace jerry
{
    /// <summary>
    /// 主角全系統
    /// </summary>
    public class T01 : MonoBehaviour
    {
        // 速度
        [SerializeField]
        private float ControlSpeedfloat = 7f;
        // 角速度 -旋轉
        //private float angle = 60f;
        //public float MinX, MaxX, MinY, MaxY;
        [SerializeField]
        private GameObject Shadow;

        [SerializeField, Header("跳躍高度"), Range(0, 3000)]
        private float heightJump = 350;

        #region 跳躍判定區塊
        [SerializeField, Header("判定區尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;//三軸初始值為1
        [SerializeField, Header("判定區座標")]
        private Vector3 v3CheckGroundOffset;
        [SerializeField, Header("判定區顏色")]
        private Color colorCheckGround = new Color(1, 0, 0, 0);//色號
        [SerializeField, Header("檢查地板圖層")]
        private LayerMask layerCheckGround;

        #endregion
        private Animator ani;
        private Rigidbody2D r2d;
        private bool Jump01;
        private bool isGround;

        private string FaceAt = "面向";//true在左 false在右
        private string WalkLeft = "走L";
        private string WalkRight = "走R";
        private string JumpRight = "跳R";
        private string JumpLeft = "跳L";
        private string AttackLeft = "攻擊觸發L";
        private string AttackRight = "攻擊觸發R";
        private string ClimbUp = "爬開關";
        private string Dead = "死";

        private void Awake()
        {
            r2d = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        #region 跳躍系統
        private void JumpKey()//跳躍按鍵執行
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump01 = true;
            }
        }

        private void JumpForce()//跳躍應力
        {
            if (Jump01 && isGround)//當jump01和isGround發生的時候.執行
            {
                r2d.AddForce(new Vector2(0, heightJump));
                Jump01 = false;//執行完成關閉
            }
        }

        private void CheckGround()//地面接觸判定
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, layerCheckGround);
            //2D碰撞器=物理2D.覆蓋方塊(座標-尺寸-角度0-圖層)
            isGround = hit;
        }

        private void OnDrawGizmos()//gizmos.編輯器用.線條.形狀.圖片:不會出現在遊戲中
        {
            Gizmos.color = colorCheckGround;
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
            //gizmos.繪製方形.(抓取介面框設置的座標及尺寸)
        }
        #endregion

        public void Update()//每秒60更新.隨效能波動
        {
            #region 移動程式
            // 左右偏移(-1,1)
            //float hor = Input.GetAxisRaw("Horizontal"); Raw效果,零直接跳到一百,沒有中間的過渡效果
            float hor = Input.GetAxis("Horizontal");
            // 前後偏移(-1,1)
            float ver = Input.GetAxis("Vertical");
            if (hor != 0 || ver != 0)
            #region 說明
            //鍵盤代碼0_代指鍵盤沒有輸入按鍵編號時.顯示為零
            // "!"表示為相反. "||"表示或者.滿足其中之一的條件
            // 讀法為"當水平軸沒有信號輸入或者垂直軸沒有信號輸入時.執行以下動作"
            #endregion
            {
                // 控制坦克前後行走
                transform.Translate(Vector3.right * Time.deltaTime * ControlSpeedfloat * hor);
                //下串是以剛體為控制目標.特點是顯著的物理加速度影響
                //r2d.velocity += Vector2.right * Time.deltaTime * ControlSpeedfloat * hor;
                //print(Vector2.right * Time.deltaTime * ControlSpeedfloat * hor);
                // 控制坦克左右旋轉
                //transform.Rotate(Vector3.up * Time.deltaTime * angle * hor);
            }
            //限制座標型,不受物理影響
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
            #endregion

            JumpKey();
            CheckGround();
        }

        private void FixedUpdate()//每秒"固定"50更新
        {
            JumpForce();//呼叫
        }

        public void NextScene()
        {
            SceneManager.LoadScene("場景02");
        }

        public void Quit()
        {
            Application.Quit();
        }


    }
}

