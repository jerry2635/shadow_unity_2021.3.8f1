using UnityEngine;

namespace jerry
{
    public class DontDestroyObject : MonoBehaviour
    {
        void Start()//掛載的物件.場景轉換時保留
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

