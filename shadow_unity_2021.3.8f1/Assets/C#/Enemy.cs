using UnityEngine;

namespace jerry
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField,Header("敵人名稱")]
        private GameObject TargetName;
        
        private float MoveRange;
        private Animator ani;
        private Rigidbody2D r2d;

        #region 攻擊判定區塊
        [SerializeField, Header("判定區尺寸")]
        private Vector3 v3CheckGroundSize = Vector3.one;//三軸初始值為1
        [SerializeField, Header("判定區座標")]
        private Vector3 v3CheckGroundOffset;
        [SerializeField, Header("判定區顏色")]
        private Color colorCheckGround = new Color(1, 0, 0, 0);//色號
        [SerializeField, Header("角色判定圖層")]
        private LayerMask layerCheckPlayer;

        #endregion

        private void Awake()
        {
            ani = GetComponent<Animator>();
            r2d = GetComponent<Rigidbody2D>();
        }
    }

}

