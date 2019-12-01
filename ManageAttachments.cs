using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.IO;

namespace OutlookAddIn1
{
    //created by Tim Hutchinson, November 2019
    public partial class ManageAttachments
    {
        private void ManageAttachments_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnSaveNew_Click(object sender, RibbonControlEventArgs e)
        {
            //open form for user to enter incident/crime details
            //sets up public variable strFolderName
            Form myForm = new Form1
            {
                Text = "Save Attachments"
            };
            myForm.ShowDialog();

            //if user cancels the process, stop execution
            if (Globals.ThisAddIn.strFolderName == "")
            {
                return;
            }

            //MessageBox.Show(Globals.ThisAddIn.strFolderName);

            //this is the bit that saves the attachments
            var m = e.Control.Context as Inspector;
            var mailItem = m.CurrentItem as MailItem;

            if (mailItem != null)
            {
                if (mailItem.Attachments.Count > 0)
                {
                    //check if folder exists and if it does, whether user wants to add to it or cancel
                    if (createFolder())
                    {
                        int intSaved = 0;
                        foreach (Attachment item in mailItem.Attachments)
                        {
                            //item.SaveAsFile... will overwrite without warning
                            //therefore need to check first whether the filename is already in use
                            string strFileName = Path.Combine(Globals.ThisAddIn.strFolderName, item.DisplayName).ToString();
                            bool blnSkip = false;
                            //if (File.Exists(Path.Combine(Globals.ThisAddIn.strFolderName,item.DisplayName)))
                            if (File.Exists(strFileName))
                            {
                                var dlgResult = new DialogResult();
                                dlgResult = MessageBox.Show(item.DisplayName + " already exists in this folder! \r\r Save anyway? " +
                                    "\r\r (filename will be modified - existing file will not be overwritten)",
                                    "File exists!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                                if (dlgResult==DialogResult.Yes)
                                {
                                    //add a pseudo unique ref to filename
                                    string strUID = DateTime.Now.ToString();
                                    strUID = strUID.Substring(11);
                                    strUID = strUID.Replace(":", "");
                                    strFileName = Path.Combine(Globals.ThisAddIn.strFolderName, strUID + "-" + item.DisplayName);
                                    blnSkip = false;
                                }
                                else
                                {
                                    //skip to next attachment
                                    blnSkip = true;
                                }
                            }
                            //item.SaveAsFile(Path.Combine(Globals.ThisAddIn.strFolderName, item.FileName));
                            if (!blnSkip)
                            {
                                try
                                {
                                item.SaveAsFile(strFileName);
                                }
                                catch (System.UnauthorizedAccessException)
                                {
                                    MessageBox.Show("You do not have permission to save to " + Properties.Settings.Default.defaultfolder + "\r\r Contact ICT for assistance.", "No write access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                intSaved += 1;
                            }
                        }

                        if (intSaved>0)
                        {
                            MessageBox.Show(intSaved + " attachment(s) saved to: " + Globals.ThisAddIn.strFolderName);

                            //save body of email too?
                            var dlgResult = new DialogResult();
                            dlgResult = MessageBox.Show("Save message body to same folder?", "Save message body?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dlgResult==DialogResult.Yes)
                            {
                                string strFilename = mailItem.Subject + ".html";
                                try
                                {
                                    mailItem.SaveAs(Path.Combine(Globals.ThisAddIn.strFolderName, strFilename), OlSaveAsType.olHTML);
                                }
                                catch (System.UnauthorizedAccessException)
                                {
                                    MessageBox.Show("You do not have permission to save to " + Properties.Settings.Default.defaultfolder + "\r\r Contact ICT for assistance.", "No write access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                MessageBox.Show("Email body saved.");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Nothing saved", "Process cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nothing saved","Process cancelled",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                }

                else
                {
                    var dlgResult = new DialogResult();
                    dlgResult = MessageBox.Show("This email doesn't have any attachments.\r\r Save message instead?","No attachments",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

                    //save message as HTML file (to include any embedded content)
                    if (dlgResult==DialogResult.Yes)
                    {
                        if (createFolder())
                        {
                            string strFilename = mailItem.Subject + ".html";

                            try
                            {
                                mailItem.SaveAs(Path.Combine(Globals.ThisAddIn.strFolderName, strFilename), OlSaveAsType.olHTML);
                            }
                            catch (System.UnauthorizedAccessException)
                            {
                                MessageBox.Show("You do not have permission to save to " + Properties.Settings.Default.defaultfolder + "\r\r Contact ICT for assistance.", "No write access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Nothing saved", "Process cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

        }

        private bool createFolder()
        {
            //check whether the folder exists & if it does
            //does user wish to add to it?
            if (System.IO.Directory.Exists(Globals.ThisAddIn.strFolderName))
            {
                var dlgResult = new DialogResult();
                dlgResult = MessageBox.Show("Folder already exists. \r\r Save to this folder?", "Save to existing folder?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //MessageBox.Show("Folder already exists. Save to this folder?", "Save to existing folder?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dlgResult==DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try //try catch block wrapped around folder create in case user does not have write permission to the root folder
                {
                    Directory.CreateDirectory(Globals.ThisAddIn.strFolderName);
                }
                catch (System.UnauthorizedAccessException)
                {
                    MessageBox.Show("You do not have permission to save to " + Properties.Settings.Default.defaultfolder + "\r\r Contact ICT for assistance.", "No write access", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }
    }
}
