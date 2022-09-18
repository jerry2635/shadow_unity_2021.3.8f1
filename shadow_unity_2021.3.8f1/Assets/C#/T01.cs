using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace jerry
{
    /// <summary>
    /// 主角全系統
    /// </summary>
    public class T01 : MonoBehaviour
    {
        public float ControlSpeedfloat; //速度控制浮點數

        private Transform tank;
        // 速度
        private float speed = 20f;
        // 角速度 
        private float angle = 60f;
        public void Update()
        {
            // 左右偏移(-1,1)
            float hor = Input.GetAxis("Horizontal");
            // 前後偏移(-1,1)
            float ver = Input.GetAxis("Vertical");
            if (hor != 0 || ver != 0)
            {
                // 控制坦克前後行走
                transform.Translate(Vector3.forward * Time.deltaTime * speed * ver);
                // 控制坦克左右旋轉
                transform.Rotate(Vector3.up * Time.deltaTime * angle * hor);
            }

        }
    }
}

