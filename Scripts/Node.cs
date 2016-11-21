using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class Node : MonoBehaviour {
    public List<NodeBridge> neighbors = new List<NodeBridge>();
    public Node nextNode() {
        return neighbors[Random.Range(0, neighbors.Count-1)].to;
    }
    public NodeBridge next() {
        return neighbors[Random.Range(0, neighbors.Count - 1)];
    }
    public void init(Node[] possibles, int start) {
        for(int i = start; i < possibles.Length; i++) {
            if (Physics2D.Linecast(transform.position, possibles[i].transform.position, Globals.get().PathfindStoppers).collider == null) {
                neighbors.Add(new NodeBridge(this,possibles[i]));
                possibles[i].neighbors.Add(new NodeBridge(possibles[i],this));
            }
        }
    }
    public void debug() {
        foreach (NodeBridge n in neighbors)
            Debug.DrawLine(transform.position, n.position());
    }
}
public class NodeBridge {
    public Node from;
    public Node to;
    private float distance;
    public NodeBridge(Node from, Node to) {
        this.from = from;
        this.to = to;
        distance = (from.transform.position - to.transform.position).magnitude;
    }
    public Vector2 direction(Vector3 start) {
        return to.transform.position - start;
    }
    public Vector3 position() {
        return to.transform.position;
    }
}