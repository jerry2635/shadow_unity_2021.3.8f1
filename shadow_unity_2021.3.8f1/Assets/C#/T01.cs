using UnityEngine;

namespace jerry
{
    /// <summary>
    /// �D�����t��
    /// </summary>
    public class T01 : MonoBehaviour
    {
        public float ControlSpeed; //�B�I��

        private void Update()
        {
            transform.Translate(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        }

    }
}

