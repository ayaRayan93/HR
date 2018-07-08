using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraGrid;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraNavBar;

namespace HR
{
    public partial class HRMainForm : DevExpress.XtraEditors.XtraForm
    {
        XtraTabPage HR_TP;
        bool flag = false;

        public HRMainForm()
        {
            try
            {
                InitializeComponent();
                HR_TP = xtraTabPageHR;
                xtraTabControlMainContainer.TabPages.Remove(xtraTabPageHR);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnHR_ItemClick(object sender, TileItemEventArgs e)
        {
            try
            {
                if (flag == false)
                {
                    xtraTabControlMainContainer.TabPages.Insert(1, HR_TP);
                    flag = true;
                }
                xtraTabControlMainContainer.SelectedTabPage = xtraTabControlMainContainer.TabPages[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //employees
        private void navBarItem2_ItemClicked(object sender, EventArgs e)
        {
            try
            {
                restForeColorOfNavBarItem();
                NavBarItem navBarItem = (NavBarItem)sender;
                navBarItem.Appearance.ForeColor = Color.Blue;

                if (!xtraTabControlHRContent.Visible)
                    xtraTabControlHRContent.Visible = true;

                XtraTabPage xtraTabPage = getTabPage("بيان الموظفين");
                if (xtraTabPage == null)
                {
                    xtraTabControlHRContent.TabPages.Add("بيان الموظفين");
                    xtraTabPage = getTabPage("بيان الموظفين");
                }
                xtraTabPage.Controls.Clear();

                xtraTabControlHRContent.SelectedTabPage = xtraTabPage;
                bindDisplayEmployeesForm(xtraTabPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        //Employee
        public void bindDisplayEmployeesForm(XtraTabPage xtraTabPage)
        {
            Employees objForm = new Employees(this);
            objForm.TopLevel = false;

            xtraTabPage.Controls.Add(objForm);
            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
        public void bindRecordEmployeesForm()
        {
            EmployeeRecord objForm = new EmployeeRecord();

            objForm.TopLevel = false;
            XtraTabPage xtraTabPage = getTabPage("أضافة موظف");
            if (xtraTabPage == null)
            {
                xtraTabControlHRContent.TabPages.Add("أضافة موظف");
                xtraTabPage = getTabPage("أضافة موظف");

            }
            xtraTabPage.Controls.Clear();
            xtraTabPage.Controls.Add(objForm);
            xtraTabControlHRContent.SelectedTabPage = xtraTabPage;

            objForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }

        private void xtraTabControlStoresContent_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
                XtraTabPage xtraTabPage = (XtraTabPage)arg.Page;
                if (xtraTabPage.ImageOptions.Image != null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to Close this page without save?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {

                        xtraTabControlHRContent.TabPages.Remove(arg.Page as XtraTabPage);
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                else
                {
                    xtraTabControlHRContent.TabPages.Remove(arg.Page as XtraTabPage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xtraTabControlMainContainer_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
                XtraTabPage xtraTabPage = (XtraTabPage)arg.Page;
                if (!IsTabPageSave())
                {
                    DialogResult dialogResult = MessageBox.Show("There are unsave Pages To you wound close anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        xtraTabControlMainContainer.TabPages.Remove(arg.Page as XtraTabPage);
                        flag = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                else
                {
                    xtraTabControlMainContainer.TabPages.Remove(arg.Page as XtraTabPage);
                    flag = false;
                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
     
        private void SalesMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsTabPageSave())
            {
                DialogResult dialogResult = MessageBox.Show("There are unsave Pages To you wound close anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = (dialogResult == DialogResult.No);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

    

        //functions
        public XtraTabPage getTabPage(string text)
        {
            for (int i = 0; i < xtraTabControlHRContent.TabPages.Count; i++)
                if (xtraTabControlHRContent.TabPages[i].Text == text)
                {
                    return xtraTabControlHRContent.TabPages[i];
                }
            return null;
        }

        public bool IsTabPageSave()
        {
            for (int i = 0; i < xtraTabControlHRContent.TabPages.Count; i++)
                if (xtraTabControlHRContent.TabPages[i].ImageOptions.Image!=null)
                {
                    return false;
                }
            return true;
        }

        public void restForeColorOfNavBarItem()
        {
            foreach (NavBarItem item in navBarControl1.Items)
            {
                item.Appearance.ForeColor = Color.Black;
            }
        }

       
    }

    public static class connection
    {
      // public static string connectionString = "SERVER=192.168.1.200;DATABASE=test;user=Devccc;PASSWORD=rootroot;CHARSET=utf8";
         public static string connectionString = "SERVER=localhost;DATABASE=ccc;user=root;PASSWORD=root;CHARSET=utf8";
    }
}