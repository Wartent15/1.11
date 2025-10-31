using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace _1._11
{
    partial class Form1 : Form
    {
        private TextBox txtName;
        private Label lblName;
        private Button btnClear;
        private CheckBox chkEnableName;
        private ComboBox cmbColors;
        private Label lblStatus;

        public Form1()
        {
            InitializeComponent();
            Component();
        }

        private void Component()
        {
            this.Text = "Базовый интерфейс";
            this.Size = new Size(420, 280);
            this.StartPosition = FormStartPosition.CenterScreen;

            lblName = new Label
            {
                Text = "Имя:",
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblName);

            txtName = new TextBox
            {
                Location = new Point(80, 16),
                Width = 260
            };
            this.Controls.Add(txtName);

            chkEnableName = new CheckBox
            {
                Text = "Разрешить редактирование имени",
                Location = new Point(20, 50),
                AutoSize = true,
                Checked = true
            };
            chkEnableName.CheckedChanged += ChkEnableName_CheckedChanged;
            this.Controls.Add(chkEnableName);

            cmbColors = new ComboBox
            {
                Location = new Point(20, 82),
                Width = 320,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbColors.Items.AddRange(new string[] { "Синий", "Красный", "Зелёный", "Чёрный" });
            cmbColors.SelectedIndex = 0;
            cmbColors.SelectedIndexChanged += CmbColors_SelectedIndexChanged;
            this.Controls.Add(cmbColors);

            btnClear = new Button
            {
                Text = "Сбросить",
                Location = new Point(20, 120),
                Width = 100
            };
            btnClear.Click += BtnClear_Click;
            this.Controls.Add(btnClear);

            lblStatus = new Label
            {
                Text = "Готово",
                Location = new Point(140, 125),
                AutoSize = true
            };
            this.Controls.Add(lblStatus);
        }

        private void ChkEnableName_CheckedChanged(object sender, EventArgs e)
        {
            txtName.Enabled = chkEnableName.Checked;
        }

        private void CmbColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            string color = cmbColors.SelectedItem.ToString();
            lblStatus.Text = $"Выбран цвет: {color}";
            // Пример визуального изменения фона в зависимости от цвета
            switch (color)
            {
                case "Синий": this.BackColor = Color.LightBlue; break;
                case "Красный": this.BackColor = Color.LightCoral; break;
                case "Зелёный": this.BackColor = Color.LightGreen; break;
                case "Чёрный": this.BackColor = Color.Gray; break;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            chkEnableName.Checked = true;
            cmbColors.SelectedIndex = 0;
            lblStatus.Text = "Сброшено";
        }
    }
}