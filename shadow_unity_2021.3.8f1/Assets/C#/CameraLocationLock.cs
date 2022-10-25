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
            //������J�ƭȱ���
            //mathf �ƭ� .  clamp ����d��
            transform.position= new Vector3(Mathf.Clamp(transform.position.x,MinX,MaxX),Mathf.Clamp(transform.position.y,MinY,MaxY),transform.position.z);
        }
    }

}

