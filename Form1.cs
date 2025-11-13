using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace QuickLaunchLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ContextMenuStrip strip;
        private readonly List<string> EXCLUSION_DIRECTORY = new List<string>() { "User Pinned" };
        private readonly List<string> EXCLUSION_FILE = new List<string>() { "desktop.ini" };
        private readonly string QUICK_LAUNCH_PATH = GetQuickLaunchPath();

        private class IniFile
        {
            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

            [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        }

        public class Config
        {
            public enum EnumHorizontal
            {
                Left,
                Center,
                Right
            }

            public enum EnumVertical
            {
                Top,
                Bottom
            }

            public enum EnumBackground
            {
                background_1,
                background_2,
                background_3,
                background_4,
            }

            EnumHorizontal _Horizontal = EnumHorizontal.Center;
            public EnumHorizontal Horizontal
            {
                get { return _Horizontal; }
            }

            EnumVertical _Vertical = EnumVertical.Bottom;
            public EnumVertical Vertical
            {
                get { return _Vertical; }
            }

            EnumBackground _Background = EnumBackground.background_1;
            public EnumBackground Background
            {
                get { return _Background; }
            }

            Form1 _form;

            public Config(Form1 form)
            {
                _form = form;
            }

            public void LoadPosition()
            {
                string inifile = Assembly.GetEntryAssembly().Location;
                inifile = inifile.Substring(0, inifile.LastIndexOf(".")) + ".ini";

                if (File.Exists(inifile))
                {
                    int capacitySize = 256;
                    StringBuilder sb = new StringBuilder(capacitySize);

                    IniFile.GetPrivateProfileString("Position", "Horizontal", EnumHorizontal.Center.ToString(), sb, Convert.ToUInt32(sb.Capacity), inifile);

                    try
                    {
                        _Horizontal = (EnumHorizontal)Enum.Parse(typeof(EnumHorizontal), sb.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    IniFile.GetPrivateProfileString("Position", "Vertical", EnumVertical.Bottom.ToString(), sb, Convert.ToUInt32(sb.Capacity), inifile);
                    try
                    {
                        _Vertical = (EnumVertical)Enum.Parse(typeof(EnumVertical), sb.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                SetPosition(_Horizontal, _Vertical, false);
            }

            public void SetPosition(EnumHorizontal h, EnumVertical v, bool writeIniFile)
            {
                _Horizontal = h;
                _Vertical = v;

                int workingAreaHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                int workingAreaWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;

                if (_Horizontal == EnumHorizontal.Left)
                {
                    _form.Left = 0;
                }
                else if (_Horizontal == EnumHorizontal.Center)
                {
                    _form.Left = workingAreaWidth / 2 - _form.Width / 2;
                }
                else if (_Horizontal == EnumHorizontal.Right)
                {
                    _form.Left = workingAreaWidth - _form.Width;
                }

                if (_Vertical == EnumVertical.Top)
                {
                    _form.Top = 0;
                }
                else if (_Vertical == EnumVertical.Bottom)
                {
                    _form.Top = workingAreaHeight - _form.Height;
                }

                if (writeIniFile)
                {
                    string inifile = Assembly.GetEntryAssembly().Location;
                    inifile = inifile.Substring(0, inifile.LastIndexOf(".")) + ".ini";
                    IniFile.WritePrivateProfileString("Position", "Horizontal", _Horizontal.ToString(), inifile);
                    IniFile.WritePrivateProfileString("Position", "Vertical", _Vertical.ToString(), inifile);
                }
            }

            public void LoadBackground()
            {
                string inifile = Assembly.GetEntryAssembly().Location;
                inifile = inifile.Substring(0, inifile.LastIndexOf(".")) + ".ini";

                if (File.Exists(inifile))
                {
                    int capacitySize = 256;
                    StringBuilder sb = new StringBuilder(capacitySize);

                    IniFile.GetPrivateProfileString("Background", "Background", EnumBackground.background_1.ToString(), sb, Convert.ToUInt32(sb.Capacity), inifile);

                    try
                    {
                        _Background = (EnumBackground)Enum.Parse(typeof(EnumBackground), sb.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                SetBackground(_Background, false);
            }

            public void SetBackground(EnumBackground b, bool writeIniFile)
            {
                _Background = b;

                _form.BackgroundImage = (Bitmap)QuickLaunchLauncher.Properties.Resources.ResourceManager.GetObject(_Background.ToString());

                if (writeIniFile)
                {
                    string inifile = Assembly.GetEntryAssembly().Location;
                    inifile = inifile.Substring(0, inifile.LastIndexOf(".")) + ".ini";
                    IniFile.WritePrivateProfileString("Background", "Background", _Background.ToString(), inifile);
                }
            }
        }

        private Config _config;
        public Config FormConfig
        {
            get { return _config; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            // フォームの最大化、最小化ボタン、コントロールボックスを非表示にする
            //this.MaximizeBox = !this.MaximizeBox;
            //this.MinimizeBox = !this.MinimizeBox;
            //this.ControlBox = !this.ControlBox;

            // フォームのサイズを変更できないようにする
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // タイトルバーを消す
            //this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = "";

            // 幅変更
            this.Width = 82;
            this.Height = 25;

            // 位置変更・背景変更
            _config = new Config(this);
            _config.LoadPosition();
            _config.LoadBackground();

            // フォームを常に手前にする
            this.TopMost = true;

            CreateContextMenu();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            this.strip.Show(this, new Point(cp.X, cp.Y));
        }

        private void CreateContextMenu()
        {
            this.strip = new ContextMenuStrip();
            CreateQuickLaunchMenu(this.strip, null, QUICK_LAUNCH_PATH);
            CreateSystemMenu(this.strip);
        }

        private void CreateSystemMenu(ContextMenuStrip paramCms)
        {
            ToolStripMenuItemEx tsiG = new ToolStripMenuItemEx();
            tsiG.Text = "System Menu";

            ToolStripMenuItemEx tsi;
            tsi = new ToolStripMenuItemEx();
            tsi.Text = "Open Quick Launch Folder";
            tsi.Click += (sender, e) =>
            {
                try
                {
                    System.Diagnostics.Process.Start(QUICK_LAUNCH_PATH);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
            tsiG.DropDownItems.Add(tsi);

            tsi = new ToolStripMenuItemEx();
            tsi.Text = "Refresh";
            tsi.Click += (sender, e) => { CreateContextMenu(); };
            tsiG.DropDownItems.Add(tsi);

            tsi = new ToolStripMenuItemEx();
            tsi.Text = "Setting";
            tsi.Click += (sender, e) =>
            {
                Form2 fm = new Form2();
                fm.SetTarget(this);
                fm.Show();
            };
            tsiG.DropDownItems.Add(tsi);

            tsi = new ToolStripMenuItemEx();
            tsi.Text = "Quit";
            tsi.Click += (sender, e) => { this.Close(); };
            tsiG.DropDownItems.Add(tsi);

            paramCms.Items.Add(new ToolStripSeparator());
            paramCms.Items.Add(tsiG);
            paramCms.Items.Add(new ToolStripSeparator());
        }

        private void CreateQuickLaunchMenu(ContextMenuStrip paramCms, ToolStripMenuItemEx paramTsi, string paramPath)
        {

            string[] directoryArray = Directory.GetDirectories(paramPath);
            foreach (string d in directoryArray)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                if (EXCLUSION_DIRECTORY.Contains(di.Name)) continue;
                ToolStripMenuItemEx tsi = new ToolStripMenuItemEx();
                tsi.Text = di.Name;
                tsi.Image = GetIconBitMap(di.FullName);
                tsi.Click += (sender, e) => { ToolStripMenuItem_Click(sender, e, di.FullName); };
                CreateQuickLaunchMenu(null, tsi, d);
                if (paramCms != null)
                {
                    paramCms.Items.Add(tsi);
                }
                else
                {
                    paramTsi.DropDownItems.Add(tsi);
                }
            }

            string[] fileArray = Directory.GetFiles(paramPath);
            foreach (string f in fileArray)
            {
                FileInfo fi = new FileInfo(f);
                if (EXCLUSION_FILE.Contains(fi.Name)) continue;
                ToolStripMenuItemEx tsi = new ToolStripMenuItemEx();
                string name = fi.Name;
                if (name.EndsWith(".lnk"))
                {
                    name = name.Substring(0, name.LastIndexOf("."));
                }
                tsi.Text = name;
                tsi.Image = GetIconBitMap(fi.FullName);
                tsi.Click += (sender, e) => { ToolStripMenuItem_Click(sender, e, fi.FullName); };
                if (paramCms != null)
                {
                    paramCms.Items.Add(tsi);
                }
                else
                {
                    paramTsi.DropDownItems.Add(tsi);
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e, string fullName)
        {
            if (((ToolStripMenuItemEx)sender).IsRightClick)
            {
                if (Directory.Exists(fullName))
                {
                    ContextMenuStrip strip2 = new ContextMenuStrip();
                    ToolStripMenuItem tsi;
                    tsi = new ToolStripMenuItem();
                    tsi.Text = "Open Folder";
                    tsi.Click += (sender1, e1) =>
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(fullName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    };
                    strip2.Items.Add(tsi);
                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    strip2.Show(sp);
                }
                else if (File.Exists(fullName))
                {
                    ContextMenuStrip strip2 = new ContextMenuStrip();
                    ToolStripMenuItem tsi;

                    tsi = new ToolStripMenuItem();
                    tsi.Text = "Open file location";
                    tsi.Click += (sender1, e1) =>
                    {
                        if (fullName.EndsWith(".lnk"))
                        {
                            //IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                            //IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(fullName);
                            Type type = Type.GetTypeFromProgID("WScript.Shell");
                            dynamic shell = Activator.CreateInstance(type);
                            dynamic shortcut = shell.CreateShortcut(fullName);
                            string targetPath = shortcut.TargetPath;
                            if (string.IsNullOrEmpty(targetPath)) return;
                            targetPath = targetPath.Substring(0, targetPath.LastIndexOf("\\"));
                            try
                            {
                                System.Diagnostics.Process.Start(targetPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            string targetPath = fullName.Substring(0, fullName.LastIndexOf("\\"));
                            try
                            {
                                System.Diagnostics.Process.Start(targetPath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    };
                    strip2.Items.Add(tsi);

                    tsi = new ToolStripMenuItem();
                    tsi.Text = "Properties";
                    tsi.Click += (sender1, e1) =>
                    {
                        try
                        {
                            Win32.ShowFileProperties(fullName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    };
                    strip2.Items.Add(tsi);

                    System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                    strip2.Show(sp);
                }
            }
            else
            {
                if (File.Exists(fullName))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(fullName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private static string GetQuickLaunchPath()
        {
            string[] cmds = System.Environment.GetCommandLineArgs();
            if (cmds.Length > 1)
            {
                if (Directory.Exists(cmds[1]))
                {
                    return cmds[1];
                }
            }

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            path += (path.EndsWith("\\") ? "" : "\\") + @"Microsoft\Internet Explorer\Quick Launch";
            return path;
        }

        private System.Drawing.Bitmap GetIconBitMap(string fileFullName)
        {
            try
            {
                return GetIcon(fileFullName).ToBitmap();
            }
            catch (Exception ex)
            {
                Console.WriteLine(fileFullName);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                System.Drawing.Bitmap img = new System.Drawing.Bitmap(16, 16);
                return img;
            }
        }

        private System.Drawing.Icon GetIcon(string fileFullName)
        {
            Win32.SHFILEINFO shinfo = new Win32.SHFILEINFO();
            IntPtr hImgSmall = Win32.SHGetFileInfo(fileFullName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);
            System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            return icon;
        }

        private class Win32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                public IntPtr hIcon;
                public IntPtr iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            };

            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon  
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon  

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct SHELLEXECUTEINFO
            {
                public int cbSize;
                public uint fMask;
                public IntPtr hwnd;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpVerb;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpFile;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpParameters;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpDirectory;
                public int nShow;
                public IntPtr hInstApp;
                public IntPtr lpIDList;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpClass;
                public IntPtr hkeyClass;
                public uint dwHotKey;
                public IntPtr hIcon;
                public IntPtr hProcess;
            }

            private const int SW_SHOW = 5;
            private const uint SEE_MASK_INVOKEIDLIST = 12;
            public static bool ShowFileProperties(string Filename)
            {
                SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
                info.cbSize = Marshal.SizeOf(info);
                info.lpVerb = "properties";
                info.lpFile = Filename;
                info.nShow = SW_SHOW;
                info.fMask = SEE_MASK_INVOKEIDLIST;
                return ShellExecuteEx(ref info);
            }
        }

        class ToolStripMenuItemEx : ToolStripMenuItem
        {
            public bool IsRightClick { get; set; }
            protected override void OnMouseDown(MouseEventArgs e)
            {
                IsRightClick = (e.Button == MouseButtons.Right);
                base.OnMouseDown(e);
            }
        }
    }
}
