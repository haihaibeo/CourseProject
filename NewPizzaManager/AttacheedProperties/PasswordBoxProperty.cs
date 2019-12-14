using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewPizzaManager
{ 
    public class PasswordBoxProperty
    {
        // public bool HasText { get; set; } = false;
        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperty), new PropertyMetadata(false));

        public static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }

        public static readonly DependencyProperty PasswordMonitoredProperty =
        DependencyProperty.RegisterAttached("PasswordMonitored", typeof(bool), typeof(PasswordBoxProperty), new PropertyMetadata(false, OnPasswordChanged));

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            if (passwordBox == null)
                return;
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if((bool)e.NewValue == true)
            {
                SetHasText(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHasText(sender as PasswordBox);
        }

        public static void SetPasswordMonitored(PasswordBox element, bool value)
        {
            element.SetValue(PasswordMonitoredProperty, value);
        }

        public static bool GetPasswordMonitored(PasswordBox element)
        {
            return (bool)element.GetValue(PasswordMonitoredProperty);
        }


    }
}
