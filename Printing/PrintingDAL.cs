﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;
using System.Reflection;

namespace Printing
{
    public static class DataTableExtensions
    {
        public static List<T> ToList<T>(this DataTable table) where T : new()
        {
            List<T> list = new List<T>();

            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();

                foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (table.Columns.Contains(prop.Name) && !row.IsNull(prop.Name))
                    {
                        try
                        {
                            var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                            var value = row[prop.Name];

                            // If the property is a string, we just assign the value directly as string
                            if (propertyType == typeof(string))
                            {
                                prop.SetValue(obj, value.ToString());
                            }
                            else
                            {
                                var safeValue = Convert.ChangeType(value, propertyType);
                                prop.SetValue(obj, safeValue);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle or log the error as needed
                            Console.WriteLine($"Error converting property {prop.Name}: {ex.Message}");
                        }
                    }
                }
                list.Add(obj);
            }

            return list;
        }
    }

    public class TrxLabelTag
    {
        public string tenant_id { get; set; }
        public string cmp_cd { get; set; }
        public string plnt_cd { get; set; }
        public string req_time { get; set; }
        public string req_ip { get; set; }
        public string page_no { get; set; }
        public string item_cd { get; set; }
        public string item_nm { get; set; }
        public string vendor_cd { get; set; }
        public string mamm_lot_no { get; set; }
        public string vendor_lot_no { get; set; }
        public string qty { get; set; }
        public string plnt_cd_s { get; set; }
        public string str_location { get; set; }
        public string uom { get; set; }
        public string print_date { get; set; }
        public string qr_cd { get; set; }
        public string label_num { get; set; }
        public string from_qty { get; set; }
        public string from_uom { get; set; }
        public string print_uom { get; set; }
        public string req_user_id { get; set; }
        public string proc_status { get; set; }
        public string cncl_flg { get; set; }
        public string proc_cls { get; set; }
        public string reg_utc { get; set; }
        public string reg_cmp_cd { get; set; }
        public string regr_id { get; set; }
        public string reg_pg_id { get; set; }
        public string upd_utc { get; set; }
        public string upd_cmp_cd { get; set; }
        public string updr_id { get; set; }
        public string upd_pg_id { get; set; }
        public string admin_mnt_notes { get; set; }
    }

    public class PrintingDAL
    {
        string connectionString = null;

        public PrintingDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MESLotTraceConnectionString"].ConnectionString;
        }


        public List<TrxLabelTag> GetLabels()
        {
            string sqlstr = @"SELECT * from TRX_LABEL_TAG Where proc_status = 0";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand(sqlstr, myConnection))
                {
                    // cmd.Parameters.AddWithValue("@equip_id", EID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt.ToList<TrxLabelTag>();

                    }

                }
            }
        }

        public List<TrxLabelTag> UpdateLabel(string code)
        {
            string sqlstr = @"Update TRX_LABEL_TAG Set proc_status = 1  Where vendor_cd = '" + code + "'";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand(sqlstr, myConnection))
                {
                    // cmd.Parameters.AddWithValue("@equip_id", EID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt.ToList<TrxLabelTag>();

                    }

                }
            }
        }


        public List<TrxLabelTag> GetLabels(string code)
        {
            string sqlstr = @"SELECT * from TRX_LABEL_TAG where proc_status = 0 AND vendor_cd = '" + code + "'";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                using (SqlCommand cmd = new SqlCommand(sqlstr, myConnection))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt.ToList<TrxLabelTag>();

                    }

                }
            }
        }


    }
}
