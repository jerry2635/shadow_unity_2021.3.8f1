using UnityEngine;

namespace jerry
{
    /// <summary>
    /// �D�����t��
    /// </summary>
    public class T01 : MonoBehaviour
    {
        public float ControlSpeedfloat; //�t�ױ���B�I��

        private void Update()
        {
            transform.Translate(Input.GetAxis("Horizontal") * ControlSpeedfloat * Time.deltaTime, Input.GetAxis("Vertical") * ControlSpeedfloat * Time.deltaTime, 0);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
            //clamp ����.�ǥѲ��ͼƭȳ]�w����.�קK����]�X�d��~--�T�w�y��.

        }

        public void QuitGame()//�C������
        {
            Application.Quit();
        }
    }
}

