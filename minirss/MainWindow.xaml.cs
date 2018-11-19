using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace minirss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.fillFeeds();
        }

        public async void fillFeeds()
        {
            var rss = new Rss();
            var items = await rss.GetAllItemsFromAllFeeds();
            this.mainList.Items.Clear();
            foreach (var item in items)
            {
                this.mainList.Items.Add(item);
            }
            this.mainList.SelectedIndex = 0;
        }

        public void SafeSelectIndex(int index)
        {
            if (index < 0)
            {
                index = 0;
            }
            if (index >= this.mainList.Items.Count)
            {
                index = this.mainList.Items.Count - 1;
            }
            this.mainList.SelectedIndex = index;
            this.mainList.ScrollIntoView(this.mainList.Items[index]);
        }

        private void mainList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.J)
            {
                this.SafeSelectIndex(this.mainList.SelectedIndex + 1);
            }

            if (e.Key == Key.K)
            {
                this.SafeSelectIndex(this.mainList.SelectedIndex - 1);
            }

            if (e.Key == Key.Enter)
            {
                System.Diagnostics.Process.Start(((MiniFeedItem)this.mainList.Items[this.mainList.SelectedIndex]).Link);
            }
        }
    }
}
