using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinFrom.Validation
{
    public class MessageValidation
    {
        public ErrorProvider errorProvider;
        public MessageValidation(ErrorProvider errorProvider)
        {
            this.errorProvider = errorProvider;
        }
        public void TextBoxString(object sender, CancelEventArgs e, String message = "")
        {

            TextBox controle = (TextBox)sender;
            if (message == "") message = "La saisie de ce champs est oblégatoir";
            if (controle.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(controle, message);
                e.Cancel = true;
            }
            else
                errorProvider.SetError(controle, "");
        }
        public void TextBoxInt32(object sender, CancelEventArgs e, String message = "")
        {

            TextBox controle = (TextBox)sender;
            if (message == "") message = "La saisie de ce champs est oblégatoir";
            if (controle.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(controle, message);
                e.Cancel = true;
            }
            else
                errorProvider.SetError(controle, "");
        }

        public void DateTimePicker(object sender, CancelEventArgs e, String message = "")
        {
            DateTimePicker controle = (DateTimePicker)sender;
            if (message == "") message = "La saisie de ce champs est oblégatoir";

            // à vérifer avec les second
            if (controle.Value == DateTime.Now)
            {
                errorProvider.SetError(controle, message);
                e.Cancel = true;
            }
            else
                errorProvider.SetError(controle, "");
        }
    }
}
