using System;
using System.Windows.Forms;

namespace MscrmTools.EnvironmentVariableManager.Forms
{
    public partial class SecretForm : Form
    {
        public SecretForm()
        {
            InitializeComponent();
        }

        public SecretForm(string secretPath) : this()
        {
            var parts = secretPath.Split('/');
            if (parts.Length == 11)
            {
                txtSubscriptionId.Text = parts[2];
                txtResourceGroupName.Text = parts[4];
                txtKeyVaultName.Text = parts[8];
                txtSecretName.Text = parts[10];
            }
        }

        public string SecretPath { get; internal set; }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (txtSubscriptionId.Text.Length == 0)
            {
                MessageBox.Show(this, "Please specify Azure Subscription Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtResourceGroupName.Text.Length == 0)
            {
                MessageBox.Show(this, "Please specify Azure Resource Group name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtKeyVaultName.Text.Length == 0)
            {
                MessageBox.Show(this, "Please specify Azure Key Vault name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSecretName.Text.Length == 0)
            {
                MessageBox.Show(this, "Please specify Secret name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SecretPath = $"/subscriptions/{txtSubscriptionId.Text}/resourceGroups/{txtResourceGroupName.Text}/providers/Microsoft.KeyVault/vaults/{txtKeyVaultName.Text}/secrets/{txtSecretName.Text}";
        }
    }
}