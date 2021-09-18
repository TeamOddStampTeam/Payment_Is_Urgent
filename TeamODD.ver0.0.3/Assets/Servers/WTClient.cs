using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class WTClient : MonoBehaviour
{
    public class AsyncObject
    {
        public Byte[] Buffer;
        public Socket WorkingSocket;
        public AsyncObject(Int32 bufferSize)
        {
            this.Buffer = new Byte[bufferSize];
        }
    }
    //데이터 번들 생성
    static string UserName = "사용자";
    static string RoomNumber = "0000000";
    public static string InformationText = "NA";
    string 안녕 = "Hello";
    //서버 연결 확인용
    public static bool ReadyToTelec = false;
    //제어
    public static bool PlayEnterServer = false;
    public static bool PlayEnterServer_KP = false;
    public static bool DataSend = false;
    public static bool SendToServer = false;
    // 개행 코드
    /*
    char CR = (char)0x0D;
    char LF = (char)0x0A;
    */
    private void Awake()
    {
        SaveData.DoLoadData = true;
    }

    // 수신 버퍼
    StringBuilder sb = new StringBuilder();
    //소켓 생성
    private Socket socket_M = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    private static AsyncCallback m_fnReceiveHandler = new AsyncCallback(handleDataReceive);

    private static void handleDataReceive(IAsyncResult ar)
    {
        // 넘겨진 추가 정보를 가져옵니다.
        AsyncObject ao = (AsyncObject)ar.AsyncState;

        // 자료를 수신하고, 수신받은 바이트를 가져옵니다.
        Int32 recvBytes = ao.WorkingSocket.EndReceive(ar);

        // 수신받은 자료의 크기가 1 이상일 때에만 자료 처리
        if (recvBytes > 0)
        {
                //여기에 자료를 처리하는 작업을 하시면 됩니다.
        }

        ao.WorkingSocket.BeginReceive(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnReceiveHandler, ao);
    }

    public void CutConnect()
    {
        byte[] EXIT = Encoding.Unicode.GetBytes("exit");
        try
        {
            socket_M.Send(EXIT, EXIT.Length, SocketFlags.None);

            SceneManager.LoadScene("SampleScene");
        }
        catch
        {
            UnityEngine.Debug.Log("전송 불가");

            //서버 오류 메세지를 유니티 화면에 올림
            //씬에 따라 메세지 출력
            SceneManager.LoadScene("SampleScene");
        }

        ReadyToTelec = false;
        PlayEnterServer = false;
        PlayEnterServer_KP = false;
    }

    private void UnUsedKeyCheck()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape)) //게임 중 뒤로가기를 했을 때
            {
                try{ CutConnect(); }
                catch{ UnityEngine.Debug.Log("하드웨어 입력에 대한 정보 전송 불가"); }
            }
            if (Input.GetKey(KeyCode.Home)) //게임 중 홈 버튼을 누를 때
            {
                try{ CutConnect(); }
                catch{ UnityEngine.Debug.Log("하드웨어 입력에 대한 정보 전송 불가"); }
            }
            if (Input.GetKey(KeyCode.Menu))  //게임 중 메뉴 버튼을 누를 때
            {
                try{ CutConnect(); }
                catch{ UnityEngine.Debug.Log("하드웨어 입력에 대한 정보 전송 불가"); }
            }
        }
    }

    void StatsServ()
    {
        ThreadPool.QueueUserWorkItem((_) =>
        {
            while (true)
            {
                try
                {
                    // 서버로 오는 메시지를 받는다.
                    byte[] ret = new byte[128];
                    socket_M.Receive(ret, 128, SocketFlags.None);
                    // 메시지를 unicode로 변환해서 버퍼에 넣는다.
                    sb.Append(Encoding.Unicode.GetString(ret, 0, 128));
                    // 버퍼의 메시지를 콘솔에 출력
                    string msg = sb.ToString();
                    UnityEngine.Debug.Log(msg);
                    // 버퍼를 비운다.
                    sb.Clear();
                }
                catch
                {
                    UnityEngine.Debug.Log("오류 수신부분");
                    return;
                }
            }
        });
    }

    void Update()
    {
        if(PlayEnterServer==true)
        {
            //유저 데이터 불러오기
            SaveData.DoLoadData = true;
            //데이터 수정사항
            UserName = SaveData.Name;
            RoomNumber = "Local_";
            int SetNumbers = 0;
            // 소켓에 연결한다
            try
            {
                //접속
                socket_M.Connect(IPAddress.Parse("101.101.210.145"), 29990); //"101.101.210.145:29990"
            }
            catch
            {
                ServerWaitErrorText.SWET_Error = 1;
                return;
            }
            //서버 활성화
            ReadyToTelec = true;
            //유저정보 전달
            string U_D = UserName + ":" + RoomNumber + ":";
            byte[] U_Db = Encoding.Unicode.GetBytes(U_D+"#"+안녕+"#");

            try
            {
                socket_M.Send(U_Db, U_Db.Length, SocketFlags.None);
            }
            catch
            {
                ServerWaitErrorText.SWET_Error = 1;
                return;
            }

            PlayEnterServer = false;
        }

        else if(PlayEnterServer_KP==true)
        {
            //유저 데이터 불러오기
            SaveData.DoLoadData = true;
            //데이터 수정사항
            UserName = SaveData.Name;
            RoomNumber = NumberKeypad.RoomCodes.ToString();
            // 소켓에 연결한다
            try
            {
                // 로컬의 29990포트로 접속
                socket_M.Connect(IPAddress.Parse("127.0.0.1"), 29990); //"175.213.85.1" 추후 고정 아이피 설정
            }
            catch
            {
                ServerWaitErrorText.SWET_Error = 1;
                return;
            }
            //서버 활성화
            ReadyToTelec = true;
            //유저정보 전달
            string U_D = UserName + ":" + RoomNumber + ":";
            byte[] U_Db = Encoding.Unicode.GetBytes(U_D + "#" + 안녕 + "#");

            try
            {
                socket_M.Send(U_Db, U_Db.Length, SocketFlags.None);
            }
            catch
            {
                ServerWaitErrorText.SWET_Error = 1;
                return;
            }

            PlayEnterServer_KP = false;
        }

        if(DataSend==true)
        {
            try
            {
                if (ReadyToTelec == true) //통신상태 활성화
                {
                    // 콘솔 입력 대기
                    string U_D = UserName + ":" + RoomNumber + ":";
                    string Information = InformationText;
                    byte[] data = Encoding.Unicode.GetBytes(U_D + " #" + Information + "#");
                    // 송신.
                    socket_M.Send(data, data.Length, SocketFlags.None);
                }
            }
            catch
            {
                //오류 발생으로 전송이 되지 않음
            }

            DataSend = false;
        }


        if(ReadyToTelec==true)
        {
            byte[] BOM = new byte[128];
            try
            {
                try
                {
                    StatsServ();
                }
                catch
                {
                    ServerWaitErrorText.SWET_Error = 3;
                    CutConnect(); //오류로 인한 서버 탈출
                    ReadyToTelec = false;
                }

                // 버퍼의 메시지를 콘솔에 출력
                string msg = sb.ToString();
                UnityEngine.Debug.Log(msg);

                //접속

                //분석

                // 버퍼를 비운다.
                sb.Clear();
            }
            catch
            {
                ServerWaitErrorText.SWET_Error = 3;
                CutConnect(); //오류로 인한 서버 탈출
                //ReadyToTelec = false;
            }
        }
        else
        {
            //
        }
    }
}
