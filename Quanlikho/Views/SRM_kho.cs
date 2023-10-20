using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Collections;

namespace Quanlikho
{
    public partial class SRM_kho : Form
    {
        SqlConnection conn = new SqlConnection(@"Server=localhost;Database=QLK;User Id=caohao;Password=123456;");

        public SRM_kho()
        {
            InitializeComponent();

        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(text_makho.Text)) || (string.IsNullOrEmpty(text_tenkho.Text)) || (string.IsNullOrEmpty(text_diachi.Text)))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }   
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into tb_KHO values (N'"+text_makho.Text+"',N'"+text_tenkho.Text+"', N'"+text_diachi.Text+"') ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);

                text_makho.Clear();
                text_tenkho.Clear();
                text_diachi.Clear();
                text_makho.Focus();
                conn.Close();
                button_load_Click(sender, e);
                
            }
        }

        private void lst_xem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("Delete from dtb_KHO where MAKHO = '" + text_makho.Text + "' ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                text_makho.Clear();
                text_tenkho.Clear();
                text_diachi.Clear();
                text_makho.Focus();
            }
            conn.Close();
            button_load_Click(sender, e);
                
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (MessageBox.Show("Bạn có muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("update tb_KHO set TENKHO = N'" + text_tenkho.Text + "', DIACHI = N'" + text_diachi.Text + "' where MAKHO = '" + text_makho.Text + "' ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                text_makho.Clear();
                text_tenkho.Clear();
                text_diachi.Clear();
                text_makho.Focus();
            }
            conn.Close();
            button_load_Click(sender, e);
            

        }
       
        private void button_load_Click(object sender, EventArgs e)
        {
           lst_xem.Items.Clear();   
            try { 
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from tb_KHO", conn);
                SqlDataReader reader = cmd.ExecuteReader(); 
               while (reader.Read())
               {
                    ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                    lv.SubItems.Add(reader.GetString(1));
                    lv.SubItems.Add(reader.GetString(2));
                    lst_xem.Items.Add(lv);
                }
               conn.Close();
            } 
            catch ( Exception ) { MessageBox.Show("Lỗi kết nối"); }
            
        }

 

        private void lst_xem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            text_makho.Text = lst_xem.SelectedItems[0].SubItems[0].Text;
            text_tenkho.Text = lst_xem.SelectedItems[0].SubItems[1].Text;
            text_diachi.Text = lst_xem.SelectedItems[0].SubItems[2].Text;

        }

        private void button_timkiem_Click(object sender, EventArgs e)
        {
            lst_xem.Items.Clear();
            try
            {
                conn.Open();
                if (!(string.IsNullOrEmpty(text_makho.Text)))
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_KHO where MAKHO = '" + text_makho.Text + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lst_xem.Items.Add(lv);
                    }
                }
                else if (!(string.IsNullOrEmpty(text_tenkho.Text)))
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_KHO where TENKHO = '" + text_tenkho.Text + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lst_xem.Items.Add(lv);
                    }
                }
                else if (!(string.IsNullOrEmpty(text_tenkho.Text) && string.IsNullOrEmpty(text_makho.Text)))
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_KHO where TENKHO = '" + text_tenkho.Text + "',MAKHO = '" + text_makho.Text + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lst_xem.Items.Add(lv);
                    }
                }
                else if (!(string.IsNullOrEmpty(text_diachi.Text)))
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_KHO where DIACHI = '" + text_diachi.Text + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lst_xem.Items.Add(lv);
                    }
                }
                else if (!(string.IsNullOrEmpty(text_tenkho.Text) && string.IsNullOrEmpty(text_diachi.Text)))
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_KHO where TENKHO = '" + text_tenkho.Text + "',DIACHI = '" + text_diachi.Text + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lst_xem.Items.Add(lv);
                    }
                }
                else if (!(string.IsNullOrEmpty(text_diachi.Text) && string.IsNullOrEmpty(text_makho.Text)))
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_KHO where DIACHI = '" + text_diachi.Text + "',MAKHO = '" + text_makho.Text + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lst_xem.Items.Add(lv);
                    }
                }
                else if(!(string.IsNullOrEmpty(text_makho.Text) && string.IsNullOrEmpty(text_tenkho.Text) && string.IsNullOrEmpty(text_diachi.Text)))
                {
                    SqlCommand cmd = new SqlCommand("select * from tb_KHO where DIACHI = '" + text_diachi.Text + "',MAKHO = '" + text_makho.Text + "',TENKHO ='" + text_tenkho.Text + "'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lst_xem.Items.Add(lv);
                    }
                } 
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm"); 
                }
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txttim_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lst_xem.Items.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tb_KHO where DIACHI like N'%" + txttim.Text + "%' or MAKHO like N'%" + txttim.Text + "%' or TENKHO like N'%" + txttim.Text + "%'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                lv.SubItems.Add(reader.GetString(1));
                lv.SubItems.Add(reader.GetString(2));
                lst_xem.Items.Add(lv);
            }
            conn.Close();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            text_makho.Clear();
            text_tenkho.Clear();
            text_diachi.Clear();
        }
    }
}
