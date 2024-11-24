using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;


public class PSVR2TriggerController : MonoBehaviour
{
    static UdpClient client;
    static IPEndPoint endPoint;
    public static PSVR2TriggerController Instance;
    public bool SetNormalAfterDestroy = true;

    private DateTime TimeSent;
    private List<Device> devices = new List<Device>();
    private Dictionary<Trigger, int> triggerToDeviceIndex = new Dictionary<Trigger, int>();



    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        Connect();
    }


    void UpdateTriggerToDeviceMapping()
    {
        foreach (var device in devices)
        {
            if (device.DeviceType == Shared.DeviceType.PS_VR2_RightController)
            {
                triggerToDeviceIndex[Trigger.Right] = device.Index;
                Debug.Log("Right PSVR2 Controller Set");
            }
            else if (device.DeviceType == Shared.DeviceType.PS_VR2_LeftController)
            {
                triggerToDeviceIndex[Trigger.Left] = device.Index;
            }
        }
    }



    //SetTriggers
    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode)
    {
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }
    }

    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode, int sensitivity)
    {
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode, sensitivity };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }
    }


    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int strenght, int frequency)
    {
        //AutomaticGun
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode, start, strenght, frequency };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }


    }
    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int end, int StrenghtA, int StrenghtB, int frequency, int period)
    {
        //Machine
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode, start, end, StrenghtA, StrenghtB, frequency, period };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }

    }
    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int end, int firstFoot, int secondFoot, int frequency)
    {
        //Machine
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode, start, end, firstFoot, secondFoot, frequency };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }

    }
    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int force)
    {
        //Rezistance
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode, start, force };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }

    }
    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode, int start, int end, int startStrength, int endStrength)
    {
        //SlopeFeedback
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode, start, end, startStrength, endStrength };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }

    }


    public void SetTriggerState(Trigger trigger, TriggerMode triggerMode, CustomTriggerValueMode valueMode, int force1, int force2, int force3, int force4, int force5, int force6, int force7)
    {
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            try
            {
                Packet p = new Packet();
                p.instructions = new Instruction[1];
                p.instructions[0].type = InstructionType.TriggerUpdate;
                p.instructions[0].parameters = new object[] { controllerIndex, trigger, triggerMode, valueMode, force1, force2, force3, force4, force5, force6, force7 };
                Send(p);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }
        //CustomTrigger

    }


    //SetTriggerThreshold
    public void SetThreshold(Trigger trigger, int strenght)
    {
        if (triggerToDeviceIndex.TryGetValue(trigger, out int controllerIndex))
        {
            Packet p = new Packet();
            p.instructions = new Instruction[1];
            p.instructions[0].type = InstructionType.TriggerThreshold;
            p.instructions[0].parameters = new object[] { controllerIndex, trigger, strenght };
            Send(p);
        }
        else
        {
            Debug.LogWarning($"No device found for trigger {trigger}");
        }

    }
    void Connect()
    {
        Debug.Log("Starting connection...");

        try
        {
            client = new UdpClient();
            Debug.Log("UdpClient initialized.");

            var portNumber = FetchPortNumber();

            endPoint = new IPEndPoint(Triggers.localhost, Convert.ToInt32(portNumber));
            Debug.Log($"EndPoint created: {endPoint.Address}:{endPoint.Port}");
            GetConnectedDevicesFromDSX();
        }
        catch (Exception ex)
        {
            Debug.Log($"Error during connection: {ex.Message}");
        }

        Debug.Log("Connection attempt completed.");
    }

    void GetConnectedDevicesFromDSX()
    {
        // Get Data from DSX first about connected devices
        Packet packet = new Packet();

        packet = AddResetToPacket(packet, 0);

        Send(packet);

        GetDataFromDSX();
        UpdateTriggerToDeviceMapping();
    }

    void GetDataFromDSX()
    {
        Debug.Log("Waiting for Server Response...\n");
        try
        {
            byte[] bytesReceivedFromServer = client.Receive(ref endPoint);

            if (bytesReceivedFromServer.Length > 0)
            {
                ServerResponse ServerResponseJson = JsonConvert.DeserializeObject<ServerResponse>($"{Encoding.ASCII.GetString(bytesReceivedFromServer, 0, bytesReceivedFromServer.Length)}");
                Debug.Log("===================================================================");

                DateTime CurrentTime = DateTime.Now;
                TimeSpan Timespan = CurrentTime - TimeSent;
                // First send shows high Milliseconds response time for some reason

                Debug.Log($"Status                  - {ServerResponseJson.Status}");
                Debug.Log($"Time Received           - {ServerResponseJson.TimeReceived}, took: {Timespan.TotalMilliseconds} to receive response from DSX");
                Debug.Log($"isControllerConnected   - {ServerResponseJson.isControllerConnected}");
                Debug.Log($"BatteryLevel            - {ServerResponseJson.BatteryLevel}\n");


                devices.Clear();
                foreach (Device device in ServerResponseJson.Devices)
                {
                    devices.Add(device);

                    Debug.Log("-------------------------------");
                    Debug.Log($"Controller Index    - {device.Index}");
                    Debug.Log($"MacAddress          - {device.MacAddress}");
                    Debug.Log($"DeviceType          - {device.DeviceType}");
                    Debug.Log($"BatteryLevel        - {device.BatteryLevel}");
                    Debug.Log($"IsSupportAT         - {device.IsSupportAT}");
                    Debug.Log($"IsSupportLightBar   - {device.IsSupportLightBar}");
                    Debug.Log($"IsSupportPlayerLED  - {device.IsSupportPlayerLED}");
                    Debug.Log($"IsSupportMicLED     - {device.IsSupportMicLED}");
                    Debug.Log("-------------------------------\n");
                }

                Debug.Log("===================================================================\n");
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    static Packet AddResetToPacket(Packet packet, int controllerIndex)
    {
        int instCount;

        if (packet.instructions == null)
        {
            packet.instructions = new Instruction[1];
            instCount = 0;
        }
        else
        {
            instCount = packet.instructions.Length;
            Array.Resize(ref packet.instructions, instCount + 1);
        }

        packet.instructions[instCount] = new Instruction
        {
            type = InstructionType.ResetToUserSettings,
            parameters = new object[] { controllerIndex }
        };

        return packet;
    }


    void Send(Packet data)
    {
        var RequestData = Encoding.ASCII.GetBytes(Triggers.PacketToJson(data));
        client.Send(RequestData, RequestData.Length, endPoint);
    }


    void OnDestroy()
    {
        if (SetNormalAfterDestroy)
        {
            SetTriggerState(Trigger.Left, TriggerMode.Normal);
            SetTriggerState(Trigger.Right, TriggerMode.Normal);
        }
    }

    int FetchPortNumber()
    {
        // ONLY WORKS WITH DSX v3.1 BETA 1.37 AND ABOVE
        const int defaultPort = 6969;
        const string appFolderName = "DSX";
        const string fileName = "DSX_UDP_PortNumber.txt";
        try
        {
            Console.WriteLine("Fetching Port Number locally...");
            // Get the Local AppData path for the application
            string localAppDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                appFolderName
            );
            string portFilePath = Path.Combine(localAppDataPath, fileName);
            // Check if the file exists
            if (File.Exists(portFilePath))
            {
                Console.WriteLine($"Port file found at: {portFilePath}");
                // Try to read and parse the port number
                string portNumberContent = File.ReadAllText(portFilePath).Trim();
                if (int.TryParse(portNumberContent, out int portNumber))
                {
                    Console.WriteLine($"Port Number successfully read: {portNumber}");
                    return portNumber;
                }
                else
                {
                    Console.WriteLine($"Invalid port number format in file: {portNumberContent}");
                }
            }
            else
            {
                Console.WriteLine($"Port file not found at: {portFilePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while fetching the port number: {ex.Message}");
        }
        // Fallback to default port number
        Console.WriteLine($"Falling back to default port number: {defaultPort}");
        return defaultPort;
    }
}
