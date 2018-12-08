using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathRequestManager : MonoBehaviour {

    //Queue<PathRequest> pathRequestsQueue = new Queue<PathRequest>();
    //PathRequest currentPathRequest;
    //
    //static PathRequestManager instance;
    //
    //Pathfinding pathfinding;
    //
    //bool bIsProcessingPath;
    //
    //void Avake()
    //{
    //    instance = this;
    //    pathfinding = GetComponent<Pathfinding>();
    //}
    //
	//public static void RequestPath(Vector3 _pathStart, Vector3 _pathEnd, Action<Vector3, bool> _callback)
    //{
    //    PathRequest newRequest = new PathRequest(_pathStart, _pathEnd, _callback);
    //    instance.pathRequestsQueue.Enqueue(newRequest);
    //    instance.TryProcessNext();
    //}
    //
    //void TryProcessNext()
    //{
    //    if(!bIsProcessingPath && pathRequestsQueue.Count > 0)
    //    {
    //        currentPathRequest = pathRequestsQueue.Dequeue();
    //        bIsProcessingPath = true;
    //        pathfinding.StartFindPath(currentPathRequest.pathStart, currentPathRequest.pathEnd);
    //    }
    //}
    //
    //public void FinishedProcessingPath(Vector3[] _path, bool _bSucess)
    //{
    //    currentPathRequest.callback(_path, _bSucess);
    //}
    //
    //struct PathRequest
    //{
    //    public Vector3 pathStart;
    //    public Vector3 pathEnd;
    //    Action<Vector3, bool> callback;
    //
    //    public PathRequest(Vector3 _pathStart, Vector3 _pathEnd, Action<Vector3, bool> _callback)
    //    {
    //        pathStart = _pathStart;
    //        pathEnd = _pathEnd;
    //        callback = _callback;
    //    }
    //}
}
