using Eloi.WatchAndDate;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LayerToExecuteUnityEventHolder
{
    public string m_executionName;
    [TextArea(1, 8)]
    public string m_whatItIsSupposedToDo;
    public UnityEvent m_whatToExecute= new UnityEvent();
    public WatchAndDateTimeActionResult m_executionTime= new WatchAndDateTimeActionResult();
    public bool m_hadError;
    [TextArea(1, 10)]
    public string m_errorMessage;
    public bool m_useCatch;

    public void ResetForNextExecution()
    {
        m_executionTime.StopCounting();
        m_hadError = false;
        m_errorMessage = "";
    }
    public void Invoke()
    {
        ResetForNextExecution();
        m_executionTime.StartCounting();
        if (m_whatToExecute!=null) { 
            if (m_useCatch) { 
            try { 
                m_whatToExecute.Invoke();
            }
            catch (System.Exception e)
            {
                m_hadError = true;
                m_errorMessage = e.Message;
            }
            }
            else
            {
                m_whatToExecute.Invoke();
            }
        }
        m_executionTime.StopCounting();
    }
    public void DiffuseErrorInConsoleIfHadOne(GameObject origine=null)
    {
        if (m_hadError)
        {
            string error = "Error in " + m_executionName + " : " + m_errorMessage;
            if(origine!=null)
                Debug.LogError(error, origine);
            else
                Debug.LogError(error);
        }

    }
}
