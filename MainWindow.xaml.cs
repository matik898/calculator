using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    public partial class MainWindow : Window
    {
        public float Result = 0;
        public string CurrentNumberString;
        public string currentFunction = "";
        public string leftNumberString = "";
        public bool isCleared = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get initial result
        /// </summary>
        /// <returns></returns>
        static public float GetInitResult()
        {
            return 0;
        }

        /// <summary>
        /// Show current string
        /// </summary>
        /// <param name="value">string</param>
        public void ShowCurrentString(string value)
        {
            this.currentString.Content = value;
        }

        /// <summary>
        /// Push number as string to current number string 
        /// </summary>
        /// <param name="numberAsString">number as string</param>
        public void PushNumberAsString(string numberAsString)
        {
            this.CurrentNumberString += numberAsString;

            ShowCurrentString(this.CurrentNumberString);
        }

        /// <summary>
        /// Clear last character
        /// </summary>
        public void ClearLastCharacter()
        {
            int index = this.CurrentNumberString.Count() - 1;

            if (index > -1)
            {
                this.CurrentNumberString = this.CurrentNumberString.Substring(0, index);
                ShowCurrentString(this.CurrentNumberString);
            }
        }

        /// <summary>
        /// Clear current string
        /// </summary>
        public void ClearCurrentString()
        {
            this.CurrentNumberString = "";

            ShowCurrentString(this.CurrentNumberString);
        }

        /// <summary>
        /// Check if field is cleared and calculate
        /// </summary>
        /// <returns>result</returns>
        public string CheckIfFieldIsCleardAndCalc()
        {
            string result = "";

            if (this.isCleared)
            {
                this.isCleared = false;
                this.resultString.Content = "";
                this.leftNumberString = "0";

                this.CurrentNumberString = this.Result.ToString();
            }
            else
            {
                if (this.currentFunction != "") result = this.Calc(this.currentFunction);
            }

            return result;
        }

        /// <summary>
        /// Divide
        /// </summary>
        public void Divide()
        {
            string result = CheckIfFieldIsCleardAndCalc();

            this.currentFunction = "/";

            this.leftNumberString = result != "" ? result : this.CurrentNumberString;

            ShowStringResult(this.resultString.Content.ToString() + this.CurrentNumberString + " / ");

            this.CurrentNumberString = "";
        }

        /// <summary>
        /// Multiply
        /// </summary>
        public void Multiply()
        {
            string result = CheckIfFieldIsCleardAndCalc();

            this.currentFunction = "*";

            this.leftNumberString = result != "" ? result : this.CurrentNumberString;

            ShowStringResult(this.resultString.Content.ToString() + this.CurrentNumberString + " * ");

            this.CurrentNumberString = "";
        }


        /// <summary>
        /// Add
        /// </summary>
        public void Add()
        {
            string result = CheckIfFieldIsCleardAndCalc();

            this.currentFunction = "+";

            this.leftNumberString = result != "" ? result : this.CurrentNumberString;

            ShowStringResult(this.resultString.Content.ToString() + this.CurrentNumberString + " + ");

            this.CurrentNumberString = "";

        }

        /// <summary>
        /// Substract
        /// </summary>
        public void Subtract()
        {
            string result = CheckIfFieldIsCleardAndCalc();

            this.currentFunction = "-";

            this.leftNumberString = result != "" ? result : this.CurrentNumberString;

            ShowStringResult(this.resultString.Content.ToString() + this.CurrentNumberString + " - ");

            this.CurrentNumberString = "";
        }

        /// <summary>
        /// Comma character
        /// </summary>
        public void Comma()
        {
            bool existInString = false;

            foreach (char el in this.CurrentNumberString)
            {
                if (el == ',')
                {
                    existInString = true;
                }
            }

            if (!existInString)
            {
                this.CurrentNumberString += ",";
                ShowCurrentString(this.CurrentNumberString);
            }
        }

        /// <summary>
        /// Change character
        /// </summary>
        public void ChangeCharacter()
        {
            this.CurrentNumberString = (float.Parse(this.CurrentNumberString) * (-1)).ToString();
            ShowCurrentString(this.CurrentNumberString);
        }

        /// <summary>
        /// Show result
        /// </summary>
        /// <param name="result">result</param>
        public void ShowResult(float? result)
        {
            if (result != null)
            {
                this.resultString.Content = this.Result;
            }
            else
            {
                this.resultString.Content = "";
            }
        }

        /// <summary>
        /// Show string result
        /// </summary>
        /// <param name="result">result</param>
        public void ShowStringResult(string result)
        {
            this.resultString.Content = result;
        }

        /// <summary>
        /// Transform string to number
        /// </summary>
        /// <param name="text">number as string</param>
        /// <returns>number</returns>
        static public float ToFloat(string text)
        {
            return float.Parse(text);
        }

        /// <summary>
        /// Calculate numbers
        /// </summary>
        /// <param name="type">add/divide/substract/etc..</param>
        /// <returns>result</returns>
        public string Calc(string type)
        {
            if (this.leftNumberString != "" && this.CurrentNumberString != "")
            {
                switch (type)
                {
                    case "/":
                        {
                            return (MainWindow.ToFloat(this.leftNumberString) / float.Parse(this.CurrentNumberString)).ToString();
                        }
                    case "*":
                        {
                            return (float.Parse(this.leftNumberString) * float.Parse(this.CurrentNumberString)).ToString();
                        }
                    case "-":
                        {
                            return (float.Parse(this.leftNumberString) - float.Parse(this.CurrentNumberString)).ToString();
                        }
                    case "+":
                        {
                            return (float.Parse(this.leftNumberString) + float.Parse(this.CurrentNumberString)).ToString();
                        }
                    case "=":
                        {
                            return "";
                        }
                    case ",":
                        {
                            return "";
                        }
                    case "+/-":
                        {
                            return "";
                        }
                    default: return "";
                }
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// Clear variables
        /// </summary>
        public void ClearAllParams()
        {
            if (this.isCleared)
            {
                this.isCleared = false;
                this.resultString.Content = "";

                this.CurrentNumberString = "";
                this.leftNumberString = "";
                this.currentFunction = "";
                this.Result = 0;
            }
        }


        /// <summary>
        /// On click event
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">event</param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string value = button.Content.ToString();

            switch (value)
            {
                case "1":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "2":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "3":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "4":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "5":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "6":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "7":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "8":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "9":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "0":
                    {
                        ClearAllParams();
                        PushNumberAsString(value);
                        break;
                    }
                case "C":
                    {
                        this.leftNumberString = "";
                        ClearCurrentString();
                        break;
                    }
                case "CE":
                    {
                        ClearCurrentString();
                        this.Result = 0;
                        this.leftNumberString = "";
                        ShowResult(null);
                        break;
                    }
                case "back":
                    {
                        ClearLastCharacter();
                        break;
                    }
                case "/":
                    {
                        Divide();
                        break;
                    }
                case "*":
                    {
                        Multiply();
                        break;
                    }
                case "-":
                    {
                        Subtract();
                        break;
                    }
                case "+":
                    {
                        Add();
                        break;
                    }
                case "=":
                    {
                        string calculatedValue = this.Calc(this.currentFunction);

                        if (this.isCleared)
                        {
                            this.resultString.Content = (float.Parse(calculatedValue) - float.Parse(this.CurrentNumberString)) + " " + this.currentFunction + " " + this.CurrentNumberString + " = " + calculatedValue;
                        }
                        else
                        {
                            this.resultString.Content += this.CurrentNumberString + " = " + calculatedValue;
                        }
                        this.leftNumberString = calculatedValue;
                        this.Result = float.Parse(calculatedValue);

                        this.isCleared = true;
                        break;
                    }
                case ",":
                    {
                        Comma();
                        break;
                    }
                case "+/-":
                    {
                        ChangeCharacter();
                        break;
                    }
            }


        }
    }
}
