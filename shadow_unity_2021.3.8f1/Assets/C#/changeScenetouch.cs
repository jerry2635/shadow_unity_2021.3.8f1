using UnityEngine.SceneManagement;
using UnityEngine;

namespace jerry
{
    public class changeScenetouch : MonoBehaviour
    {
        [SerializeField, Header("ª±®a")]
        private string Player;
        [SerializeField, Header("³õ´º½s¸¹")]
        private string SceneNumber;

        private bool DoorArea = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Player.Contains(Player))
            {
                DoorArea = true;
            }
        }

        private void NextScene()
        {
            if (DoorArea == true)
            {
                SceneManager.LoadScene(SceneNumber);
            }
        }

        private void LockLocationSystem()
        {
            
        }

        private void Update()
        {
            NextScene();
        }
    }
}

