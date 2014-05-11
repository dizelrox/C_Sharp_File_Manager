using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace FileManager
{
	public partial class SidePanel : UserControl
	{
		private DirectoryInfo _curDir;
        private string _curPath;

	    public const string InitialDirectory = @"C:\";

	    public delegate void OperateInFolder (DirectoryInfo directory, string name);

	    public delegate void OperateOnGUI();

        public delegate void OperateWithEvents(MouseEventArgs e);

        public delegate void OperateOnDirectory(DirectoryInfo directory);

	    public delegate void OperateOnThisPanel(SidePanel sender);

	    public static event OperateInFolder OnDeleteFromFolderClicked;
	    public static event OperateOnGUI OnRefreshListClicked;
	    public static event OperateOnGUI OnDirectoryCompareClicked;
	    public static event OperateOnThisPanel OnCopyFileClicked;
	    public static event OperateOnThisPanel OnMoveFileClicked;
	    public static event OperateOnGUI OnFileCompareClicked;
        public static event OperateOnDirectory OnDirectoryCreateClicked;
        public static event OperateWithEvents OnItemDoubleClicked;

	    public SidePanel(MainForm mainForm)
		{
			InitializeComponent();
            comboBoxDrives.DropDownStyle = ComboBoxStyle.DropDownList;
            
            comboBoxDrives.Items.AddRange(DriveInfo.GetDrives());
		    comboBoxDrives.SelectedItem = comboBoxDrives.Items[0];
        }

        public object SelectedItem
        {
            get { return listBox1.SelectedItem; }
            
        }

	    public void RefreshList()
	    {
            string dir = CurrentDirectory;
            CurrentDirectory = SidePanel.InitialDirectory;
            CurrentDirectory = dir;
	    }
	    
	    public string CurrentDirectory
		{
			get { return _curDir.FullName; }
			set
			{
				if (_curDir != null && (value == _curDir.FullName || !Directory.Exists(value))) //if no Dir or the same
					return;

			    try //Get access to the directory
			    {
			        DirectorySecurity ds = Directory.GetAccessControl(value);
			    }
			    catch (UnauthorizedAccessException exception)
			    {
			        MessageBox.Show(exception.Message, "Access denied");
                    return;
			    }
			    
				_curDir = new DirectoryInfo(value);

			    listBox1.DataSource = null;
				listBox1.Items.Clear();


                foreach (string path in Directory.GetDirectories(value)) // Cut the string to only show names without path for Dirs
                {
                    var dirName = new DirectoryInfo(path);
                    listBox1.Items.Add(dirName.Name);

                }

                foreach (string path in Directory.GetFiles(value)) // Cut the string to only show names without path for Files
                {
                    listBox1.Items.Add(Path.GetFileName(path));

                }

                //listBox1.Items.AddRange(Directory.GetDirectories(value));
                //listBox1.Items.AddRange(Directory.GetFiles(value));

				pathBox.Text = _curDir.ToString();
                _curPath = value;
			    //string curDrive = _curPath[0].ToString().ToUpper() + ":\";

			    var curDrive = Path.GetPathRoot(_curPath);

			    foreach (object drive in comboBoxDrives.Items)
			    {
			        if (drive.ToString().ToUpper() == curDrive.ToUpper())
			            comboBoxDrives.SelectedItem = drive;
			    }
			}
		}



		private void SidePanel_Load(object sender, EventArgs e)
		{
			CurrentDirectory = InitialDirectory;
		}

		private void tsb_UpDir_Click(object sender, EventArgs e)
		{
            if (Directory.GetParent(CurrentDirectory) != null)
			CurrentDirectory = 
				Directory.GetParent(CurrentDirectory).ToString();
		}

		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			base.OnDoubleClick(e);

			if (listBox1.SelectedItem == null)
				return;

			string itemString = listBox1.SelectedItem.ToString();

            if (pathBox.Text != "Search Results") 
                itemString = Path.Combine(_curPath, itemString);
            


			if (Directory.Exists(itemString))
			{
				CurrentDirectory = itemString;
			} else if (File.Exists(itemString))
			{

			    try
			    {
			        System.Diagnostics.Process.Start(itemString);
			    }
                catch (Win32Exception exception)
                {
                    
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                }
			}
		}



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (Directory.Exists(pathBox.Text))
                {
                    CurrentDirectory = pathBox.Text;
                }
            }
        }

        private void rootDirBtn_Click(object sender, EventArgs e)
        {
            CurrentDirectory = Path.GetPathRoot(CurrentDirectory);
        }

        private void newDirBtn_Click(object sender, EventArgs e)
        {
            OnDirectoryCreateClicked(new DirectoryInfo(CurrentDirectory));
        }

        private void copyItemBtn_Click(object sender, EventArgs e)
        {
            if (OnCopyFileClicked != null)
                OnCopyFileClicked(this);

        }

        private void moveItemBtn_Click(object sender, EventArgs e)
        {
            if (OnMoveFileClicked != null)
                OnMoveFileClicked(this);
        }

        private void refreshListsBtn_Click(object sender, EventArgs e)
        {
            if (OnRefreshListClicked != null)
                OnRefreshListClicked();
        }

        private void deleteItemBtn_Click(object sender, EventArgs e)
        {
            if (OnDeleteFromFolderClicked != null)
                OnDeleteFromFolderClicked(new DirectoryInfo(CurrentDirectory), this.SelectedItem.ToString());
        }

        private void compareDirsBtn_Click(object sender, EventArgs e)
        {

            if (OnDirectoryCompareClicked != null)
                OnDirectoryCompareClicked();

        }

        private void pathBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                try
                {
                    if (Directory.Exists(Path.GetFullPath(pathBox.Text)))
                    {
                        CurrentDirectory = Path.GetFullPath(pathBox.Text);
                    }
                }
                catch (ArgumentException)
                {

                    var filterItems = Operation.FilterItems(pathBox.Text);
                    if (filterItems != null)
                        listBox1.DataSource = filterItems;
                }
                

                
            }
        }



        private void pathBox_Leave(object sender, EventArgs e)
        {
            pathBox.Text = CurrentDirectory;
        }


        private void compareFilesBtn_Click(object sender, EventArgs e)
        {
            if (OnFileCompareClicked != null)
                OnFileCompareClicked();
        }

        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveInfo selectedDrive = (DriveInfo) comboBoxDrives.SelectedItem;
            if (selectedDrive.IsReady)
            {
                this.CurrentDirectory = comboBoxDrives.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("This drive isn't ready!", "Drive not ready", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string curDrive = Path.GetPathRoot(CurrentDirectory);
                foreach (object currentDrive in comboBoxDrives.Items)
                {
                    if (currentDrive.ToString().ToUpper() == curDrive.ToUpper())
                        comboBoxDrives.SelectedItem = currentDrive;
                }

            }

        }

        private void txtEditorBtn_Click(object sender, EventArgs e)
        {
            string filename = PromptDialog.ShowDialog("Enter file name:", "New text file");

            TextEditor txt = new TextEditor(Path.Combine(this.CurrentDirectory, filename));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string searchValue = PromptDialog.ShowDialog("Enter search term:", "Search");

            if (!String.IsNullOrEmpty(searchValue))
            {
                listBox1.Items.Clear();
                //this._curPath = "Search Results";

                Operation.Search(searchValue, new DirectoryInfo(CurrentDirectory), listBox1);
                listBox1.DataSource =  Operation.Search(searchValue, new DirectoryInfo(CurrentDirectory), listBox1);
            }
        }


	}


}