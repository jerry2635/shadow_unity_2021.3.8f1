using UnityEngine;
using UnityEngine.SceneManagement;

namespace jerry
{
    public class ChangScene : MonoBehaviour
    {
        [SerializeField, Header("�����s��")]
        private string SceneTarger;
     

        public void NextScene()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneTarger);
            }
        }

        void Start()
        {

        }

        void Update()
        {
            NextScene();
        }


    }
}

