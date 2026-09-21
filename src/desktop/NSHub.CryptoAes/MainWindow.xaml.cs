// <copyright file="MainWindow.xaml.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Windows;

namespace NSHub.CryptoAes;

/// <summary>
/// Interaction logic for MainWindow.xaml.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Handles the Click event of the BtnDecrypt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>>
    private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string? iv = null;
            string? key = null;

            if (!string.IsNullOrWhiteSpace(TxtIv.Text))
            {
                iv = TxtIv.Text;
            }

            if (!string.IsNullOrWhiteSpace(TxtKey.Text))
            {
                key = TxtKey.Text;
            }

            TxtDecryptResult.Text = AesService.Decrypt(TxtDecrypt.Text, key, iv);
        }
        catch (Exception ex)
        {
            TxtDecryptResult.Text = TxtDecrypt.Text;
            _ = MessageBox.Show(ex.Message, "Crypto Aes", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    /// <summary>
    /// Handles the Click event of the BtnEncrypt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string? iv = null;
            string? key = null;

            if (!string.IsNullOrWhiteSpace(TxtIv.Text))
            {
                iv = TxtIv.Text;
            }

            if (!string.IsNullOrWhiteSpace(TxtKey.Text))
            {
                key = TxtKey.Text;
            }

            TxtEncryptResult.Text = AesService.Encrypt(TxtEncrypt.Text, key, iv);
        }
        catch (Exception ex)
        {
            TxtEncryptResult.Text = TxtEncrypt.Text;
            _ = MessageBox.Show(ex.Message, "Crypto Aes", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    /// <summary>
    /// Handles the TextChanged event of the TxtEncrypt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void TxtEncrypt_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) =>
        BtnEncrypt.IsEnabled = !string.IsNullOrWhiteSpace(TxtEncrypt.Text);

    /// <summary>
    /// Handles the TextChanged event of the TxtDecrypt control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void TxtDecrypt_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) =>
        BtnDecrypt.IsEnabled = !string.IsNullOrWhiteSpace(TxtDecrypt.Text);
}
