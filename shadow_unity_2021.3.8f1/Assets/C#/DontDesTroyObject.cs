using UnityEngine;

namespace jerry
{
    public class DontDestroyObject : MonoBehaviour
    {
        void Start()//����������.�����ഫ�ɫO�d
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

