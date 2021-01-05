using System.Collections;
using UnityEngine;

public class DrawScript: MonoBehaviour
{
    public LineRenderer m_LineRenderer;
    public float m_LaserDuration = 0.1f;
    public void Init()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
        m_LineRenderer.positionCount = 2;
        ResetLine();
    }

    public void DrawLine(Vector3 pos1,Vector3 pos2)
    {
        m_LineRenderer.SetPosition(0, pos1);
        m_LineRenderer.SetPosition(1, pos2);
        //this is so that the laser appears just enough for us to see it
        StartCoroutine(ResetLineAfterTime(m_LaserDuration));
    }

    public void ResetLine()
    {
        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, transform.position);
    }

    IEnumerator ResetLineAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ResetLine();
    }    
}
