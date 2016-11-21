using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour{
    Node[] pathNodes;
    public void Start() {
        buildPaths();
    }
    public void buildPaths() {
        pathNodes = GameObject.Find("Nodes").GetComponentsInChildren<Node>();
        for (int i = 0; i < pathNodes.Length; i++)
            pathNodes[i].init(pathNodes, i+1);
    }
    public void debug() {
        foreach (Node n in pathNodes) n.debug();
        Debug.Break();
    }
}
