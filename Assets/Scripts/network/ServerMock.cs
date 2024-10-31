using System.Collections;
using System.Collections.Generic;
using NetWork;
using Table;
using UnityEngine;

public class ServerMock
{
    
    private readonly static object lockObj = new object();
    private static ServerMock _instance;

    public static ServerMock Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (lockObj)
                {
                    _instance = new ServerMock();
                }
            }

            return _instance;
        }
    }

    public void ClientOnceMove(MoveReq moveReq)
    {
        var result = new MoveNotify();
        result.move = moveReq.move;
        
        var msg = new Msg();
        msg.name = "Table.MoveNotify";
        msg.body = result;
        NetWork.NetClient.Instance().MockAddMsg(msg);
    }

    public void ClientMatch()
    {
        var result = new MatchResult();
        result.i_am_red = true;
        result.name = "testred1";
        result.lv = 1;
        result.icon = 1;
        
        var msg = new Msg();
        msg.name = "Table.MatchResult";
        msg.body = result;
        NetWork.NetClient.Instance().MockAddMsg(msg);
    }
}