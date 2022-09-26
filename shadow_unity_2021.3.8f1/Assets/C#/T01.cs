using UnityEngine;
using UnityEngine.SceneManagement;

namespace jerry
{
    /// <summary>
    /// �D�����t��
    /// </summary>
    public class T01 : MonoBehaviour
    {
        // �t��
        [SerializeField]
        private float ControlSpeedfloat = 7f;
        // ���t�� -����
        //private float angle = 60f;
        //public float MinX, MaxX, MinY, MaxY;
        [SerializeField]
        private GameObject Shadow;

        [SerializeField, Header("���D����"), Range(0, 3000)]
        private float heightJump = 350;

        #region ���D�P�w�϶�
        [SerializeField, Header("�P�w�Ϥؤo")]
        private Vector3 v3CheckGroundSize = Vector3.one;//�T�b��l�Ȭ�1
        [SerializeField, Header("�P�w�Ϯy��")]
        private Vector3 v3CheckGroundOffset;
        [SerializeField, Header("�P�w���C��")]
        private Color colorCheckGround = new Color(1, 0, 0, 0);//�⸹
        [SerializeField, Header("�ˬd�a�O�ϼh")]
        private LayerMask layerCheckGround;

        #endregion
        private Animator ani;
        private Rigidbody2D r2d;
        private bool Jump01;
        private bool isGround;

        private string FaceAt = "���V";//true�b�� false�b�k
        private string WalkLeft = "��L";
        private string WalkRight = "��R";
        private string JumpRight = "��R";
        private string JumpLeft = "��L";
        private string AttackLeft = "����Ĳ�oL";
        private string AttackRight = "����Ĳ�oR";
        private string ClimbUp = "���}��";
        private string Dead = "��";

        private void Awake()
        {
            r2d = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }

        #region ���D�t��
        private void JumpKey()//���D�������
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump01 = true;

                if (ani.GetBool(FaceAt))//FaceAt���g���true
                {
                    ani.SetBool(JumpLeft, true && !isGround);
                }
                if (!ani.GetBool(FaceAt))// "!"����]�w�bBool�W
                {
                    ani.SetBool(JumpRight, true && !isGround);
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    ani.SetBool(JumpLeft, false);
                    ani.SetBool(JumpRight, false);
                }
            }
        }

        private void JumpForce()//���D���O
        {
            if (Jump01 && isGround)//��jump01�MisGround�o�ͪ��ɭ�.����
            {
                r2d.AddForce(new Vector2(0, heightJump));
                Jump01 = false;//���槹������
            }
        }

        private void CheckGround()//�a����Ĳ�P�w
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position + v3CheckGroundOffset, v3CheckGroundSize, 0, layerCheckGround);
            //2D�I����=���z2D.�л\���(�y��-�ؤo-����0-�ϼh)
            isGround = hit;
        }

        private void OnDrawGizmos()//gizmos.�s�边��.�u��.�Ϊ�.�Ϥ�:���|�X�{�b�C����
        {
            Gizmos.color = colorCheckGround;
            Gizmos.DrawCube(transform.position + v3CheckGroundOffset, v3CheckGroundSize);
            //gizmos.ø�s���.(��������س]�m���y�ФΤؤo)
        }
        #endregion

        #region �ʵe�t��
        private void AnimeDecideSystem()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))//��
            {
                if (ani.GetBool(FaceAt))//FaceAt���g���true
                    ani.SetTrigger(AttackLeft);
                else if (!ani.GetBool(FaceAt))// "!"����]�w�bBool�W
                    ani.SetTrigger(AttackRight);
            }

            if (Input.GetKeyDown(KeyCode.A))//��
            {
                ani.SetBool(FaceAt, true);
                ani.SetBool(WalkRight, false);
                ani.SetBool(WalkLeft, true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                ani.SetBool(WalkLeft, false);
            }

            if (Input.GetKeyDown(KeyCode.D))//�k
            {
                ani.SetBool(FaceAt, false);
                ani.SetBool(WalkLeft, false);
                ani.SetBool(WalkRight, true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                ani.SetBool(WalkRight, false);
            }
        }
        #endregion

        private void Move()//���ʵ{��
        {
            // ���k����(-1,1)
            //float hor = Input.GetAxisRaw("Horizontal"); Raw�ĪG,�s��������@��,�S���������L��ĪG
            float hor = Input.GetAxis("Horizontal");


            // �e�᰾��(-1,1)
            float ver = Input.GetAxis("Vertical");
            if (hor != 0 || ver != 0)
            #region ����
            //��L�N�X0_�N����L�S����J����s����.��ܬ��s
            // "!"��ܬ��ۤ�. "||"��ܩΪ�.�����䤤���@������
            // Ū�k��"������b�S���H����J�Ϊ̫����b�S���H����J��.����H�U�ʧ@"
            #endregion
            {
                // ����Z�J�e��樫
                transform.Translate(Vector3.right * Time.deltaTime * ControlSpeedfloat * hor);
                #region �H���鬰����
                //�U��O�H���鬰����ؼ�.�S�I�O��۪����z�[�t�׼v�T
                //r2d.velocity += Vector2.right * Time.deltaTime * ControlSpeedfloat * hor;
                //print(Vector2.right * Time.deltaTime * ControlSpeedfloat * hor);
                // ����Z�J���k����
                //transform.Rotate(Vector3.up * Time.deltaTime * angle * hor);
                #endregion
            }
            //����y�Ы�,�������z�v�T
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
        }

        public void Update()//�C��60��s.�H�į�i��
        {
            Move();
            JumpKey();
            CheckGround();
            AnimeDecideSystem();
        }

        private void FixedUpdate()//�C��"�T�w"50��s
        {
            JumpForce();//�I�s
        }

        public void NextScene()
        {
            SceneManager.LoadScene("����02");
        }

        public void Quit()
        {
            Application.Quit();
        }

        
    }
}

