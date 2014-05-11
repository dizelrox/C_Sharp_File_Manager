using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    class Controller
    {
        private MainForm view;
        private Operation model;

        public Controller()
        {

            view = new MainForm();
            model = new Operation();
            Subscribe();
            Application.Run(view);
            
        }

        

        private void Subscribe()
        {
            SidePanel.OnDeleteFromFolderClicked += OnDeleteItemClickedListner;
            SidePanel.OnRefreshListClicked += OnRefreshListsClickedListner;
            SidePanel.OnDirectoryCompareClicked += OnCompareDirectoriesClickedListner;
            SidePanel.OnCopyFileClicked += OnCopyFileClickedListner;
            SidePanel.OnMoveFileClicked += OnMoveFileClickedListner;
            SidePanel.OnFileCompareClicked += OnFileCompareClickedListner;
            SidePanel.OnDirectoryCreateClicked += OnDirectoryCreateListner;
        }

        public void OnFileCompareClickedListner()
        {

            if (view.SidePanelLeft.SelectedItem != null && view.SidePanelRight.SelectedItem != null)
            {
                string path1 = Path.Combine(view.SidePanelLeft.CurrentDirectory, view.SidePanelLeft.SelectedItem.ToString());
                string path2 = Path.Combine(view.SidePanelRight.CurrentDirectory, view.SidePanelRight.SelectedItem.ToString());
                

                if (File.Exists(path1) && File.Exists(path2))
                {
                    if (model.IsFileContentEqual(new FileInfo(path1), new FileInfo(path2)))
                    {
                        MessageBox.Show("The files content is equal.", "Content Comparison", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The files content is different.", "Content Comparison", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("One or more selections is not a file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void OnMoveFileClickedListner(SidePanel source)
        {
            SidePanel target = (source == view.SidePanelLeft) ? view.SidePanelRight : view.SidePanelLeft;

            var sourceFile = new FileInfo(Path.Combine(source.CurrentDirectory, source.SelectedItem.ToString()));

            var destinationFolder = new DirectoryInfo(target.CurrentDirectory);

            if (File.Exists(sourceFile.FullName))
            {
                if (!File.Exists(Path.Combine(destinationFolder.FullName, sourceFile.Name)))
                {
                    model.MoveFileToDirectory(sourceFile, destinationFolder);
                    OnRefreshListsClickedListner();
                }
                else
                {
                    MessageBox.Show("This file already exists in the destination folder!", "Cannot Move",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void OnDirectoryCreateListner(DirectoryInfo CurrentDirectory)
        {
            string newDirValue = PromptDialog.ShowDialog("Enter name:", "New Folder");

            if (newDirValue == "")
                return;

            if (isLegalName(newDirValue))
            {
                if (!(Directory.Exists(Path.Combine(CurrentDirectory.ToString(),newDirValue))))
                    {
                    model.CreateDirectory(Path.Combine(CurrentDirectory.ToString(), newDirValue));
                    OnRefreshListsClickedListner();
                    }
                else
                {
                    MessageBox.Show("This folder already exists!");
                }

            }
            else
                MessageBox.Show("Illegal folder name!");
        }

        private bool isLegalName(string name)
        {
            char[] invalid = Path.GetInvalidFileNameChars();

            for (int i = 0; i < name.Length; i++)
            {
                if (name.Contains(invalid[i].ToString()))
                {
                    return false;
                }

            }
            return true;
        }

        private void OnCopyFileClickedListner(SidePanel source)
        {
            SidePanel target = (source == view.SidePanelLeft) ? view.SidePanelRight : view.SidePanelLeft;
            if (source.SelectedItem != null)
            {
                var sourceFile = new FileInfo(Path.Combine(source.CurrentDirectory, source.SelectedItem.ToString()));

                var destinationFolder = new DirectoryInfo(target.CurrentDirectory);

                if (File.Exists(sourceFile.FullName))
                {
                    if (!File.Exists(Path.Combine(destinationFolder.FullName, sourceFile.Name)))
                    {
                        model.CopyFileToDirectory(sourceFile, destinationFolder);
                        OnRefreshListsClickedListner();
                    }
                    else
                    {
                        MessageBox.Show("This file already exists in the destination folder!", "Cannot Copy",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
                MessageBox.Show("No file selected", "Cannot Copy",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnCompareDirectoriesClickedListner()
        {
            string dir1 = Path.Combine(view.SidePanelLeft.CurrentDirectory, view.SidePanelLeft.SelectedItem.ToString());
            string dir2 = Path.Combine(view.SidePanelRight.CurrentDirectory, view.SidePanelRight.SelectedItem.ToString());
         

            if (view.SidePanelLeft.SelectedItem != null && view.SidePanelRight.SelectedItem != null
                && Directory.Exists(dir1) && Directory.Exists(dir2))

                if (model.AreDirectoriesEqual(new DirectoryInfo(dir1), new DirectoryInfo(dir2)))
                {
                    MessageBox.Show("Folders are equal!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Folders are NOT equal!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            else
            {
                MessageBox.Show("One or more selections isn't a folder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnRefreshListsClickedListner()
        {
            view.SidePanelLeft.RefreshList();
            view.SidePanelRight.RefreshList();
        }

        private void OnDeleteItemClickedListner(DirectoryInfo containingDirectory, string itemToRemove)
        {
            if (File.Exists(Path.Combine(containingDirectory.ToString(), itemToRemove)))
            {
                if (MessageBox.Show("Are You sure you want to delete the file " + itemToRemove + "?", "Confirm delete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    model.DeleteFile(containingDirectory, itemToRemove);
                    OnRefreshListsClickedListner();
                }
            }
            else if (Directory.Exists(Path.Combine(containingDirectory.ToString(), itemToRemove)))
            {
                if (
                    MessageBox.Show(
                        "Are You sure you want to delete the folder " + itemToRemove + " \nand all of its contents?",
                        "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    model.DeleteDirectory(containingDirectory, itemToRemove);
                    OnRefreshListsClickedListner();
                }
                
            }
        }
    }
}
