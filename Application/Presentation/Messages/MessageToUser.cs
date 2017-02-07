using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Application.Presentation.Messages
{

    public class MessageToUser
    {
        /// <summary>
        /// Catégoies des messages
        /// </summary>
        public enum Category {
            MultiLanguageResourceFile,
            BusinessRule,
            Convert,
            ForeignKeViolation,
            EntityValidation
        } 
       

        static MessageToUser()
        {
            

        }

        public static void AddMessage(Category category, string msg)
        {
         
                
            switch (category)
            {
                case Category.MultiLanguageResourceFile:
                    MessageBox.Show(msg, MessageToUser_Resource.MultiLanguageResourceFile_Title);
                    break;
                case Category.BusinessRule:
                        MessageBox.Show(msg, MessageToUser_Resource.BusinessRule_Title);
                        break;
                case Category.Convert:
                        MessageBox.Show(msg, MessageToUser_Resource.Convert_Title);
                        break;
                case Category.ForeignKeViolation:
                    if (msg == string.Empty) msg = MessageToUser_Resource.ForeignKeViolation_Message;
                    MessageBox.Show(msg, MessageToUser_Resource.ForeignKeViolation_Title);
                        break;
                case Category.EntityValidation:
                    if (msg == string.Empty) msg = MessageToUser_Resource.EntityValidation_Message;
                    MessageBox.Show(msg, MessageToUser_Resource.EntityValidation_Title);
                    break;
                default:
                    break;
            }

            
        }

    }
}
