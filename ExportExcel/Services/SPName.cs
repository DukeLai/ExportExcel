using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Services
{
    public class SPName
    {
        //Menu
        public readonly static string prc_sp_query_DailyReservation3 = "[dbo].[prc_sp_query_DailyReservation3]";      //查詢


        public readonly static string prc_sp_query_ReservationForAestheticMedicine = "[dbo].[prc_sp_query_ReservationForAestheticMedicine]";      //查詢


        //問卷登錄
        public readonly static string prc_sp_query_QuestionLogin = "[dbo].[prc_sp_query_QuestionLogin2]";      //查詢


        //掃描更新
        public readonly static string prc_sp_Update_PreCheck = "[dbo].[prc_sp_Update_PreCheck]";      //掃描更新

        //無紙化查詢
        public readonly static string prc_sp_query_Nopaper = "[dbo].[prc_sp_query_Nopaper]";      //查詢
        public readonly static string prc_sp_Update_Nopaper = "[dbo].[prc_sp_Update_Nopaper]";      //更新

        //會議室預約
        public readonly static string prc_sp_query_RoomBooking = "[dbo].[prc_sp_query_RoomBooking]";      //更新
        public readonly static string prc_sp_Update_RoomBooking = "[dbo].[prc_sp_Update_RoomBooking]";      //更新

        //可預約時段查詢
        public readonly static string prc_sp_query_WeeklyReservationSummation = "[dbo].[prc_sp_query_WeeklyReservationSummation]";      //查詢


        /// <summary>
        /// Medirep自動夾圖
        /// </summary>
        //
        public readonly static string prc_sp_query_custome = "[dbo].[prc_sp_query_custome]";      //查詢
        public readonly static string prc_sp_Update_queryCustome_pic = "[dbo].[prc_sp_Update_queryCustome_pic]";      //更新該人的圖片檔
        public readonly static string prc_sp_query_customeByID = "[dbo].[prc_sp_query_customeByID]";      //查詢該人的圖片string
        public readonly static string prc_sp_query_categories = "[dbo].[prc_sp_query_categories]";      //查詢檢驗項目代碼名稱
        public readonly static string prc_sp_query_gauge_data = "[dbo].[prc_sp_query_gauge_data]";      //查詢有做的檢驗項目



        //專案查詢與勞檢套表更新66
        public readonly static string prc_sp_query_CheckProject = "[dbo].[prc_sp_query_CheckProject]";      //查詢
        public readonly static string prc_sp_query_CheckProject_Live = "[dbo].[prc_sp_query_CheckProject_Live]";      //查詢
        public readonly static string prc_sp_Update_ProjectScheme66 = "[dbo].[prc_sp_Update_ProjectScheme66]";//更新


        //勞檢表基礎個人資料
        public readonly static string prc_sp_query_LabourChecklist = "[dbo].[prc_sp_query_LabourChecklist]";//查詢


        //CheckProjectScheme
        public readonly static string prc_sp_query_CheckProjectScheme = "[dbo].[prc_sp_query_CheckProjectScheme]";//查詢
        //CheckItem
        public readonly static string prc_sp_query_CheckItem = "[dbo].[prc_sp_query_CheckItem]";//查詢

        //PersonItem
        public readonly static string prc_sp_query_CheckProjectPersonItem = "[dbo].[prc_sp_query_CheckProjectPersonItem]";//查詢

        //NameList
        public readonly static string prc_sp_query_PersonCustomer = "[dbo].[prc_sp_query_PersonCustomer]";//查詢

        



    }
}