﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TelasReclame.Models;
using TelasReclame.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco é documentado em http://go.microsoft.com/fwlink/?LinkId=234238

namespace TelasReclame.Views
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class AddReclamacao : Page
    {

        public AddReclamacaoViewModel ViewModel { get; set; }
        App myApp = (App)App.Current;
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {            
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        public AddReclamacao()
        {
            this.InitializeComponent();
            ViewModel = new AddReclamacaoViewModel();
            DataContext = ViewModel;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListCategoria.SelectedIndex <= -1 ||
                ListBairro.SelectedIndex <= -1 ||
                string.IsNullOrWhiteSpace(TextBoxEndereco.Text) ||
                string.IsNullOrWhiteSpace(TextBoxDescricao.Text))
            {
                var dialog = new MessageDialog("Favor preencher todos os campos antes de salvar a reclamação.");
                await dialog.ShowAsync();
            }
            else
            {            
                App myApp = (App)App.Current;
                ViewModel.ReclamacaoAtual.DataCriacao = DateTime.Now;           
                myApp.Reclamacoes.ListaReclamacoes.Add(ViewModel.ReclamacaoAtual);
                bool ok = await myApp.Reclamacoes.Save();
                if (ok)
                {                    
                    this.Frame.GoBack();
                }
                else
                {
                    myApp.Reclamacoes.ListaReclamacoes.RemoveAt(myApp.Reclamacoes.ListaReclamacoes.Count - 1);
                    var dialog = new MessageDialog("Falha no armazenamento da reclamação.");
                    await dialog.ShowAsync();
                }
            }
        }

        private async void ImagePickerButton_Click(object sender, RoutedEventArgs e)
        {            
            FileOpenPicker openPicker = new FileOpenPicker();            
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");            

            StorageFile imagem = await openPicker.PickSingleFileAsync();
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            string nomeImagem = "img_" + ViewModel.ReclamacaoAtual.Id;

            if (imagem != null)
            {
                // Application now has read/write access to the picked file                            
                StorageFile copiaImagem = await imagem.CopyAsync(localFolder, nomeImagem, NameCollisionOption.GenerateUniqueName);
                ViewModel.ReclamacaoAtual.URLImagem = copiaImagem.Path;
                Uri imageUri = new Uri(ViewModel.ReclamacaoAtual.URLImagem, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);                
                ImagemRetangulo.Source = imageBitmap;                    
            }

        }       

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void RemoveImageButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(ViewModel.ReclamacaoAtual.URLImagem))
                File.Delete(ViewModel.ReclamacaoAtual.URLImagem);
            ViewModel.ReclamacaoAtual.URLImagem = null;
            BitmapImage imagemPadrao = new BitmapImage(new Uri(this.BaseUri, "/Assets/nopicdefault.png"));
            ImagemRetangulo.Source = imagemPadrao;
        }
    }
}
