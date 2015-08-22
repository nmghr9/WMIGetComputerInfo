﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Text.RegularExpressions;

namespace WMIGetComputerInfo
{
    public partial class GetComputerInfo : Form
    {
        public string ComputerName = string.Empty;
        Dictionary<string, string[]> searchQuery = new Dictionary<string, string[]>();
        TreeNode oldChildNode;

        public GetComputerInfo()
        {
            InitializeComponent();
        }

        private void InitDictionary()
        {
            //Query String Name Directory
            string[] hardwareValue =
            {
                "Win32_1394Controller",
                "Win32_1394ControllerDevice",
                "Win32_BaseBoard",
                "Win32_Battery",
                "Win32_BIOS",
                "Win32_Bus",
                "Win32_CDROMDrive",
                "Win32_CIMLogicalDeviceCIMDataFile",
                "Win32_DeviceBus",
                "Win32_DeviceMemoryAddress",
                "Win32_DeviceSettings",
                "Win32_DisplayConfiguration",
                "Win32_DisplayControllerConfiguration",
                "Win32_DMAChannel",
                "Win32_DriverVXD",
                "Win32_FloppyController",
                "Win32_FloppyDrive",
                "Win32_HeatPipe",
                "Win32_IDEController",
                "Win32_IDEControllerDevice",
                "Win32_InfraredDevice",
                "Win32_IRQResource",
                "Win32_Keyboard",
                "Win32_MotherboardDevice",
                "Win32_OnBoardDevice",
                "Win32_PCMCIAController",
                "Win32_PNPAllocatedResource",
                "Win32_PnPDevice",
                "Win32_PnPEntity",
                "Win32_PointingDevice",
                "Win32_PortableBattery",
                "Win32_PortConnector",
                "Win32_PortResource",
                "Win32_POTSModem",
                "Win32_POTSModemToSerialPort",
                "Win32_PowerManagementEvent",
                "Win32_Printer",
                "Win32_PrinterConfiguration",
                "Win32_PrinterController",
                "Win32_PrinterDriverDll",
                "Win32_PrinterSetting",
                "Win32_PrinterShare",
                "Win32_PrintJob",
                "Win32_Processor",
                "Win32_SCSIController",
                "Win32_SCSIControllerDevice",
                "Win32_SerialPort",
                "Win32_SerialPortConfiguration",
                "Win32_SerialPortSetting",
                "Win32_SMBIOSMemory",
                "Win32_SoundDevice",
                "Win32_TemperatureProbe",
                "Win32_USBController",
                "Win32_USBControllerDevice",
                "Win32_VideoConfiguration",
                "Win32_VideoController",
                "Win32_VideoSettings",
                "Win32_VoltageProbe"
            };
            searchQuery.Add("Hardware", hardwareValue);

            string[] dataStorageValue =
            {
                "Win32_DiskDrive",
                "Win32_DiskDriveToDiskPartition",
                "Win32_DiskPartition",
                "Win32_LogicalDisk",
                "Win32_LogicalDiskRootDirectory",
                "Win32_LogicalDiskToPartition",
                "Win32_LogicalFileAccess",
                "Win32_LogicalFileAuditing",
                "Win32_LogicalFileGroup",
                "Win32_LogicalFileOwner",
                "Win32_LogicalFileSecuritySetting",
                "Win32_TapeDrive"
            };
            searchQuery.Add("DataStorage", dataStorageValue);

            string[] memoryValue =
            {
                "Win32_CacheMemory",
                "Win32_MemoryArray",
                "Win32_MemoryArrayLocation",
                "Win32_MemoryDevice",
                "Win32_MemoryDeviceArray",
                "Win32_MemoryDeviceLocation",
                "Win32_AssociatedProcessorMemory",
                "Win32_DeviceMemoryAddress",
                "Win32_LogicalMemoryConfiguration",
                "Win32_PerfRawData_PerfOS_Memory",
                "Win32_PhysicalMemory",
                "Win32_PhysicalMemoryArray",
                "Win32_PhysicalMemoryLocation",
                "Win32_SMBIOSMemory",
                "Win32_SystemLogicalMemoryConfiguration",
                "Win32_SystemMemoryResource"
            };
            searchQuery.Add("Memory", memoryValue);

            string[] systemInfoValue =
            {
                "Win32_ACE",
                "Win32_ActionCheck",
                "Win32_AllocatedResource",
                "Win32_ApplicationCommandLine",
                "Win32_ApplicationService",
                "Win32_ApplicationCommandLine",
                "Win32_ApplicationService",
                "Win32_Account",
                "Win32_AccountSID",
                "Win32_ACE",
                "Win32_ActionCheck",
                "Win32_AllocatedResource",
                "Win32_AssociatedBattery",
                "Win32_AssociatedProcessorMemory",
                "Win32_Process",
                "Win32_ProcessStartup",
                "Win32_Product",
                "Win32_ProductCheck",
                "Win32_ProductResource",
                "Win32_ProductSoftwareFeatures",
                "Win32_ProgIDSpecification",
                "Win32_ProgramGroup",
                "Win32_ProgramGroupContents",
                "Win32_ProgramGroupOrItem",
                "Win32_Property",
                "Win32_ProtocolBinding",
                "Win32_PublishComponentAction",
                "Win32_QuickFixEngineering",
                "Win32_Refrigeration",
                "Win32_Registry",
                "Win32_RegistryAction",
                "Win32_SystemAccount",
                "Win32_SystemBIOS",
                "Win32_SystemBootConfiguration",
                "Win32_SystemDesktop",
                "Win32_SystemDevices",
                "Win32_SystemDriver",
                "Win32_SystemDriverPNPEntity",
                "Win32_SystemEnclosure",
                "Win32_SystemLoadOrderGroups",
                "Win32_SystemLogicalMemoryConfiguration",
                "Win32_SystemMemoryResource",
                "Win32_SystemOperatingSystem",
                "Win32_SystemPartitions",
                "Win32_SystemProcesses",
                "Win32_SystemProgramGroups",
                "Win32_SystemResources",
                "Win32_SystemServices",
                "Win32_SystemSetting",
                "Win32_SystemSlot",
                "Win32_SystemSystemDriver",
                "Win32_SystemTimeZone",
                "Win32_ComputerSystem",
                "Win32_ComputerSystemProcessor",
                "Win32_ComputerSystemProduct",
                "Win32_Service",
                "Win32_ServiceControl",
                "Win32_ServiceSpecification",
                "Win32_ServiceSpecificationService"
            };
            searchQuery.Add("SystemInfo", systemInfoValue);

            string[] networkValue =
            {
                "Win32_NetworkAdapter",
                "Win32_NetworkAdapterConfiguration",
                "Win32_NetworkAdapterSetting",
                "Win32_NetworkClient",
                "Win32_NetworkConnection",
                "Win32_NetworkLoginProfile",
                "Win32_NetworkProtocol",
                "Win32_PerfRawData_Tcpip_ICMP",
                "Win32_PerfRawData_Tcpip_IP",
                "Win32_PerfRawData_Tcpip_NBTConnection",
                "Win32_PerfRawData_Tcpip_NetworkInterface",
                "Win32_PerfRawData_Tcpip_TCP",
                "Win32_PerfRawData_Tcpip_UDP",
                "Win32_PerfRawData_W3SVC_WebService",
                "Win32_SystemNetworkConnections"
            };
            searchQuery.Add("Network", networkValue);

            string[] userAndSecurityValue =
            {
                "Win32_SystemUsers",
                "Win32_Account",
                "Win32_AccountSID",
                "Win32_SecurityDescriptor",
                "Win32_SecuritySetting",
                "Win32_SecuritySettingAccess",
                "Win32_SecuritySettingAuditing",
                "Win32_SecuritySettingGroup",
                "Win32_SecuritySettingOfLogicalFile",
                "Win32_SecuritySettingOfLogicalShare",
                "Win32_SecuritySettingOfObject",
                "Win32_SecuritySettingOwner",
                "Win32_NTEventlogFile",
                "Win32_NTLogEvent",
                "Win32_NTLogEventComputer",
                "Win32_NTLogEventLog",
                "Win32_NTLogEventUser"
            };
            searchQuery.Add("UserAndSecurity", userAndSecurityValue);

            string[] developerValue =
            {
                "Win32_COMApplication",
                "Win32_COMApplicationClasses",
                "Win32_COMApplicationSettings",
                "Win32_COMClass",
                "Win32_ComClassAutoEmulator",
                "Win32_ComClassEmulator",
                "Win32_COMSetting",
                "Win32_ODBCAttribute",
                "Win32_ODBCDataSourceAttribute",
                "Win32_ODBCDataSourceSpecification",
                "Win32_ODBCDriverAttribute",
                "Win32_ODBCDriverSoftwareElement",
                "Win32_ODBCDriverSpecification",
                "Win32_ODBCSourceAttribute",
                "Win32_ODBCTranslatorSpecification",
                "Win32_Perf",
                "Win32_PerfRawData",
                "Win32_PerfRawData_ASP_ActiveServerPages",
                "Win32_PerfRawData_ASPNET_114322_ASPNETAppsv114322",
                "Win32_PerfRawData_ASPNET_114322_ASPNETv114322",
                "Win32_PerfRawData_ASPNET_ASPNET",
                "Win32_PerfRawData_ASPNET_ASPNETApplications",
                "Win32_PerfRawData_IAS_IASAccountingClients",
                "Win32_PerfRawData_IAS_IASAccountingServer",
                "Win32_PerfRawData_IAS_IASAuthenticationClients",
                "Win32_PerfRawData_IAS_IASAuthenticationServer",
                "Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal",
                "Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator",
                "Win32_PerfRawData_MSFTPSVC_FTPService",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerAccessMethods",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerBackupDevice",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerBufferManager",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerBufferPartition",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerCacheManager",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerDatabases",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerGeneralStatistics",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerLatches",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerLocks",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerMemoryManager",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationAgents",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationDist",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationLogreader",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationMerge",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationSnapshot",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerSQLStatistics",
                "Win32_PerfRawData_MSSQLSERVER_SQLServerUserSettable",
                "Win32_PerfRawData_NETFramework_NETCLRExceptions",
                "Win32_PerfRawData_NETFramework_NETCLRInterop",
                "Win32_PerfRawData_NETFramework_NETCLRJit",
                "Win32_PerfRawData_NETFramework_NETCLRLoading",
                "Win32_PerfRawData_NETFramework_NETCLRLocksAndThreads",
                "Win32_PerfRawData_NETFramework_NETCLRMemory",
                "Win32_PerfRawData_NETFramework_NETCLRRemoting",
                "Win32_PerfRawData_NETFramework_NETCLRSecurity",
                "Win32_PerfRawData_Outlook_Outlook",
                "Win32_PerfRawData_PerfDisk_PhysicalDisk",
                "Win32_PerfRawData_PerfNet_Browser",
                "Win32_PerfRawData_PerfNet_Redirector",
                "Win32_PerfRawData_PerfNet_Server",
                "Win32_PerfRawData_PerfNet_ServerWorkQueues",
                "Win32_PerfRawData_PerfOS_Cache",
                "Win32_PerfRawData_PerfOS_Memory",
                "Win32_PerfRawData_PerfOS_Objects",
                "Win32_PerfRawData_PerfOS_PagingFile",
                "Win32_PerfRawData_PerfOS_Processor",
                "Win32_PerfRawData_PerfOS_System",
                "Win32_PerfRawData_PerfProc_FullImage_Costly",
                "Win32_PerfRawData_PerfProc_Image_Costly",
                "Win32_PerfRawData_PerfProc_JobObject",
                "Win32_PerfRawData_PerfProc_JobObjectDetails",
                "Win32_PerfRawData_PerfProc_Process",
                "Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly",
                "Win32_PerfRawData_PerfProc_Thread",
                "Win32_PerfRawData_PerfProc_ThreadDetails_Costly",
                "Win32_PerfRawData_RemoteAccess_RASPort",
                "Win32_PerfRawData_RemoteAccess_RASTotal",
                "Win32_PerfRawData_RSVP_ACSPerRSVPService",
                "Win32_PerfRawData_Spooler_PrintQueue",
                "Win32_PerfRawData_TapiSrv_Telephony",
                "Win32_SoftwareElement",
                "Win32_SoftwareElementAction",
                "Win32_SoftwareElementCheck",
                "Win32_SoftwareElementCondition",
                "Win32_SoftwareElementResource",
                "Win32_SoftwareFeature",
                "Win32_SoftwareFeatureAction",
                "Win32_SoftwareFeatureCheck",
                "Win32_SoftwareFeatureParent",
                "Win32_SoftwareFeatureSoftwareElements",
                "Win32_ClassicCOMApplicationClasses",
                "Win32_ClassicCOMClass",
                "Win32_ClassicCOMClassSetting",
                "Win32_ClassicCOMClassSettings",
                "Win32_ClassInfoAction",
                "Win32_ClientApplicationSetting",
                "Win32_CodecFile",
                "Win32_DCOMApplication",
                "Win32_DCOMApplicationAccessAllowedSetting",
                "Win32_DCOMApplicationLaunchAllowedSetting",
                "Win32_DCOMApplicationSetting"
            };
            searchQuery.Add("Developer", developerValue);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            TreeNode rootNode = new TreeNode();
            foreach (var name in searcher.Get())
            {
                ComputerName = name["Name"].ToString();
            }

            if (ComputerName == string.Empty)
            {
                ComputerName = "MyComputer";
            }

            rootNode.Name = ComputerName;
            rootNode.Text = ComputerName;
            rootNode.Tag = ComputerName;

            this.attributeTree.Nodes.Add(rootNode);

            TreeNode hardware = new TreeNode();
            TreeNode dataStorage = new TreeNode();
            TreeNode memory = new TreeNode();
            TreeNode network = new TreeNode();
            TreeNode systemInfo = new TreeNode();
            TreeNode userAndSecurity = new TreeNode();
            TreeNode developer = new TreeNode();

            hardware.Name = "Hardware";
            hardware.Text = "Hardware";
            hardware.Tag = "Hardware";
            hardware.Nodes.Add("");

            dataStorage.Name = "DataStorage";
            dataStorage.Text = "DataStorage";
            dataStorage.Tag = "DataStorage";
            dataStorage.Nodes.Add("");

            memory.Name = "Memory";
            memory.Text = "Memory";
            memory.Tag = "Memory";
            memory.Nodes.Add("");

            network.Name = "Network";
            network.Text = "Network";
            network.Tag = "Network";
            network.Nodes.Add("");

            systemInfo.Name = "SystemInfo";
            systemInfo.Text = "SystemInfo";
            systemInfo.Tag = "SystemInfo";
            systemInfo.Nodes.Add("");

            userAndSecurity.Name = "UserAndSecurity";
            userAndSecurity.Text = "UserAndSecurity";
            userAndSecurity.Tag = "UserAndSecurity";
            userAndSecurity.Nodes.Add("");

            developer.Name = "Developer";
            developer.Text = "Developer";
            developer.Tag = "Developer";
            developer.Nodes.Add("");

            rootNode.Nodes.Add(hardware);
            rootNode.Nodes.Add(dataStorage);
            rootNode.Nodes.Add(memory);
            rootNode.Nodes.Add(network);
            rootNode.Nodes.Add(systemInfo);
            rootNode.Nodes.Add(userAndSecurity);
            rootNode.Nodes.Add(developer);

            InitDictionary();

            rootNode.Expand();
        }

