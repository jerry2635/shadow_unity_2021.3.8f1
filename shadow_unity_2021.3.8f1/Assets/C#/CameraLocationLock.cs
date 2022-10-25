using Cinemachine;
using UnityEngine;

namespace jerry
{
    public class CameraLocationLock : MonoBehaviour
    {
        public float MinX, MaxX, MinY, MaxY;

        private void Awake()
        {
           
        }

        private void Update()
        {
            //介面輸入數值控制
            //mathf 數值 .  clamp 限制範圍
            transform.position= new Vector3(Mathf.Clamp(transform.position.x,MinX,MaxX),Mathf.Clamp(transform.position.y,MinY,MaxY),transform.position.z);
        }
    }

}

