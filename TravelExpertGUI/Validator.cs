using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TravelExpertGUI
{
    public static class Validator
	{


        // check if its valid email
        public static bool IsValidEmail(TextBox tb, string name)
        {
            bool result = true;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(tb.Text);
            if (!match.Success)
            {
                MessageBox.Show(name + " accepts only Valid Email address");
                result = false;
                tb.Focus();
                tb.SelectAll();
                tb.Text.Remove(tb.Text.Length - 1);
            }
            return result;
        }



        // check if input in a text is nVarchar only
        public static bool IsNvarchar(TextBox tb, string name)
        {
            bool result = true;
            if (!System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show(name + " accepts only alphabetical characters");
                result = false;
                tb.Focus();
                tb.SelectAll();
                tb.Text.Remove(tb.Text.Length - 1);
            }
            return result;
        }



        public static bool checkPhoneNumberFormat(TextBox tb, string name)
        {
            bool result = true;
            if (tb.Text.Length < 10)
            {
                MessageBox.Show(name + " must be atleast 10 digits.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }
        public static string isPhoneNumber(string value, string name)
        {
            string msg = "";
            if (value.Length < 9)
            {
                msg += name + " must be atleast 9 digits" + LineEnd;
            }
            return msg;
        }

        public static string isDateTime(string value, string name)
        {
            string msg = "";
            DateTime temp;
            if (!DateTime.TryParse(value, out temp))
            {
                msg += name + " must be a valid datetime format" + LineEnd;
            }
            return msg;
        }


        public static string IsProvince(string value, string name)
        {
            string msg = "";
            if (value.Length != 2)
            {
                msg += name + " must be only two characters." + LineEnd;
            }
            return msg;
        }


        // checks if text box is not empty
        public static bool IsEmpty(TextBox tb, string name)
        {
            bool result = true;
            if (tb.Text == "")
            {
                MessageBox.Show(name + " has to be provided",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
                tb.Focus();
            }
            return result;
        }

        // checks if comboBox  is not empty
        public static bool IsNotEmpty(ComboBox cb, string name)
        {
            bool result = true;
            if (cb.Text == "")
            {
                MessageBox.Show(name + " has to be provided",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
                cb.Focus();
            }
            return result;
        }

                public static string LineEnd { get; set; } = "\n";


        public static string IsPresent(string value, string name)
        {
            string msg = "";
            if (value == "")
            {
                msg += name + " is a required field." + LineEnd;
            }
            return msg;
        }

        public static string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg += name + " must be a valid decimal value." + LineEnd;
            }
            return msg;
        }

        // checks if input in a text box in an int
        public static bool IsInteger(TextBox tb, string v)
        {
            bool result = true;
            int parsedValue;


            if (!Int32.TryParse(tb.Text, out parsedValue))// bad!
            {
                MessageBox.Show(v + " has to be a whole number",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
                tb.SelectAll();
                tb.Focus();
            }
            return result;
        }

        // The IsInt32 and IsWithinRange methods were omitted from figure 12-15.
        public static string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg += name + " must be a valid integer value." + LineEnd;
            }
            return msg;
        }

        public static string IsWithinRange(string value, string name, decimal min,
            decimal max)
        {
            string msg = "";
            if (Decimal.TryParse(value, out decimal number))
            {
                if (number < min || number > max)
                {
                    msg += name + " must be between " + min + " and " + max + "." + LineEnd;
                }
            }
            return msg;
        }
    }
}
