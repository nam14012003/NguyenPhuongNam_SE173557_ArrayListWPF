using Football_Repo;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace NguyenPhuongNam_SE173557
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFootballRepo footballRepo;
        private ArrayList players = new ArrayList();
        public MainWindow()
        {
            footballRepo = new FootballRepo();
            InitializeComponent();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPlayers();

            txtPlayerId.Clear();
            txtPlayerName.Clear();
            txtOriginCountry.Clear();
            txtAchievements.Clear();
            dpBirthday.SelectedDate = null;
        }

        private void LoadPlayers()
        {
            players = footballRepo.GetAll();
            dtgFootballPlayer.ItemsSource = null;
            dtgFootballPlayer.ItemsSource = players;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int playerId = int.Parse(txtPlayerId.Text);

            var player = footballRepo.GetById(playerId);
            if (player != null)
            {
                MessageBox.Show($"Cầu thủ Với ID {playerId} đã tồn tại.");
                return;
            }
            Football football = new Football();
            football.PlayerID = int.Parse(txtPlayerId.Text);
            football.PlayerName = txtPlayerName.Text;
            football.Birthday = DateTime.Parse(dpBirthday.Text);
            football.Achievements = txtAchievements.Text;
            football.OriginCountry = txtOriginCountry.Text;

            if (footballRepo.AddNewPlayer(football))
            {
                Window_Loaded(sender, e);
                MessageBox.Show(" Thêm Cầu Thủ Thành Công");

            }
            else
            {
                MessageBox.Show("Thêm Cầu Thủ Thất Bại");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int playerId = int.Parse(txtPlayerId.Text);

            var football = footballRepo.GetById(playerId);
            if (football == null)
            {
                MessageBox.Show($"Cầu thủ Với ID {playerId} không tìm thấy");
                return;
            }
            football.PlayerName = txtPlayerName.Text;
            football.Achievements = txtAchievements.Text;
            football.Birthday = DateTime.Parse(dpBirthday.Text);
            football.OriginCountry = txtOriginCountry.Text;

            if (footballRepo.UpdatePlayerProfile(football))
            {
                MessageBox.Show("Thay đổi thông tin cầu thủ thành công");
                Window_Loaded(sender, e);

            }
            else
            {
                MessageBox.Show("Cập nhật thông tin cầu thủ thất bại ");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int playerId = int.Parse(txtPlayerId.Text);


            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa cầu thủ này không?",
                                          "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                if (playerId > 0 && footballRepo.DeletePlayerProfile(playerId))
                {
                    MessageBox.Show("Xóa cầu thủ thành công");
                    Window_Loaded(sender,e);
                }
                else
                {
                    MessageBox.Show("Xóa cầu thủ thất bại");
                }
            }
        }

        private void dtgFootballPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgFootballPlayer.SelectedItem is Football selectedPlayer)
            {
                txtPlayerId.Text = selectedPlayer.PlayerID.ToString();
                txtPlayerName.Text = selectedPlayer.PlayerName;
                txtOriginCountry.Text = selectedPlayer.OriginCountry.ToString();
                txtAchievements.Text = selectedPlayer.Achievements.ToString();
                dpBirthday.Text = selectedPlayer.Birthday.ToString();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}