using UnityEngine;

namespace jerry
{
    /// <summary>
    /// 主角全系統
    /// </summary>
    public class T01 : MonoBehaviour
    {
        public float ControlSpeedfloat; //速度控制浮點數

        private void Update()
        {
            transform.Translate(Input.GetAxis("Horizontal") * ControlSpeedfloat * Time.deltaTime, Input.GetAxis("Vertical") * ControlSpeedfloat * Time.deltaTime, 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
            //clamp 限制.藉由產生數值設定介面.避免物件跑出範圍外--固定座標.

        }

        public void QuitGame()//遊戲結束
        {
            Application.Quit();
        }
    }
}

