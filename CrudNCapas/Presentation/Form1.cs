using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using Common.Atributos;
using Domain.Crud;

namespace Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                
        }
        //variables
        CPersonas personas = new CPersonas();
        AttributesPeople Attributes = new AttributesPeople();
        Boolean edit = false;
        private void getData()
        {
            CPersonas cPersonas= new CPersonas();
            DvgDatos.DataSource = cPersonas.Mostrar();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cbSexo.SelectedIndex = 0;
            btnGuardar.Enabled = false;
            getData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            if (DvgDatos.SelectedRows.Count > 0)
            {
                txtID.Enabled = false;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                edit = true;
                //LLamar Datos
                txtID.Text = DvgDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = DvgDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = DvgDatos.CurrentRow.Cells[2].Value.ToString();
                cbSexo.Text = DvgDatos.CurrentRow.Cells[3].Value.ToString();

            }

        }   

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (DvgDatos.SelectedRows.Count > 0)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show(" Desea Eliminar este REgistro", "ELIMINAR ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        Attributes.Id = Convert.ToInt32(DvgDatos.CurrentRow.Cells[0].Value.ToString());
                        personas.Eliminar(Attributes);
                        getData();
                    }catch (Exception ex)
                    {
                        MessageBox.Show("ERROR SE INGRESO UN DATO ERRONEO");
                    }
                }
            }
        }
        private void ClearTextBoxs()
        {
            txtID.Text = " ID";
            txtApellido.Text = "Apellido";
            txtNombre.Text = " Nombre";
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled= false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    Attributes.Id = Convert.ToInt32(txtID.Text);
                    Attributes.Name = txtNombre.Text;
                    Attributes.Apellido = txtApellido.Text;
                    Attributes.Sexo = cbSexo.Text;
                    personas.Insertar(Attributes);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    MessageBox.Show("Se Guardo un Dato de Forma Exitosa", " Insertado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ) 
                {
                    MessageBox.Show("ERROR SE INGRESO UN DATO ERRONEO");
                }
            } else if (edit == true)
            {
                //Update
                try
                {
                    Attributes.Id = Convert.ToInt32(txtID.Text);
                    Attributes.Name = txtNombre.Text;
                    Attributes.Apellido = txtApellido.Text;
                    Attributes.Sexo = cbSexo.Text;
                    personas.Modificar(Attributes);
                    ClearTextBoxs();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    txtID.Enabled = true;
                    edit = false;
                    MessageBox.Show("Se Guardo un Dato de Forma Exitosa", " Modificado Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("ERROR SE INGRESO UN DATO ERRONEO");
                }
            }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar") txtBuscar.Text = "";
          
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {

            if (txtBuscar.Text == "") 
            {
                txtBuscar.Text = "Buscar";
                getData();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CPersonas Cpersonas = new CPersonas();
            DvgDatos.DataSource = Cpersonas.Buscar(txtBuscar.Text);
        }
    }
}
