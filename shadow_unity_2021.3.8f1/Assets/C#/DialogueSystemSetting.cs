using UnityEngine;
using TMPro;
using System.Collections;//引用系統_資料系統結構協同

namespace jerry
{
    /// <summary>
    /// 對話文字系統.框淡入.更新名稱.更新資料內容.音效X.框淡出
    /// </summary>
    public class DialogueSystemSetting : MonoBehaviour
    {
        [SerializeField, Header("畫布文字框系統")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("畫布文字框系統")]//TMP文字系統.using TMPro 引用
        private TextMeshProUGUI textName;//文檔名稱
        [SerializeField, Header("畫布文字框系統")]
        private TextMeshProUGUI textContent;//文檔內容

        private AudioSource aud;//建立音源名稱aud

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
            StartCoroutine(TextPass());
        }

        private IEnumerator TextPass()//協同介面功能名稱IEnumerator
        {
            print("第一行文字");
            yield return new WaitForSeconds(2);//兩秒之後
                                               //return 是回傳並停止後面程式的運作
                                               //yield(讓步/退讓) return 執行到此回傳.下面程式繼續執行
            print("第二行文字");                //這邊的回傳.應該會刷新對話框文字
            yield return new WaitForSeconds(2);
            print("第三行文字");
        }
    }
}

