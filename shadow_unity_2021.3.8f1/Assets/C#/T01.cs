using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace jerry
{
    /// <summary>
    /// �D�����t��
    /// </summary>
    public class T01 : MonoBehaviour
    {
        public float ControlSpeedfloat; //�t�ױ���B�I��

        private Transform tank;
        // �t��
        private float speed = 20f;
        // ���t�� 
        private float angle = 60f;
        public void Update()
        {
            // ���k����(-1,1)
            float hor = Input.GetAxis("Horizontal");
            // �e�᰾��(-1,1)
            float ver = Input.GetAxis("Vertical");
            if (hor != 0 || ver != 0)
            {
                // ����Z�J�e��樫
                transform.Translate(Vector3.forward * Time.deltaTime * speed * ver);
                // ����Z�J���k����
                transform.Rotate(Vector3.up * Time.deltaTime * angle * hor);
            }

        }
    }
}

