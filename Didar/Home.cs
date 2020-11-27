using Didar.Models;
using Didar.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Didar
{
    public partial class Home : Form
    {
        private readonly IUserService userService;

        public Home(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {  
            if (IsValid())
            {
                var result = userService.AddUser(CheckData()); 
                MessageBox.Show(this,result.Message, result.IsSuccess ? "Information" : "Error", MessageBoxButtons.OK, result.IsSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                if (result.IsSuccess) setData(result.Data);
            } 
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        { 
        }


        #region Methods
        User CheckData()
        {
            User user = new User()
            {
                Contact = new Contact
                {
                    Id = tb_Id.Text == "" ? null : tb_Id.Text,
                    CustomerCode = tb_CustomerCode.Text == "" ? null : tb_CustomerCode.Text,
                    FirstName = tb_FirstName.Text == "" ? null : tb_FirstName.Text,
                    LastName = tb_LastName.Text == "" ? null : tb_LastName.Text,
                    OwnerId = tb_OwnerId.Text == "" ? null : tb_OwnerId.Text,
                    MobilePhone = tb_MobilePhone.Text == "" ? null : tb_MobilePhone.Text,
                    WorkPhone = tb_WorkPhone.Text == "" ? null : tb_WorkPhone.Text,
                    Email = tb_Email.Text == "" ? null : tb_Email.Text,
                    CompanyId = tb_CompanyId.Text == "" ? null : tb_CompanyId.Text,
                    CompanyName = tb_CompanyName.Text == "" ? null : tb_CompanyName.Text,
                }
            };
            if (tb_SegmentIds.Text == "")
                user.Contact.SegmentIds = null;
            else
                user.Contact.SegmentIds.Add(tb_SegmentIds.Text);
            return user;
        }
        void setData(Response response)
        {
            try
            {
                tb_Id.Text = response.Id;
                tb_CustomerCode.Text = response.CustomerCode;
                tb_FirstName.Text = response.FirstName;
                tb_LastName.Text = response.LastName;
                tb_OwnerId.Text = response.OwnerId;
                tb_MobilePhone.Text = response.MobilePhone;
                tb_WorkPhone.Text = response.WorkPhone;
                tb_Email.Text = response.Email;
                tb_CompanyId.Text = response.CompanyId;
                tb_CompanyName.Text = response.CompanyName;
                tb_SegmentIds.Text = response.Segments.Count > 0 ? response.Segments[0].ToString() : "";
            }
            catch (Exception)
            {

                throw;
            }


        }
        bool IsConnectedToDidar()
        { 
            Uri url = new Uri("https://didar.me/");
            string pingurl = string.Format("{0}", url.Host);
            string host = pingurl;
            bool result = false;
            Ping p = new Ping();
            try
            {
                PingReply reply = p.Send(host, 3000);
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch { } 
            return result;
        }

        public bool ValidateEmailId(string emailId)
        {
            Regex rEMail = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!rEMail.IsMatch(emailId))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool ValidateMobileNumber(string Number)
        {
            Regex MobileNumber = new Regex(@"^[0][9]\d{9}$");
            if (!MobileNumber.IsMatch(Number) || Number.Length<11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        bool IsValid()
        {
            string message = "";
            if (!IsConnectedToDidar())
            {
                message = "ارتباط با دیدار برقرار نمی باشد"; 
            }
            else if (tb_LastName.Text == "")
            {
                message = "نام خانوادگی وارد نشده"; 
            }
            else if (tb_Email.Text.Length > 0 && (!ValidateEmailId(tb_Email.Text)))
            {
                message = "ایمیل وارد شده صحیح نمی باشد";
            }
            else if (tb_MobilePhone.Text.Length > 0 && (!ValidateMobileNumber(tb_MobilePhone.Text)))
            {
                message = "شماره همراه وارد شده صحیح نمی باشد";
            }
            if (message!="")
            {    
                MessageBox.Show(this, message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                return false;
            }
            return true;
        }


        #endregion

        private void btn_NewUser_Click(object sender, EventArgs e)
        {
            tb_Id.Text = "";
            tb_CustomerCode.Text = "";
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_OwnerId.Text = "";
            tb_MobilePhone.Text = "";
            tb_WorkPhone.Text = "";
            tb_Email.Text = "";
            tb_CompanyId.Text = "";
            tb_CompanyName.Text = "";
            tb_SegmentIds.Text = "";

        }


    }
}
