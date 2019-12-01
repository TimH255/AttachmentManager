using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OutlookAddIn1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool blnFlag = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialise fields on loading form
            dtpIncident.MaxDate = DateTime.Today;
            dtpIncident.Value = DateTime.Today;
            radIncident.Checked = true;
            txtIncident.Text = "0000";
            txtCrime.Text = "000000/00";
            txtCrime.Enabled = false;
            lblFolder.Text = "";
            btnSave.Enabled = false;
            txtRoot.Text = Properties.Settings.Default.defaultfolder;
            btnUpdateRoot.Text = "Browse";
            btnUpdateRoot.Visible = false;
        }

        private void refType(object sender, EventArgs e)
        {
            //enable/disable input fields depending on selection
            txtIncident.Enabled = !radCrime.Checked;
            dtpIncident.Enabled = !radCrime.Checked;
            txtCrime.Enabled = !radIncident.Checked;

            //set focus to relevant textbox
            if (txtIncident.Enabled)
            {
                txtIncident.Focus();
            }
            else
            {
                txtCrime.Focus();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.strFolderName = "";
            this.Close();
        }

        private void resetFields(object sender, EventArgs e)
        {
            txtIncident.Text = "0000";
            dtpIncident.Value = DateTime.Today;
            txtCrime.Text = "000000/00";
            lblFolder.Text = "";
            btnSave.Enabled = false;
        }

        private void validateCrimeNumber(object sender, EventArgs e)
        {
            //don't validate if txtCrime is disabled
            if (!txtCrime.Enabled)
            {
                return;
            }

            //check a crime number has been entered
            if (txtCrime.Text == ""||txtCrime.Text=="000000/00")
            {
                MessageBox.Show("No crime number entered!", "Invalid crime number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                txtCrime.Focus();
                return;
            }

            //check format of crime number is valid
            //i.e. 123456/19
            Regex rx = new Regex(@"\d*[/]\d{2}$");

            if (!rx.IsMatch(txtCrime.Text))
            {
                MessageBox.Show("Crime number format must be 000000/00","Invalid crime number!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnSave.Enabled = false;
                txtCrime.Focus();
                return;
            }

            //check section before the / is not zero
            string tempString = txtCrime.Text.Remove(txtCrime.Text.Length - 3);

            if (tempString==""||tempString=="0")
            {
                MessageBox.Show("Crime number cannot be zero", "Invalid crime number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                txtCrime.Focus();
                return;
            }

            //check crime reference year is valid
            //i.e. cannot be greater than current year
            int currentYear = DateTime.Today.Year % 100;

            int enteredYear = int.Parse(txtCrime.Text.Substring(txtCrime.Text.Length - 2));

            if (enteredYear > currentYear)
            {
                MessageBox.Show("Year cannot be in the future!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                txtCrime.Focus();
                return;
            }

            //add leading zeroes, if necessary
            string strCrimeNumber = txtCrime.Text;
            switch (tempString.Length)
            {
                case 1:
                    strCrimeNumber = string.Concat("00000" + strCrimeNumber);
                    break;
                case 2:
                    strCrimeNumber = string.Concat("0000" + strCrimeNumber);
                    break;
                case 3:
                    strCrimeNumber = string.Concat("000" + strCrimeNumber);
                    break;
                case 4:
                    strCrimeNumber = string.Concat("00" + strCrimeNumber);
                    break;
                case 5:
                    strCrimeNumber = string.Concat("0" + strCrimeNumber);
                    break;
                default:
                    break;
            }

            //if validated correctly, generate folder name
            //Globals.ThisAddIn.strFolderName = string.Concat("CR" + txtCrime.Text.Replace("/",""));
            Globals.ThisAddIn.strFolderName = string.Concat("CR" + strCrimeNumber.Replace("/", ""));
            lblFolder.Text = Globals.ThisAddIn.strFolderName;
            btnSave.Enabled = true;

        }

        private void validateIncidentNumber(object sender, EventArgs e)
        {
            //don't validate if txtIncident is disabled
            if (!txtIncident.Enabled)
            {
                return;
            }

            //validate the data entered and create the folder name 
            if (txtIncident.Text == "0000"||txtIncident.Text=="")
            {
                MessageBox.Show("No incident number entered!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                txtIncident.Focus();
                return;
            }

            //check it's a number & greater than zero
            Regex rx = new Regex(@"\d{1,4}$");
            bool blnIsInt = true;

            if (!rx.IsMatch(txtIncident.Text))
            {
                blnIsInt = false;
            }
            else
            {
                if(int.Parse(txtIncident.Text)<1)
                {
                    blnIsInt = false;
                }
            }

            if (!blnIsInt)
            {
                MessageBox.Show("Must be a number between 1-9999", "Invalid incident number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                txtIncident.Clear();
                txtIncident.Focus();
                return;
            }

            //add leading zeroes if necessary
            //add leading zeroes, if necessary
            string strIncidentNumber = txtIncident.Text;
            switch (strIncidentNumber.Length)
            {
                case 1:
                    strIncidentNumber = string.Concat("000" + strIncidentNumber);
                    break;
                case 2:
                    strIncidentNumber = string.Concat("00" + strIncidentNumber);
                    break;
                case 3:
                    strIncidentNumber = string.Concat("0" + strIncidentNumber);
                    break;
                default:
                    break;
            }
            
            //if validated correctly, generate folder name
            string strYear = dtpIncident.Value.Year.ToString();

            string strMonth = dtpIncident.Value.Month.ToString();
            if (strMonth.Length==1)
            {
                strMonth = "0" + strMonth;
            }

            string strDay = dtpIncident.Value.Day.ToString();
            if (strDay.Length==1)
            {
                strDay = "0" + strDay;
            }

            //Globals.ThisAddIn.strFolderName = string.Concat("GC-" + strYear + strMonth + strDay + "-" + txtIncident.Text);
            Globals.ThisAddIn.strFolderName = string.Concat("GC-" + strYear + strMonth + strDay + "-" + strIncidentNumber);
            lblFolder.Text = Globals.ThisAddIn.strFolderName;
            btnSave.Enabled = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //on first run, defaultFolder will be blank and needs to be set
            if (blnFlag==false)
            {
                if (Properties.Settings.Default.defaultfolder=="")
                {
                    MessageBox.Show("Select default root folder", "Set folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRoot.Enabled = true;
                    btnUpdateRoot.PerformClick();                
                }
            }
            
            //set focus to incident number text box when form first appears
            //does not work correctly if put in the From1_Load event handler
            radIncident.Focus();
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            //allows user to change the root folder where documents are saved

            //check whether button is in Browse or Update mode
            if (btnUpdateRoot.Text=="Browse")
            {
                //browse for new folder
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                txtRoot.Text = folderBrowserDialog1.SelectedPath;

                    //if this is the first run through to set the default folder
                    //need to set this before continuing
                    if (blnFlag==false)
                    {
                        //apply changes and disable text box
                        Properties.Settings.Default.defaultfolder = txtRoot.Text;
                        btnUpdateRoot.Visible = false;
                        btnUpdateRoot.Text = "Browse";
                        txtRoot.Enabled = false;
                        chkChangeRoot.Checked = false;
                        blnFlag = true;
                    }
                    else
                    {
                        btnUpdateRoot.Text = "Update";
                        btnSave.Enabled = false;
                    }

                }
            }
            else
            {
                //check valid folder
                //not strictly necessary if selected through folderbrowserdialog
                //but user may have made manual changes
                if (!System.IO.Directory.Exists(txtRoot.Text))
                {
                    MessageBox.Show("Invalid folder name", "Invalid folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnUpdateRoot.Text = "Browse";
                    return;
                }

                //apply changes and disable text box
                Properties.Settings.Default.defaultfolder = txtRoot.Text;
                btnSave.Enabled = true;
                btnUpdateRoot.Visible = false;
                btnUpdateRoot.Text = "Browse";
                txtRoot.Enabled = false;
                chkChangeRoot.Checked = false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //pass folder name back to main function
            Globals.ThisAddIn.strFolderName = string.Concat(Properties.Settings.Default.defaultfolder + "\\" + Globals.ThisAddIn.strFolderName);
            this.Close();
        }

        private void chkChangeRoot_CheckedChanged(object sender, EventArgs e)
        {
            txtRoot.Enabled = chkChangeRoot.Checked;
            btnUpdateRoot.Visible = chkChangeRoot.Checked;
        }

        private void txtRoot_TextChanged(object sender, EventArgs e)
        {
            //if text in this box is changed manually
            //need to show Update button and disable Save button
            btnSave.Enabled = false;
            btnUpdateRoot.Text = "Update";
            btnUpdateRoot.Visible = true;
        }

        private void txtIncident_KeyPress(object sender, KeyPressEventArgs e)
        {
            //prevent entry of non-numeric characters
            if (char.IsLetter(e.KeyChar) ||
            char.IsSymbol(e.KeyChar) ||
            char.IsWhiteSpace(e.KeyChar) ||
            char.IsPunctuation(e.KeyChar))
            e.Handled = true;
        }

        private void txtCrime_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //prevent entry of non-numeric characters but allow /

            if (e.KeyChar == 47)
            {
                return;
            }

            if (char.IsLetter(e.KeyChar) ||
            char.IsSymbol(e.KeyChar) ||
            char.IsWhiteSpace(e.KeyChar) ||
            char.IsPunctuation(e.KeyChar))
            e.Handled = true;
        }

        private void inputTextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
    }
}
