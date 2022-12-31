using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        // 実行ボタン押下処理
        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            // 複製するフォルダが存在する場合
            if (Directory.Exists(createFolderTextBox.Text))
            {
                try
                {
                    // 出力先のフォルダに作成する
                    SetFolder(createFolderTextBox.Text,outputFolderTextBox.Text);
                    MessageBox.Show("完了しました。", "メッセージ",MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("エラーが発生しました。", "エラーメッセージ", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("入力したフォルダは存在しません。","エラーメッセージ", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 作成フォルダのフォルダ構成を出力先フォルダに構築する
        /// </summary>
        /// <param name="path">フォルダパス</param>
        /// <param name="createPath">フォルダパス</param>
        private void SetFolder(string createPath, string outputPath)
        {
            // 子フォルダを全て取得
            var allFolder = Directory.GetDirectories(createPath);

            // 各フォルダごと一番下の階層まで処理する
            foreach (var folder in allFolder)
            {
                // フルパスからフォルダ名を取得
                var folderName = Path.GetFileName(folder);
                outputPath += @"\" + folderName;
                // 親フォルダ内にフォルダを作成
                Directory.CreateDirectory(outputPath);
                // 再帰的にフォルダ構成を構築
                SetFolder(folder, outputPath);
            }
        }
    }
}
