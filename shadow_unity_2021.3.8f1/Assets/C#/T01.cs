using UnityEngine;

namespace jerry
{
    /// <summary>
    /// 主角全系統
    /// </summary>
    public class T01 : MonoBehaviour
    {
        public float ControlSpeed; //浮點數

        private void Update()
        {
            transform.Translate(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        }

    }
}

