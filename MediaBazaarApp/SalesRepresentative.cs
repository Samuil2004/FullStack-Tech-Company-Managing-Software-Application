using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using LogicLayer;

namespace MediaBazaarApp
{
	public partial class SalesRepresentative : Form
	{
		Person loggedinUser;
		SQLDatabase db;
		Product SelectedProduct;
		ProductManager productManager;
		bool close_application;
		public SalesRepresentative(Person person)
		{
			try
			{
				InitializeComponent();
				db = new SQLDatabase();
				productManager = new ProductManager();
				this.loggedinUser = person;
				close_application = true;
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		private void RequestNewDepoStockButton_Click(object sender, EventArgs e)
		{
			try
			{
				SendStockRequest();
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		private void tbxProductCode_TextChanged(object sender, EventArgs e)
		{
			try
			{
				SelectedProduct = db.FindProductByBarcode(tbxProductCode.Text);
				if (SelectedProduct != null)
				{
					lblSelectedProduct.Text = "Selected product: " + SelectedProduct.Name;
					lblCurrentQuantity.Text = "Current quantity: " + SelectedProduct.QuantityinStock;
				}
				else
				{
					lblSelectedProduct.Text = "Selected product:";
					lblCurrentQuantity.Text = "Current quantity:";
				}
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		private void pbPrevPage_Click(object sender, EventArgs e)
		{
			close_application = false;
			this.Close();
		}

		private void AnyForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (close_application)
			{
				Application.Exit();
			}
			else
			{
				return;
			}
		}

		private void tbxProductCode_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					nudQuantity.Select();
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
        }

		private void nudQuantity_KeyDown(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyCode == Keys.Enter)
				{
					SendStockRequest();
				}
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

		private void SendStockRequest()
		{
			try
			{
				int quantity = Convert.ToInt32(nudQuantity.Value);
				DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
				if (quantity != 0)
				{
					if (db.CheckRequestAlreadyExists(SelectedProduct.getId(), "Sales representative") == false)
					{
						db.CreateNewRestockRequest(SelectedProduct.getId(), SelectedProduct.Name, quantity, currentDate, "Sales representative");
						MessageBox.Show("Request sent");
					}
					else
					{
						MessageBox.Show("A restock request for this product was already sent");
					}
				}
				else { MessageBox.Show("Quantity selected must be greater than zero"); }
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
	}
}
