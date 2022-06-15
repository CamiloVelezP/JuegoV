using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{
    private Text _text;
    private Queue<QueueText> queue;
    private bool active = false;
    void Start()
    {
        _text = gameObject.GetComponent<Text>();
        queue = new Queue<QueueText>();
    }
    
    void Update()
    {
        if (!active)
        {
            if(queue.Count > 0)
            {
                QueueText qText = queue.Dequeue();
                StartCoroutine(HideText(qText));
            }
        }
    }

    public void ShowText(string text, float time)
    {
        queue.Enqueue(new QueueText(text, time));
    }

    IEnumerator HideText(QueueText item)
    {
        active = true;
        _text.text = item.text;
        yield return new WaitForSeconds(item.time);        
        _text.text = "";
        active = false;
        yield return null;
    }

    private struct QueueText
    {
        public string text;
        public float time;

        public QueueText(string text, float time)
        {
            this.text = text;
            this.time = time;
        }
    }
}

