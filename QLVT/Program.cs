using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using QLVT.View;
using QLVT.model;
using System.Data;
using QLVT.model.trac_nghiem;

namespace QLVT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static CoSo CO_SO;
        public static User USER = new User();
        public static DataTable DanhSachCoSo;
        public static String MaCoSo;
        public static String SV_NAME;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            Application.Run(new frmLogin()); 
        }
    }
}