using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Form1 : Form
    {
        private DataProvider dataPprovider= new DataProvider();
        private string stLoaiSach;
        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void init()
        {
            initSach();
        }
        private void initSach()
        {
            loadDgSach();
            loadcbSachLoaiSach();
        }
        private void loadDgSach()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT ma_sach as [Mã sách],ten_sach as [Tên Sách],tbl_sach.ma_loai_sach as [Mã loại sách],tac_gia as [Tác giả],so_luong as [Số lượng],gia_ban as [Giá Bán] FROM c#.dbo.tbl_sach,c#.dbo.tbl_loai_sach WHERE tbl_sach.ma_loai_sach = tbl_loai_sach.ma_loai_sach;");
            dt= dataPprovider.exeQuery(query.ToString());
            dgSach.DataSource= dt;
        }
        private void loadcbSachLoaiSach()
        {
            DataTable dataTable = new DataTable();
            dataTable = dataPprovider.exeQuery("SELECT * FROM c#.dbo.tbl_loai_sach");
            cbSachLoaiSach.DisplayMember = "ten_loai_sach";
            cbSachLoaiSach.ValueMember= "ma_loai_sach";
            cbSachLoaiSach.DataSource= dataTable;
        }

        private void dgSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId=  e.RowIndex;
            if (rowId < 0)
            {
                rowId = 0;
            }
            if(rowId == dgSach.RowCount-1) {
                rowId= rowId-1;
            }
            
            DataGridViewRow row= dgSach.Rows[rowId];
            txtSachTenSach.Text = row.Cells[1].Value.ToString();
            txtSachTacGia.Text = row.Cells[3].Value.ToString();
            cbSachLoaiSach.Text= row.Cells[2].Value.ToString();
            numSachSoLuong.Value = (int)row.Cells[4].Value;
            numSachGiaBan.Value = Convert.ToInt32(row.Cells[5].Value);

        }

        private void btnSachThem_Click(object sender, EventArgs e)
        {
            StringBuilder query= new StringBuilder("INSERT INTO c#.dbo.tbl_sach values(ten_sach,ma_loai_sach,tac_gia,so_luong,gia_ban) ");
        }

        private void btnSachSua_Click(object sender, EventArgs e)
        {

        }

        private void btnSachXoa_Click(object sender, EventArgs e)
        {

        }

        private void cbSachLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            stLoaiSach= comboBox.SelectedValue.ToString();
        }
    }
}
