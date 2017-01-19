using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Administracion.Presentacion.Utilidades
{
    public static class TextBoxMaxValueBehavior
    {
        private static readonly DependencyPropertyKey _maxValueExpressionPropertyKey = DependencyProperty.RegisterAttachedReadOnly("MaxValueExpression",
            typeof(int),
            typeof(TextBoxMaxValueBehavior),
            new FrameworkPropertyMetadata());

        
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.RegisterAttached("MaxValue",
            typeof(string),
            typeof(TextBoxMaxValueBehavior),
            new FrameworkPropertyMetadata(OnMaxValueChanged));

        public static readonly DependencyProperty MaxValueExpressionProperty = _maxValueExpressionPropertyKey.DependencyProperty;

        public static string GetMaxValue(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            return textBox.GetValue(MaxValueProperty) as string;
        }

        public static void SetMaxValue(TextBox textBox, string maxValue)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            textBox.SetValue(MaxValueProperty, maxValue);
        }

        public static int GetMaxValueExpression(TextBox textBox)
        {
            if (textBox == null)
            {
                throw new ArgumentNullException("textBox");
            }

            return Convert.ToInt32(textBox.GetValue(MaxValueExpressionProperty));
        }

        private static void SetMaxValueExpression(TextBox textBox, int value)
        {
            textBox.SetValue(_maxValueExpressionPropertyKey, value);
        }

        private static void OnMaxValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var textBox = dependencyObject as TextBox;
            var maxValue = e.NewValue as string;
            textBox.PreviewTextInput -= textBox_PreviewTextInput;
            textBox.PreviewKeyDown -= textBox_PreviewKeyDown;
            DataObject.RemovePastingHandler(textBox, Pasting);

            if (maxValue == null)
            {
                textBox.ClearValue(MaxValueProperty);
                textBox.ClearValue(MaxValueExpressionProperty);
            }
            else
            {
                textBox.SetValue(MaxValueProperty, maxValue);
                SetMaxValueExpression(textBox, int.Parse(maxValue));
                textBox.PreviewTextInput += textBox_PreviewTextInput;
                textBox.PreviewKeyDown += textBox_PreviewKeyDown;
                DataObject.AddPastingHandler(textBox, Pasting);
            }
        }

        private static void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            var maxValue = GetMaxValueExpression(textBox);

            if (maxValue == 0)
            {
                return;
            }

            var value = GetProposedText(textBox, e.Text);

            if (int.Parse(value) > maxValue)
            {
                e.Handled = true;
            }
        }

        private static void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            var maxValue = GetMaxValueExpression(textBox);

            if (maxValue == 0)
            {
                return;
            }

            if (e.Key == Key.Space)
            {
                var value = GetProposedText(textBox, " ");

                if (int.Parse(value) > maxValue)
                {
                    e.Handled = true;
                }
            }
        }

        private static void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            var textBox = sender as TextBox;
            var maxValue = GetMaxValueExpression(textBox);

            if (maxValue == 0)
            {
                return;
            }

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = e.DataObject.GetData(typeof(string)) as string;
                var value = GetProposedText(textBox, pastedText);

                if (int.Parse(value) > maxValue)
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static string GetProposedText(TextBox textBox, string newText)
        {
            var text = textBox.Text;

            if (textBox.SelectionStart != -1)
            {
                text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
            }

            text = text.Insert(textBox.CaretIndex, newText);

            return text;
        }
    }
}
