using Eloi.WatchAndDate;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// When you start player with Job System, it is important to work with Layers of execution.
/// I am a class that keep track of the layers of execution and the time it took to execute them.
/// </summary>
public class LayersStateAndExecutionRelayedMono : MonoBehaviour
{


    public WatchAndDateTimeActionResult m_fullExecutionTime;
    [Header("Layers")]
    public List<LayerRelayExecutionMono> m_layersToExecute;

    public bool m_useUpdateCall = true;
    public Debug m_debug;
    [System.Serializable]
    public class Debug
    {
        public int m_layerIndexState;
        public bool m_finishedRunning;
        public bool m_hasError;
        public int m_errorCount;
    }

    private void Update()
    {
        if (m_useUpdateCall)
        {
            ExecuteLayers();
        }
    }


    public void ExecuteLayers()
    {


        m_fullExecutionTime.StartCounting();
        m_debug.m_finishedRunning = false;

        m_debug.m_hasError = false;
        m_debug.m_errorCount = 0;
        for (int i = 0; i < m_layersToExecute.Count; i++)
        {
            m_debug.m_layerIndexState = i;
            m_layersToExecute[i].Execute();
        }
        m_debug.m_finishedRunning = true;
        m_fullExecutionTime.StopCounting();

    }
}