        private void attributeTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
        }

        private void attributeTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            AddTreeViewItems(e.Node);
        }
        private void AddTreeViewItems(TreeNode e)
        {
            if (e.Name == ComputerName)
            {
                //MainNode
            }
            else
            {
                //ChildNode 1
                if (e.Name == "Hardware" || e.Name == "DataStorage" || e.Name == "Memory" || e.Name == "Network" || e.Name == "SystemInfo" || e.Name == "UserAndSecurity" || e.Name == "Developer")
                {
                    e.Nodes.Clear();

                    //Add API_NAME Node
                    foreach (string nodeName in searchQuery[e.Name])
                    {
                        TreeNode tn = new TreeNode();
                        tn.Name = nodeName;
                        tn.Text = nodeName;
                        tn.Tag = nodeName;

                        e.Nodes.Add(tn);
                        tn.Nodes.Add("");
                    }
                }
                else
                {
                    //ChildNode API_NAME
                    e.Nodes.Clear();

                    //Determine whether it is API_Name
                    int count = 0;
                    foreach (var a in Regex.Matches(e.Name, "Win32_"))
                    {
                        count++;
                    }

                    if (count > 0)
                    {
                        //Add Devices and Service Node
                        try
                        {
                            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + e.Name);
                            foreach (ManagementObject res in searcher.Get())
                            {
                                TreeNode tn = new TreeNode();
                                string name = res["Name"].ToString();
                                tn.Name = name;
                                tn.Text = name;
                                tn.Tag = name;

                                e.Nodes.Add(tn);
                                tn.Nodes.Add("");
                            }
                        }
                        catch (Exception except)
                        {
                            MessageBox.Show(except.Message);
                        }
                    }
                    else
                    {
                        //ChildNode Devices or Services Name
                        InforMationView.Items.Clear();

                        //Deal with old tree node logic
                        if (e == oldChildNode)
                        {
                            //Skip
                        }
                        else
                        {
                            if (oldChildNode == null)
                            {
                                oldChildNode = e;
                            }
                            else
                            {
                                //get '+' symbol ahead of the node name
                                oldChildNode.Nodes.Clear();
                                oldChildNode.Nodes.Add("");
                                oldChildNode.Collapse();

                                //renew oldChildNode
                                oldChildNode = e;
                            }

                            //update ListView
                            string tmpString = string.Format(@"select * from {0} where Name = '{1}'", e.Parent.Name, e.Name.AsQueryable());
                            //build Query String
                            string queryString = tmpString.Replace(@"\",@"\\");

                            ManagementObjectSearcher searcher = new ManagementObjectSearcher(queryString);

                            foreach (ManagementObject result in searcher.Get())
                            {
                                //Add listview title
                                ListViewGroup lvg = new ListViewGroup();
                                try
                                {
                                    lvg = InforMationView.Groups.Add(result["Name"].ToString(), result["Name"].ToString());
                                }
                                catch
                                {
                                    lvg = InforMationView.Groups.Add(result.ToString(), result.ToString());
                                }
                                if (result.Properties.Count <= 0)
                                {
                                    MessageBox.Show("No Info");
                                }

                                //Set Listview items and color
                                foreach (PropertyData pd in result.Properties)
                                {
                                    ListViewItem item = new ListViewItem(lvg);

                                    if (InforMationView.Items.Count % 2 == 0)
                                    {
                                        item.BackColor = Color.LightBlue;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.LightYellow;
                                    }

                                    item.Text = pd.Name;

                                    if (pd.Value != null && pd.Value.ToString() != "")
                                    {
                                        //pd.Value has three value type, set each type of value one by one
                                        switch (pd.Value.GetType().ToString())
                                        {
                                            case "System.String[]":

                                                item.SubItems.Add(String.Join(" ", (string[])pd.Value));

                                                break;

                                            case "System.UInt16[]":

                                                ushort[] ushorts = (ushort[])pd.Value;
                                                string res = String.Empty;
                                                foreach (ushort us in ushorts)
                                                {
                                                    res += us.ToString() + " ";
                                                }
                                                item.SubItems.Add(res);

                                                break;

                                            default:

                                                item.SubItems.Add(pd.Value.ToString());

                                                break;
                                        }
                                    }
                                    InforMationView.Items.Add(item);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
//無效類，提供的程序無法進行操作等，是否可以在程序沒有運行的時候清除這些分支
//運行卡死UI問題,async解決
//搜索出來的結果中有Name相同的，導致右側欄目多打印了,多打印不好解決，但是可以將其用乘法寫在左邊啊


    //123131231231231321321
