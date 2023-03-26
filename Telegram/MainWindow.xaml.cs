using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bogus;
using Emoji;


namespace Telegram
{
    
    public partial class MainWindow : Window
    {
        public List<User> contact { get; set; } = new();

        


        public void LoadChats()
        {
            
        }

        public MainWindow()
        {
            InitializeComponent();
            contact = new Faker<User>().RuleFor(p => p.name, f => f.Person.FullName).RuleFor(p => p.date, f => f.Date.Recent()).Generate(3);
            DataContext = this;
        }
        private async void text_box_mouseEnter(object sender, MouseEventArgs e)
        {
            if (txt_box.Text == "Type a message")
            {
                await Task.Delay(1000);

                txt_box.Text = " ";
                txt_box.Foreground = new SolidColorBrush(Colors.Black);
                txt_box.FontStyle = FontStyles.Normal;
            }
        }

        private void text_box_mouseLeave(object sender, MouseEventArgs e)
        {
            if (txt_box.Text == string.Empty)
            {
                txt_box.Foreground = new SolidColorBrush(Colors.Gray);
                txt_box.Text = "Type a message";
            }
        }


        private void emoji_Picked(object sender, Emoji.Wpf.EmojiPickedEventArgs e)
        {
            var emo = emoji.Selection;
            if (txt_box.Text == "Write a message")
            {
                txt_box.Clear();
                txt_box.Foreground = new SolidColorBrush(Colors.Black);
                txt_box.Text += emo;
            }
            else
                txt_box.Text += emo;

        }
        private void ListView_DoubleClick(object sender, MouseEventArgs e)
        {


            Stckpnl.Children.Clear();
            if (sender is ListView listView)
            {
                var person = listView.SelectedItem as Person;
                tbl_Name.Text = person.FullName;
            }
            LoadChats();
        }

    }
}
