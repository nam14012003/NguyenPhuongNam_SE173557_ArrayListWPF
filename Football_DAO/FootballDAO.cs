using NguyenPhuongNam_SE173557;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_DAO
{

    public class FootballDAO
    {
        private readonly ArrayList players = new ArrayList();

        public ArrayList GetAll()
        {
            return players;
        }

        public Football GetById(int id)
        {
            return players.OfType<Football>().FirstOrDefault(p => p.PlayerID == id);
        }


        public bool AddNewPlayer(Football football)
        {
            bool isSuccess = false;
            Football playerProfile = this.GetById(football.PlayerID);
            try
            {
                if (playerProfile == null)
                {
                    players.Add(football);
                    isSuccess = true;
                }

            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return isSuccess;
        }

        public bool UpdatePlayerProfile(Football football)
        {
            var existingPlayer = players.OfType<Football>().FirstOrDefault(p => p.PlayerID == football.PlayerID);
            if (existingPlayer == null)
            {
                throw new Exception("không tìm thấy cầu thủ");
            }
            try
            {
                int index = players.IndexOf(existingPlayer);

                if (index >= 0)
                {   
                    players[index] = football;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
            return false;
        }



        public bool DeletePlayerProfile(int playerId)
        {
            bool isSuccess = false;
            Football playerProfile = this.GetById(playerId);
            try
            {
                if (playerId != null)
                {
                    players.Remove(playerProfile);
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
            return isSuccess;
        }
    }
}

