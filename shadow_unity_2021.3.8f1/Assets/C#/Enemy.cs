using UnityEngine;

namespace jerry
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField,Header("�ĤH�W��")]
        private GameObject TargetName;
        
        private float MoveRange;
        private Animator ani;
        private Rigidbody2D r2d;

        #region �����P�w�϶�
        [SerializeField, Header("�P�w�Ϥؤo")]
        private Vector3 v3CheckGroundSize = Vector3.one;//�T�b��l�Ȭ�1
        [SerializeField, Header("�P�w�Ϯy��")]
        private Vector3 v3CheckGroundOffset;
        [SerializeField, Header("�P�w���C��")]
        private Color colorCheckGround = new Color(1, 0, 0, 0);//�⸹
        [SerializeField, Header("����P�w�ϼh")]
        private LayerMask layerCheckPlayer;

        #endregion

        private void Awake()
        {
            ani = GetComponent<Animator>();
            r2d = GetComponent<Rigidbody2D>();
        }
    }

}

