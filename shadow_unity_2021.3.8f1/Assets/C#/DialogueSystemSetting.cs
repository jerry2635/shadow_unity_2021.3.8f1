using UnityEngine;
using TMPro;
using System.Collections;//引用系統_資料系統結構協同
using System;

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
        [SerializeField, Header("對話引導")]
        private GameObject dialogueTip;//建立欄位放置引導物件

        private AudioSource aud;//建立音源名稱aud

        public ReadText dataText;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(StartDialogueFrame());//變更為協程.才能接受回傳值
        }

        public IEnumerator StartDialogueFrame()//合併項目.變更為IEnumerator/協程.才能使用yield return/暫停回傳
        {
            textName.text = dataText.TextTitleName;//在開啟時抓取datatext的標題抬頭
            textContent.text = "";//標題抬頭初始為空白

            yield return StartCoroutine(TextPass());
            yield return StartCoroutine(TypeEffect());
        }

        private IEnumerator TextPass()//協同介面功能名稱IEnumerator
        {
            //return 是回傳並停止後面程式的運作
            //yield(讓步/退讓) return 執行到此回傳.下面程式繼續執行
            //這邊的回傳.應該會刷新對話框文字
            for (int i = 0; i < 10; i++)//設定執行十次
            {
                groupDialogue.alpha += 0.1f;
                yield return new WaitForSeconds(0.5f);//每0.5秒增加0.1可見度
            }

            StartCoroutine(TypeEffect());//當for迴圈執行完之後.執行入字型特效
        }

        private IEnumerator TypeEffect()
        {
            aud.PlayOneShot(dataText.datadialogues[0].sound);//playoneshot必須有音源檔

            string content = dataText.datadialogues[0].content;//字串.陣列[0]
            for (int i = 0; i < content.Length; i++)//content.length是指陣列裡面的字數
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(0.05f);
            }

            dialogueTip.SetActive(true);//單行對話完成時.會顯示對話引導
        }
    }
}

