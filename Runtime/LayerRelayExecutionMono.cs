using UnityEngine;

public class LayerRelayExecutionMono : MonoBehaviour {
    
    public bool m_disableExecution;
    public bool m_ignoreError;
    public LayerToExecuteUnityEventHolder m_whatToExecute ;


    [ContextMenu("Execute")]
    public void Execute() {
        if(m_whatToExecute == null) {
            return;
        }
        if(!this.isActiveAndEnabled)
        {
            return;
        }
        if(m_disableExecution) {
            return;
        }
        m_whatToExecute.Invoke();
        if(!m_ignoreError) {
            m_whatToExecute.DiffuseErrorInConsoleIfHadOne();
        }
    }
}